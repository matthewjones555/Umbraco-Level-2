using System.Linq;
using Umbraco.Core;
using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Publishing;
using Umbraco.Core.Services;

namespace Umbraco.Course.Level2.Events
{
    public class Level2ApplicationEventHandler : ApplicationEventHandler
    {
        protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication,ApplicationContext applicationContext)
        {
            ContentService.Saving += ContentService_Saving;
            ContentService.Publishing += ContentService_Publishing;
        }

        private void ContentService_Saving(IContentService sender, SaveEventArgs<IContent> e)
        {
            foreach (var content in e.SavedEntities)
            {
                if (content.ContentType.Alias == "statusUpdate")
                {
                    var bodyText = content.GetValue<string>("bodyText");

                    if (bodyText.Contains("ass"))
                    {
                        bodyText = bodyText.Replace("ass", "butt");
                        content.SetValue("bodyText", bodyText);
                    }

                    if (BAD_WORDS.Any(b => bodyText.ToLower().Contains(b)))
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }

        readonly string[] BAD_WORDS = new string[]
        {
            "fudge", "gosh", "darn", "heck", "ass", 
        };

        private void ContentService_Publishing(IPublishingStrategy sender, PublishEventArgs<IContent> e)
        {
            foreach (var content in e.PublishedEntities)
            {
                if (content.ContentType.Alias == "statusUpdate")
                {
                    var bodyText = content.GetValue<string>("bodyText").ToLower();

                    if (BAD_WORDS.Any(b => bodyText.Contains(b)))
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }
    }
}