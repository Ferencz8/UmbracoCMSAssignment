using StackExchange.Profiling.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Services;

namespace UmbracoHeartcoreHooks.WebHook_Handlers
{
    public class SendAMessageNotification : INotificationHandler<ContentPublishedNotification>
    {
        private const string HookSite = "HookSite";//TODO: move to service to remove duplicate code

        private IKeyValueService keyValueService;
        public SendAMessageNotification(IKeyValueService keyValueService)
        {
            this.keyValueService = keyValueService;
        }

        public void Handle(ContentPublishedNotification notification)
        {
            var hookSite = keyValueService.GetValue(HookSite);
            if(hookSite.HasValue())
            {
                foreach (var node in notification.PublishedEntities)
                {
                    using HttpClient client = new();
                    //client.GetAsync($"https://webhook.site/b1051074-7f08-4f34-b9bc-4610b174fda9?param1={productName}").Wait();
                    client.GetAsync($"{hookSite}?alias={node.ContentType.Alias}").Wait();
                    ////Use other config fields to decide what message content to send
                    //if (node.ContentType.Alias.Equals("product"))
                    //{
                    //    var productName = node.GetValue<string>("productName");
                    //    if (!string.IsNullOrWhiteSpace(productName))
                    //    {
                    //        using HttpClient client = new();
                    //        client.GetAsync($"https://webhook.site/b1051074-7f08-4f34-b9bc-4610b174fda9?param1={productName}").Wait();
                    //    }
                    //}
                }
            }            
        }
    }
}
