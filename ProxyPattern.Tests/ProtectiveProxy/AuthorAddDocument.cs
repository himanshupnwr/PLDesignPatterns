using Proxy.ProtectiveProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Tests.ProtectiveProxy
{
    public class AuthorAddDocument
    {
        [Fact]
        public void AddsDocumentToAuthoredDocuments()
        {
            var author = new User { Role = Roles.Author };

            author.AddDocument(TestConstants.TEST_DOCUMENT_NAME, TestConstants.TEST_DOCUMENT_CONTENT);

            Assert.Contains(author.AuthoredDocuments, doc => doc.Name == TestConstants.TEST_DOCUMENT_NAME);
        }
    }
}
