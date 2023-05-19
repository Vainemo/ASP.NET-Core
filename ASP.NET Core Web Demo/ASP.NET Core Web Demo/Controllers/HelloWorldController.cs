using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers;

public class HelloWorldController : Controller
{


    /* 控制器中的每个public方法都可以作为HTTP终结点调用: /HelloWorld/
     * HTTP终结点:Web应用程序中可定向的URL,例如:https://localhost:xxxx/Helloworld.
     * 1.https:所用的协议.
     * 2.localhost:xxxx:Web服务器的网络位置和TCP端口.
     * 3.Helloworld;目标URI.
     */
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Welcome( string name,int numTimes=1)
    {
        ViewData["Message"] = "Hello" + name;
        ViewData["NumTimes"] = numTimes;
        return View();
    }
}