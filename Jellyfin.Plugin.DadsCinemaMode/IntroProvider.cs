using Jellyfin.Data.Entities;
using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Library;

namespace jellyfin_plugin_dadscinemamode
{
    public class IntroProvider : IIntroProvider
    {
        public string Name { get; } = "DadsCinemaMode";

        public Task<IEnumerable<IntroInfo>> GetIntros(BaseItem item, User user)
        {
            // Check item type, for now just pre roll movies
            if (item is not MediaBrowser.Controller.Entities.Movies.Movie && item is not MediaBrowser.Controller.Entities.TV.Episode)
            {
                return Task.FromResult(Enumerable.Empty<IntroInfo>());
            }

            IntroManager introManager = new IntroManager();
            return Task.FromResult(introManager.Get(item, user));
        }

        public IEnumerable<string> GetAllIntroFiles()
        {
            // not implemented
            return Enumerable.Empty<string>();
        }
    }
}