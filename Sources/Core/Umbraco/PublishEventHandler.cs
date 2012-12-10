namespace VSS.Milan.Web.Core.Umbraco
{
    using umbraco.cms.businesslogic.web;
    using umbraco.interfaces;

    public class PublishEventHandler : IApplicationStartupHandler
    {
        public PublishEventHandler()
        {
            Document.AfterPublish += DocumentAfterPublish;
        }

        private static void DocumentAfterPublish(Document sender, umbraco.cms.businesslogic.PublishEventArgs e)
        {
            // Log.Add(LogTypes.Publish, sender.Id, DocumentAfterPublish");
        }
    }
}