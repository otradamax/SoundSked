using Microsoft.AspNetCore.Mvc;
using ServerApp.Models;

namespace ServerApp.Controllers;

[Route("/api/list")]
[ApiController]
public class ListController : Controller {

    private DataContext context;

    public ListController(DataContext ctx) {
        context = ctx;
    }

    [HttpGet("pictures")]
    public IEnumerable<byte[]> GetPictures(){
        return null;
    }
}