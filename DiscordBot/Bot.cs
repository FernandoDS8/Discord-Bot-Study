using DiscordBot.Commands;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot
{
    public class Bot
    {
        // Declaração do Bot do Discord
        public DiscordClient Client { get; private set; }

        public CommandsNextExtension Commands { get; private set; }

        //Função Para Executar o Bot de forma assíncrona
        public async Task RunAsync()
        {
            var json = string.Empty;

            //Abrir e ler o arquivo config.json
            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync().ConfigureAwait(false);

            //Instanciar a classe ConfigJson a partir dos dados que foram pegos do arquivo
            var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);

            //Cria uma nova Configuração com valores padrão
            var config = new DiscordConfiguration
            {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = LogLevel.Debug,
            };

            //Cria uma nova instância do DiscordClient que recebe como parâmetro uma nova Configuração
            Client = new DiscordClient(config);

            // Evento a ser executado quando o bot for ativado
            Client.Ready += OnClientReady;

            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { configJson.Prefix },
                EnableDms = false,
                EnableMentionPrefix = true
            };

            Commands = Client.UseCommandsNext(commandsConfig);

            Commands.RegisterCommands<TestCommands>();

            await Client.ConnectAsync();

            await Task.Delay(-1);
        }
        
        //Função que não tem retorno, mas de maneira assíncrona (substitui o void, de certa forma)
        private Task OnClientReady(object sender, ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
