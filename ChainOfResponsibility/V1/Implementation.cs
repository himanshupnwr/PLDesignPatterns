using System.ComponentModel.DataAnnotations;

namespace ChainOfResponsibility.V1
{
    public class Document
    {
        public string Title { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public bool ApprovedByLitigation { get; set; }
        public bool ApprovedByManagement { get; set; }

        public Document(string title, DateTimeOffset lastModified, bool approvedByLitigation, bool approvedByManagement)
        {
            Title = title;
            LastModified = lastModified;
            ApprovedByLitigation = approvedByLitigation;
            ApprovedByManagement = approvedByManagement;
        }

        public interface IHandler<T> where T : class
        {
            IHandler<T> SetSuccessor(IHandler<T> successor);
            void Handle(T request);
        }

        /// <summary>
        /// Concrete Handler
        /// </summary>
        public class DocumentTitleHandler : IHandler<Document>
        {
            private IHandler<Document> _successor;
            public void Handle(Document document)
            {
                if (document.Title == string.Empty)
                {
                    //validation doesn't check out
                    throw new ValidationException(new ValidationResult("Title must be present", new List<string>() { "Title" }), null, null);
                }

                //go to the next handler
                _successor.Handle(document);
            }

            public IHandler<Document> SetSuccessor(IHandler<Document> successor)
            {
                _successor = successor;
                return successor;
            }
        }

        public class DocumentLastModifiedHandler : IHandler<Document>
        {
            private IHandler<Document> _successor;
            public void Handle(Document document)
            {
                if (document.LastModified < DateTime.UtcNow.AddDays(-30))
                {
                    //validation does not checks out
                    throw new ValidationException(new ValidationResult("Document must be modified in the last 30 days", new List<string>() { "Last Modified" }), null, null);
                }

                //go to the next handler
                _successor.Handle(document);
            }

            public IHandler<Document> SetSuccessor(IHandler<Document> successor)
            {
                _successor = successor;
                return successor;
            }
        }

        public class DocumentApprovedByLitigationHandler : IHandler<Document>
        {
            private IHandler<Document> _successor;
            public void Handle(Document document)
            {
                if (!document.ApprovedByLitigation)
                {
                    //validation does not checks out
                    throw new ValidationException(new ValidationResult("Document must be approved by manager", new List<string>() { "Approved By Litigation" }), null, null);
                }

                //go to the next handler
                _successor.Handle(document);
            }

            public IHandler<Document> SetSuccessor(IHandler<Document> successor)
            {
                _successor = successor;
                return successor;
            }
        }

        public class DocumentApprovedByManagerHandler : IHandler<Document>
        {
            private IHandler<Document> _successor;
            public void Handle(Document document)
            {
                if (!document.ApprovedByManagement)
                {
                    //validation does not checks out
                    throw new ValidationException(new ValidationResult("Document must be approved by manager", new List<string>() { "Approved By Management" }), null, null);
                }

                //go to the next handler
                _successor.Handle(document);
            }

            public IHandler<Document> SetSuccessor(IHandler<Document> successor)
            {
                _successor = successor;
                return successor;
            }
        }
    }
}
