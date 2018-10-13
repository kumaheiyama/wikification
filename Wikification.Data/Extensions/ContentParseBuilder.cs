using System;
using System.Collections.Generic;
using System.Text;

namespace Wikification.Data.Extensions
{
    internal class ContentParseBuilder
    {
        private string _parsedContents;

        private ContentParseBuilder()
        {
            _parsedContents = string.Empty;
        }
        public static ContentParseBuilder Begin()
        {
            return new ContentParseBuilder();
        }
        public ContentParseBuilder SetUnparsedContent(string content)
        {
            _parsedContents = content;

            return this;
        }
        public ContentParseBuilder ParseList()
        {
            _parsedContents = _parsedContents;

            return this;
        }
        public ContentParseBuilder ParseLinks()
        {
            _parsedContents = _parsedContents;

            return this;
        }
        public ContentParseBuilder ParseImageUrls()
        {
            _parsedContents = _parsedContents;

            return this;
        }

        public string Build()
        {
            return _parsedContents;
        }
    }
}
