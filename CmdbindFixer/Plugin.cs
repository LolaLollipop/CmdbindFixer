namespace CmdbindFixer
{
#if EXILED
    using Exiled.API.Features;
    using Exiled.Events.EventArgs.Player;
#else
    using PluginAPI.Core;
    using PluginAPI.Core.Attributes;
    using PluginAPI.Enums;
#endif

    public class CmdbindFixer
#if EXILED
    : Plugin<Config>
#endif
    {
        private static readonly UserGroup fixerGroup = new UserGroup
        {
            BadgeColor = "none"
        };

#if NWAPI
#nullable disable
        [PluginConfig] public Config Config;
#nullable enable
#endif

#if EXILED
        public override void OnEnabled()
        {
            Exiled.Events.Handlers.Player.Verified += OnPlayerVerified;
        }
#else
        [PluginEntryPoint("CmdbindFixer", "1.0.0", "Fixes cmdbinds lol", "Rue <3")]
        private void LoadPlugin()

        {
            if (!Config.IsEnabled)
            {
                return;
            }

            PluginAPI.Events.EventManager.RegisterEvents(this);
        }
#endif

#if EXILED
        private static void OnPlayerVerified(VerifiedEventArgs ev) {
            Player player = ev.Player;
#else
        [PluginEvent(ServerEventType.PlayerJoined)]
        public bool OnPlayerJoin(Player player)
        {
#endif
            UserGroup current = ServerStatic.PermissionsHandler.GetUserGroup(player.ReferenceHub.authManager.UserId);
            player.ReferenceHub.serverRoles.SetGroup(fixerGroup);
            player.ReferenceHub.serverRoles.SetGroup(current);

#if !EXILED
            return true;
#endif
        }
    }
}