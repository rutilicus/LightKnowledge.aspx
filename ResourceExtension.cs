using Markdig;
using Markdig.Renderers;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LightKnowledge.aspx
{
    public class ResourceExtension : IMarkdownExtension
    {
        public int id { get; set; }

        public void Setup(MarkdownPipelineBuilder pipeline)
        {
            pipeline.DocumentProcessed += ChangeResourcePath;
        }

        public void ChangeResourcePath(MarkdownDocument document)
        {
            foreach (LinkInline link in document.Descendants<LinkInline>())
            {
                if (link.IsImage)
                {
                    link.Url = $"/Resources/{id}/{link.Url}";
                }
            }
        }

        public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
        {
        }
    }
}