using BulkyRockWeb.Data;
using BulkyRockWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyRockWeb.Controllers
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
            //var objCateogryList = _db.cateogries.ToList();
            IEnumerable<Cateogry> objCateogryList = _db.cateogries;
            return View(objCateogryList);
        }
        //Get
        public IActionResult Create()
        {
            //var objCateogryList = _db.cateogries.ToList();
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cateogry obj)
        {
            
            if (ModelState.IsValid)
            {
                if (obj.Name == obj.DisplayOrder.ToString())
                {
                    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
                }
                else
                {

                    _db.cateogries.Add(obj);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(obj);
        }
        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryObjFirst = _db.cateogries.FirstOrDefault(c => c.Id == id);
            if (categoryObjFirst == null)
            {
                return NotFound();
            }
            //var categoryObjSingle = _db.cateogries.SingleOrDefault(c => c.Id == id);
            //var categoryObj = _db.cateogries.Find(id);
            return View(categoryObjFirst);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cateogry obj)
        {

            
            return View(obj);
        }
    }
}
