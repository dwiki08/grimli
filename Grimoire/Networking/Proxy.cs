using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Grimoire.Networking.Handlers;
using Grimoire.Tools;

namespace Grimoire.Networking
{
    public class Proxy
    {
        public static Proxy Instance { get; set; } = new Proxy();

        public delegate void Receive(Message message);

        public event Receive ReceivedFromClient;
        public event Receive ReceivedFromServer;

        private readonly List<IJsonMessageHandler> _handlersJson = new List<IJsonMessageHandler>
        {
            new HandlerDropItem(),
            new HandlerGetQuests(),
            new HandlerQuestComplete(),
            new HandlerLoadShop()
        };

        private readonly List<IXtMessageHandler> _handlersXt = new List<IXtMessageHandler>();

        private readonly List<IXmlMessageHandler> _handlersXml = new List<IXmlMessageHandler>
        {
            new HandlerPolicy()
        };

        private TcpClient _client;
        private TcpClient _server;
        private TcpListener _listener;

        private List<byte> _bufferClient;
        private List<byte> _bufferServer;

        public int ListenerPort;
        private const int GameServerPort = 5588;
        private const int MaxBufferSize = 1024;

        private static readonly CancellationTokenSource AppClosingToken = new CancellationTokenSource();
        private bool _shouldConnect = true;
        private bool _policyReceived;

        private Proxy()
        {
            ReceivedFromServer += ProcessMessage;
            ReceivedFromClient += ProcessMessage;
            _bufferClient = new List<byte>();
            _bufferServer = new List<byte>();
        }

        public void RegisterHandler(IJsonMessageHandler handler) => RegisterHandler(handler, _handlersJson);
        public void RegisterHandler(IXmlMessageHandler handler) => RegisterHandler(handler, _handlersXml);
        public void RegisterHandler(IXtMessageHandler handler) => RegisterHandler(handler, _handlersXt);
        public void UnregisterHandler(IJsonMessageHandler handler) => _handlersJson.Remove(handler);
        public void UnregisterHandler(IXmlMessageHandler handler) => _handlersXml.Remove(handler);
        public void UnregisterHandler(IXtMessageHandler handler) => _handlersXt.Remove(handler);

        private void RegisterHandler<T>(T handler, List<T> list)
        {
            if (!list.Contains(handler))
                list.Add(handler);
        }

        public async Task Start()
        {
            if (_listener == null)
                _listener = new TcpListener(IPAddress.Loopback, ListenerPort);

            while (!AppClosingToken.IsCancellationRequested)
            {
                if (_shouldConnect)
                {
                    try
                    {
                        await AcceptAndConnect();
                        _shouldConnect = false;
                    }
                    catch
                    {
                    }
                }
                else
                {
                    await Task.Delay(1000); // What to do here?
                }
            }
        }

        private async Task AcceptAndConnect()
        {
            _listener.Start();

            _client = await _listener.AcceptTcpClientAsync();
            _server = new TcpClient();
            IPAddress gameServerAddress;

            try
            {
                gameServerAddress = IPAddress.Parse(Flash.Call<string>("RealAddress"));
                //this._client.Connect(IPAddress.Parse(Flash.Call<string>("RealAddress")), GameServerPort);
            }
            catch (Exception)
            {
                gameServerAddress = Dns.GetHostAddresses(Flash.Call<string>("RealAddress"))[0];
                //this._client.Connect(Dns.GetHostAddresses(Flash.Call<string>("RealAddress"))[0], GameServerPort);
            }

            if (!_policyReceived)
            {
                byte[] cbuffer = new byte[MaxBufferSize], sbuffer = new byte[MaxBufferSize];
                cbuffer = ReceiveOnce(cbuffer, await _client.GetStream().ReadAsync(cbuffer, 0, MaxBufferSize));

                await _server.ConnectAsync(gameServerAddress, GameServerPort);
                await SendToServer(cbuffer);

                sbuffer = ReceiveOnce(sbuffer, await _server.GetStream().ReadAsync(sbuffer, 0, MaxBufferSize));
                await SendToClient(ModifyDomainPolicy(sbuffer));

                _client.Close();
                _client = await _listener.AcceptTcpClientAsync();
                _policyReceived = true;
            }
            else
            {
                await _server.ConnectAsync(gameServerAddress, GameServerPort);
            }

            _listener.Stop();
            Task.Factory.StartNew(ReceiveFromClient, TaskCreationOptions.LongRunning);
            Task.Factory.StartNew(ReceiveFromServer, TaskCreationOptions.LongRunning);
        }

