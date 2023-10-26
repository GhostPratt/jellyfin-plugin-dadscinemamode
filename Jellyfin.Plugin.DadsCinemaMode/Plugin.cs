using System;
using System.Collections.Generic;
using Jellyfin.Plugin.DadsCinemaMode.Configuration;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Controller.Library;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;
using MediaBrowser.Controller;
using MediaBrowser.Controller.Channels;
using Microsoft.Extensions.Logging;

namespace Jellyfin.Plugin.DadsCinemaMode
{
    public class Plugin : BasePlugin<PluginConfiguration>, IHasWebPages
    {
        public override string Name => "Dads Cinema Mode";

        public override Guid Id => Guid.Parse("00EDEF7D-5307-43D6-BE63-49CE1FD5C29F");

        public static Plugin Instance { get; private set; }

        public PluginConfiguration PluginConfiguration => Configuration;

        public static IServerApplicationPaths ServerApplicationPaths { get; private set; }

        public static ILibraryManager LibraryManager { get; private set; }
        public static IChannelManager ChannelManager { get; private set; }
        public static ILogger<Plugin> Logger { get; private set; }

        public Plugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer, ILibraryManager libraryManager, IServerApplicationPaths serverApplicationPaths, IChannelManager channelManager, ILogger<Plugin> logger)
            : base(applicationPaths, xmlSerializer)
        {
            Instance = this;
            LibraryManager = libraryManager;
            ServerApplicationPaths = serverApplicationPaths;
            ChannelManager = channelManager;
            Logger = logger;
        }

        public IEnumerable<PluginPageInfo> GetPages()
        {
            yield return new PluginPageInfo
            {
                Name = Name,
                EmbeddedResourcePath = GetType().Namespace + ".Configuration.config.html"
            };
        }
    }
}