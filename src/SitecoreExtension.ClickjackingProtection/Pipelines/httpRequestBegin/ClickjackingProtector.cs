namespace SitecoreExtension.ClickjackingProtection.Pipelines.httpRequestBegin
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Sitecore.Common;
    using Sitecore.Pipelines.HttpRequest;
    using Sitecore.StringExtensions;

    /// <summary>
    /// 
    /// </summary>
    public class ClickjackingProtector : HttpRequestProcessor
    {
        /// <summary>
        /// Gets the header values.
        /// </summary>
        /// <value>
        /// The header values.
        /// </value>
        public List<string> HeaderValues
        {
            get
            {
                return new List<string> { "DENY", "SAMEORIGIN", string.Empty };
            }
        }

        /// <summary>
        /// Gets the header key.
        /// </summary>
        /// <value>
        /// The header key.
        /// </value>
        public string HeaderKey
        {
            get
            {
                return "X-FRAME-OPTIONS";
            }
        }

        /// <summary>
        /// Processes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public override void Process(HttpRequestArgs args)
        {
            
            var defaultValue = Sitecore.Configuration.Settings.GetSetting("ClickjackingProtection.DefaultXFrameValue", string.Empty);

            var value = this.HeaderValues.First(v => v.Contains(defaultValue));

            if (value == string.Empty)
            {
                return;
            }

            // remove any already set headers; duplicate headers are a big no no.
            while (args.Context.Response.Headers.Get(this.HeaderKey) != null)
            {
                args.Context.Response.Headers.Remove(this.HeaderKey);
            }

            args.Context.Response.AddHeader(this.HeaderKey, value);
        }
    }
}
