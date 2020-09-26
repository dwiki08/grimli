using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Grimoire.Botting.Commands.Misc
{
    public class CmdLoadBot : IBotCommand
    {
        public string BotFileName { get; set; }

        public async Task Execute(IBotEngine instance)
        {
            string path = Path.Combine(Application.StartupPath, BotFileName);
            if (File.Exists(path))
            {
                try
                {
                    string content;
                    using (TextReader reader = new StreamReader(path))
                        content = await reader.ReadToEndAsync();

                    Configuration c = JsonConvert.DeserializeObject<Configuration>(content, new JsonSerializerSettings
                    {
                        DefaultValueHandling = DefaultValueHandling.Ignore,
                        NullValueHandling = NullValueHandling.Ignore,
                        TypeNameHandling = TypeNameHandling.All
                    });

                    if (c?.Commands.Count > 0)
                    {
                        instance.Configuration = c;
                        instance.Index = -1;
                        instance.LoadBankItems();
                        instance.LoadAllQuests();
                    }
                }
                catch { }
            }
        }

        public override string ToString()
        {
            return $"Load bot: {BotFileName}";
        }
    }
}
