using Microsoft.AspNetCore.Mvc;
using simple_chat_csharp;
using System.Linq;

public class HomeController : Controller
{
    private readonly SimpleChatContext _context;

    public HomeController(SimpleChatContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Chat()
    {
        var messages = _context.Messages.OrderBy(m => m.Timestamp).ToList();
        return View(messages);
    }
}