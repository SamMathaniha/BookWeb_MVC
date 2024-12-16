using BookWeb.Data;
using BookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db) 
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder)
            {
                ModelState.AddModelError("DisplayOrder", "The DisplayOrder can match the same Name");
            }


            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
             return View();
           
        }


        public IActionResult Edit(int? Id)
        {
            if(Id==null || Id == 0)
            {
                return NotFound();
            }
            Category? CategoryFromDB = _db.Categories.Find(Id);                                //Method 1
            Category? CategoryFromDB1 = _db.Categories.FirstOrDefault(u=>u.Id == Id);         //Method 2
            Category? CategoryFromDB2 = _db.Categories.Where(u=>u.Id== Id).FirstOrDefault();  //Method 3

            if (CategoryFromDB == null) 
            {
                return NotFound();
            }
            return View(CategoryFromDB);
        }
        
       

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder)
            {
                ModelState.AddModelError("DisplayOrder", "The DisplayOrder can match the same Name");
            }


            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}
