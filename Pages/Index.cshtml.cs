using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace simple_chat_csharp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly SimpleChatContext _context;

        public IndexModel(SimpleChatContext context)
        {
            _context = context;
        }

        public List<Message> Messages { get; set; }

        public void OnGet()
        {
            Messages = _context.Messages.OrderBy(m => m.Timestamp).ToList();
        }
    }
}