using Proxy.ProtectiveProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Tests.ProtectiveProxy
{
    public class EditorReviewDocument
    {
        [Fact]
        public void SetsDateReviewedToCurrentDateTime()
        {
            var editor = new User { Role = Roles.Editor };
            var document = Document.CreateDocument(TestConstants.TEST_DOCUMENT_NAME, TestConstants.TEST_DOCUMENT_CONTENT);

            document.CompleteReview(editor);

            Assert.True(DateTime.UtcNow - document.DateReviewed < TimeSpan.FromMilliseconds(500));
        }
    }
}
