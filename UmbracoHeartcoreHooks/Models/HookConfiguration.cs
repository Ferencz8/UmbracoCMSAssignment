using System.ComponentModel.DataAnnotations;

namespace UmbracoHeartcoreHooks.Models
{
    public class HookConfiguration
    {
        [Required(ErrorMessage = "Site is a required value.")]
        public string Site { get; set; }
    }
}
