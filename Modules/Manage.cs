using Discord;
using Discord.Commands;
using System.Threading.Tasks;
using SkeletonBot.Model;

namespace SkeletonBot.Modules
{
    public class Manage : ModuleBase<SocketCommandContext>
    {
        private string _inviteLink = "https://discordapp.com/api/oauth2/authorize?client_id={0}&permissions=8&scope=bot";

        [Command(Commands.Ping)]
        [Summary(Summary.Ping)]
        public async Task PingDefault()
        {
            EmbedBuilder builder = new EmbedBuilder();
            builder.WithTitle("Pong!").WithDescription("Pong Pong Pong!").WithColor(Color.Blue);
            await ReplyAsync("", false, builder.Build());
        }

        [Command(Commands.Clean), RequireUserPermission(ChannelPermission.ManageMessages)]
        [Summary(Summary.Clean)]
        public async Task Clean(int delnum = 0)
        {
            if (delnum == 0)
            {
                await ReplyAsync("Quantas Mensagens?");
                return;
            }
            else if (delnum > 100)
            {
                await ReplyAsync("100 é o maximo de mensagens a serem excluidas.");
                return;
            }

            var messages = await Context.Channel.GetMessagesAsync(delnum + 1).FlattenAsync();
            foreach (var message in messages)
                await Context.Channel.DeleteMessageAsync(message.Id);
        }

        [Command(Commands.InviteBot)]
        [Summary(Summary.InviteBot)]
        public async Task InviteBot()
        {
            try
            {
                await Context.User.SendMessageAsync(string.Format(_inviteLink, Context.Client.CurrentUser.Id));
            }
            catch { }
        }
    }
}
