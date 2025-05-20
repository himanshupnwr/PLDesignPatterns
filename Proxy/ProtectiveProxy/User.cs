using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.ProtectiveProxy
{
    public class User
    {
        public string Name { get; set; }
        public Roles Role { get; set; }
        public List<Document> AuthoredDocuments { get; } = new List<Document>();

        public void AddDocument(string documentName, string documentContent)
        {
            var document = Document.CreateDocument(documentName, documentContent);
            AuthoredDocuments.Add(document);
        }
    }



    // Author can create a new document
    // Author can update the name of the document, modify its content, and assign initial tags
    // Author can submit document for review by an Editor
    // Editor can edit tags
    // Editor can mark the document reviewed (sets DateReviewed)
    // Editor cannot modify Name or Content directly
    // Maybe add Admin who can do anything (later)
}
