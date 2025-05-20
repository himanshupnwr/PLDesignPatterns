using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.ProtectiveProxy
{
    public class ProtectedDocument : Document
    {
        public ProtectedDocument(string name, string content) : base(name, content)
        {
        }

        public override void UpdateName(string newName, User user)
        {
            if (user.Role != Roles.Author)
            {
                throw new UnauthorizedAccessException("Cannot update name unless in Author role.");
            }
            base.UpdateName(newName, user);
        }

        public override void CompleteReview(User editor)
        {
            if (editor.Role != Roles.Editor)
            {
                throw new UnauthorizedAccessException("Cannot review documents unless you are an Editor.");
            }
            base.CompleteReview(editor);
        }
    }
}
