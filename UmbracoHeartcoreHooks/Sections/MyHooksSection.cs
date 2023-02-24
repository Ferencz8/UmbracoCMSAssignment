using Umbraco.Cms.Core.Sections;

namespace UmbracoHeartcoreHooks.Sections
{
    public class MyHooksSection : ISection
    {
        /// <inheritdoc />
        public string Alias => "myHooks";

        /// <inheritdoc />
        public string Name => "My Hooks";
    }

}
