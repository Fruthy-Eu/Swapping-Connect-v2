#nullable enable
using DiscordRPC;
using DiscordRPC.Message;
using System;
using System.Diagnostics;

namespace SwappingConnectV2.Main.Classes
{
    public class DiscordRpc
    {
        private DiscordRpcClient discordrpc;
        public DiscordRpc()
        {
            discordrpc = new DiscordRpcClient("933050129743769670");

            discordrpc.OnReady += OnReady;

            _currentPresence = new RichPresence
            {
                Assets = _assets,
                Buttons = _discordButtons,
                Timestamps = _timestamps,
                State = "🥀 • Made by Tamely & Fruthy"
            };

            discordrpc.Initialize();
        }

        private void OnReady(object sender, ReadyMessage e)
        {
            Console.WriteLine("Received Ready from user {0}", e.User.Username);
            SetDiscordLocation("Dashboard");
        }

        private readonly Assets _assets = new()
        {
            LargeImageKey = "swappingconnect",
        };

        private readonly Button[] _discordButtons =
        {
            new()
            {
                Label = "Discord",
                Url = "https://discord.gg/uShUdSE3ME"
            }
        };

        private readonly RichPresence _currentPresence;
        private readonly Timestamps _timestamps = new()
        {
            StartUnixMilliseconds = (ulong)DateTimeOffset.Now.ToUnixTimeSeconds()
        };

        public User ReturnUser() => discordrpc.CurrentUser;

        public void SetDiscordLocation(string Location)
        {
            if (!discordrpc.IsInitialized) return;

            _currentPresence.Details = $"🧊 • In The {Location} Tab";
            discordrpc.SetPresence(_currentPresence);
        }

        public void SetDiscordAction(string Action)
        {
            if (!discordrpc.IsInitialized) return;

            _currentPresence.Details = $"🧊 • {Action}";
            discordrpc.SetPresence(_currentPresence);
        }
    }
}