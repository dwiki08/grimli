using Grimoire.Networking;

namespace ExamplePacketPlugin
{
    public class JoinHandler : IXtMessageHandler
    {
        public string[] HandledCommands { get; } = {"tfer"};

        public string MapToJoin { get; set; }

        public void Handle(XtMessage message)
        {
            message.Arguments[7] = MapToJoin;

            /* 
               %xt%zm%cmd%1%tfer%yourUsername%whitemob-654321%
                
               0 = 
               1 = xt
               2 = zm
               3 = cmd
               4 = 1
               5 = tfer
               6 = yourUsername
               7 = whitemob-654321
               8 = 

            */
        }
    }
}
