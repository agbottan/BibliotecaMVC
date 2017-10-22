using Microsoft.AspNetCore.Mvc;

public class StatusCodeController : Controller
{
    // GET: /<controller>/

    [HttpGet("/StatusCode/{statusCode}")]

    public IActionResult Index(int statusCode)
    {
        return View(statusCode);
    }
}