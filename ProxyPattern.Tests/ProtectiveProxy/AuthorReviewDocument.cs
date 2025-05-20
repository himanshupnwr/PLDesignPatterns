using Proxy.ProtectiveProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Tests.ProtectiveProxy
{
    public class AuthorReviewDocument
    {
        [Fact]
        public void ThrowsUnauthorizedExceptionAndDoesNotSetDateReviewed()
        {
            var author = new User { Role = Roles.Author };
            var document = Document.CreateDocument(TestConstants.TEST_DOCUMENT_NAME, TestConstants.TEST_DOCUMENT_CONTENT);

            Assert.Throws<UnauthorizedAccessException>(() => document.CompleteReview(author));
            Assert.Null(document.DateReviewed);
        }
    }
}