        // Modifies the policy file (sets the allowed port to ListenerPort) to allow multiple Grimoire instances
        private byte[] ModifyDomainPolicy(byte[] policy)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Encoding.UTF8.GetString(policy));
            doc["cross-domain-policy"]["allow-access-from"].Attributes["to-ports"].Value = ListenerPort.ToString();
            return Encoding.UTF8.GetBytes(doc.OuterXml);
        }

        private byte[] ReceiveOnce(byte[] buffer, int read)
        {
            byte[] c = new byte[read];
            Array.Copy(buffer, c, read);
            return c;
        }

        public void Stop(bool appClosing)
        {
            if (!_shouldConnect)
            {
                if (appClosing)
                    AppClosingToken.Cancel();
                _server?.Close();
                _client?.Close();
                _listener.Stop();
                _shouldConnect = true;
            }
        }

        private async Task ReceiveFromClient()
        {
            while (!AppClosingToken.IsCancellationRequested)
            {
                try
                {
                    NetworkStream stream = _client.GetStream();

                    if (_shouldConnect || !stream.CanRead)
                        continue;

                    int read;
                    byte[] buffer = new byte[MaxBufferSize];

                    if ((read = await stream.ReadAsync(buffer, 0, MaxBufferSize)) == 0)
                    {
                        Stop(false);
                        return;
                    }

                    int i = 0;
                    while (--read >= 0)
                    {
                        byte b = buffer[i++];
                        if (b != 0x00)
                            _bufferClient.Add(b);
                        else
                        {
                            byte[] data = _bufferClient.ToArray();

                            Message msg = CreateMessage(Encoding.UTF8.GetString(data));

                            ReceivedFromClient?.Invoke(msg);

                            if (msg.Send)
                                await SendToServer(msg.ToString());

                            _bufferClient = new List<byte>();
                        }
                    }
                }
                catch
                {
                    Stop(false);
                    return;
                }
            }
        }

        private async Task ReceiveFromServer()
        {
            while (!AppClosingToken.IsCancellationRequested)
            {
                try
                {
                    NetworkStream stream = _server.GetStream();

                    if (_shouldConnect || !stream.CanRead)
                        continue;

                    int read;
                    byte[] buffer = new byte[MaxBufferSize];

                    if ((read = await stream.ReadAsync(buffer, 0, MaxBufferSize)) == 0)
                    {
                        Stop(false);
                        return;
                    }

                    int i = 0;
                    while (--read >= 0)
                    {
                        byte b = buffer[i++];

                        if (b != 0x00)
                            _bufferServer.Add(b);
                        else
                        {
                            byte[] data = _bufferServer.ToArray();

                            Message msg = CreateMessage(Encoding.UTF8.GetString(data));

                            ReceivedFromServer?.Invoke(msg);

                            if (msg.Send)
                                await SendToClient(msg.ToString());

                            _bufferServer = new List<byte>();
                        }
                    }
                }
                catch
                {
                    Stop(false);
                    return;
                }
            }
        }

        public async Task SendToServer(string data)
        {
            if (data?.Length > 0)
            {
                if (data[data.Length - 1] != '\0')
                    data += "\0";
                await SendToServer(Encoding.UTF8.GetBytes(data));
            }
        }

        public async Task SendToServer(byte[] data)
        {
            NetworkStream stream = _server.GetStream();

            if (stream.CanWrite)
            {
                try
                {
                    await stream.WriteAsync(data, 0, data.Length);
                }
                catch
                {
                    Stop(false);
                }
            }
        }

        public async Task SendToClient(string data)
        {
            if (data?.Length > 0)
            {
                if (data[data.Length - 1] != '\0')
                    data += "\0";
                await SendToClient(Encoding.UTF8.GetBytes(data));
            }
        }

        public async Task SendToClient(byte[] data)
        {
            NetworkStream stream = _client.GetStream();

            if (stream.CanWrite)
            {
                try
                {
                    await stream.WriteAsync(data, 0, data.Length);
                }
                catch
                {
                    Stop(false);
                }
            }
        }

        private void ProcessMessage(Message message)
        {
            try
            {
                switch (message)
                {
                    case JsonMessage msgJson:
                        foreach (IJsonMessageHandler handler in _handlersJson.Where(h => h.HandledCommands.Contains(msgJson.Command)))
                            handler.Handle(msgJson);
                        break;
                    case XmlMessage msgXml:
                        foreach (IXmlMessageHandler handler in _handlersXml.Where(h => h.HandledCommands.Contains(msgXml.Command)))
                            handler.Handle(msgXml);
                        break;
                    case XtMessage msgXt:
                        foreach (IXtMessageHandler handler in _handlersXt.Where(h => h.HandledCommands.Contains(msgXt.Command)))
                            handler.Handle(msgXt);
                        break;
                }
            }
            catch
            {
            }
        }

        private Message CreateMessage(string raw)
        {
            if (raw?.Length > 0)
            {
                switch (raw[0])
                {
                    case '<': return new XmlMessage(raw);
                    case '%': return new XtMessage(raw);
                    case '{': return new JsonMessage(raw);
                }
            }

            return null;
        }
    }
}
