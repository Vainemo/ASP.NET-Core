using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.NET_Core_Web_Demo.Data;
using ASP.NET_Core_Web_Demo.Models;

namespace ASP.NET_Core_Web_Demo.Controllers
{
    /// <summary>
    /// 构造函数使用依赖关系注入将 MvcMovieContext 数据库上下文注入到控制器中。 数据库上下文将在控制器中的每个 CRUD 方法中使用。
    /// </summary>
    public class MoviesController : Controller
    {
        private readonly ASPNET_Core_Web_DemoContext _context;
        //依赖注入，将数据库上下文 (MvcMovieContext) 注入到控制器中。 数据库上下文将在控制器中的每个 CRUD 方法中使用。
        public MoviesController(ASPNET_Core_Web_DemoContext context)
        {
            _context = context;
        }
        [HttpPost]
        public string Index(string scearchString, bool notUsed)
        {
            return "From [HttpPost]Index:Filter on" + scearchString;
        }
        // GET: Movies
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Movie==null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }
            //Linq语句,查询选择的电影

            //         1.LINQ 查询始终在循环访问查询变量时执行，而不是在创建查询变量时执行。 这称为“延迟执行”。
            //         2.在返回一系列值的查询中，查询变量本身从不保存查询结果，它只存储查询命令.
            //         3.在执行查询后，所有后续查询都将使用内存中的 LINQ 运算符。 通过使用 foreach 或 For Each 语句或者调用某个 LINQ 转换运算符来循环访问查询变量会使查询立即执行。
            //         这些转换运算符包括：ToList、ToArray、ToLookup 和 ToDictionary。
            //立即执行查询:与返回一系列值的延迟执行查询相反，返回单一实例值的查询将立即执行
            //          1.Average、Count、First 和 Max 是单一实例查询的一些示例。 这些查询立即执行，因为查询必须生成序列才能计算单一实例结果。
            //          2.若要强制立即执行不生成单一实例值的查询，可以对查询或查询变量调用 ToList、ToDictionary 或 ToArray 方法。
            //          3.通过在查询表达式之后紧随 foreach 或 For Each 循环，也可以强制执行，而通过调用 ToList 或 ToArray，可以缓存单个集合对象中的所有数据。
            var movies = from m in _context.Movie select m;
            if (!string.IsNullOrEmpty(searchString))
            {
                //Contains 方法在数据库上运行，而不是在上面显示的 C# 代码中运行
                movies = movies.Where(s => s.Title!.Contains(searchString));
            }
            return View(await movies.ToArrayAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Movie == null)
            {
                return Problem("Entity set 'ASPNET_Core_Web_DemoContext.Movie'  is null.");
            }
            var movie = await _context.Movie.FindAsync(id);
            if (movie != null)
            {
                _context.Movie.Remove(movie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
          return (_context.Movie?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
