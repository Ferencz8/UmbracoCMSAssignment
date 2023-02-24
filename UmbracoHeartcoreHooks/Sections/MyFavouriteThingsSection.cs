using Umbraco.Cms.Core.Sections;

namespace UmbracoHeartcoreHooks.Sections
{
    public class MyFavouriteThingsSection : ISection
    {
        /// <inheritdoc />
        public string Alias => "myFavouriteThings";

        /// <inheritdoc />
        public string Name => "My Favourite Things";
    }

}
