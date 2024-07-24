using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summariser
{
    public class Comment
    {
        public string Page { get; set; }
        public string Text { get; set; }

        public Comment(string page, string text)
        {
            Page = page;
            Text = text;
        }
    }
}
