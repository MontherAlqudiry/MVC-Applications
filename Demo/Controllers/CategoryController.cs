
using Demo.DataAccess.Data;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;


namespace Demo.Controllers
{
    public class CategoryController : Controller
    {
        

        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _HostEnvironment;
       
        public CategoryController(ApplicationDbContext db ,IWebHostEnvironment hc) {
            _db = db;
            _HostEnvironment = hc;
        }

        public IActionResult Index()
        {
            IList<Category> objCategoryList = _db.Categories.ToList();
            
            IList<Category> SortedCategoryList = objCategoryList.OrderBy(h => h.DisplayOrder).ToList();
             return View(SortedCategoryList);
           
        }

        public IActionResult Create() {

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create([Bind("ID", "Name", "DisplayOrder", "Disc", "ImageFile")] Category obj)
        {
            
            if (ModelState.IsValid) {

                string wwwRootPath = _HostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(obj.ImageFile.FileName);
                string extension = Path.GetExtension(obj.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                obj.ImageName = fileName;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using( var fileStream =new FileStream(path, FileMode.Create))
                { 
                    await obj.ImageFile.CopyToAsync(fileStream);
                }
               


                _db.Categories.Add(obj);
                await _db.SaveChangesAsync();
                TempData["Success"] = "Category created seccessfuly!";
                return RedirectToAction("Index");
            }
            return View();

        }



        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            Category CategoryFromDb = _db.Categories.Find(id);
            if(CategoryFromDb == null) {
                return NotFound();
            }


            return View(CategoryFromDb);
        }



        [HttpPost]
        public async Task<IActionResult> Edit([Bind("ID", "Name", "DisplayOrder", "Disc", "ImageFile")] Category obj)
        {
            
            if (ModelState.IsValid)
            {

                    string wwwRootPath = _HostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(obj.ImageFile.FileName);
                string extension = Path.GetExtension(obj.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await obj.ImageFile.CopyToAsync(fileStream);
                }



                Category newObj = new Category
                {
                    ID = obj.ID,
                    Name = obj.Name,
                    Disc = obj.Disc,
                    DisplayOrder = obj.DisplayOrder,
                    ImageName = fileName

                };

                _db.Categories.Update(newObj);
                _db.SaveChanges();
                TempData["Success"] = "Category updated seccessfuly!";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category CategoryFromDb = _db.Categories.Find(id);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }


            return View(CategoryFromDb);
        }



        [HttpPost,ActionName("Delete")]
        
        public IActionResult DeletePost(int? id)
        {
            Category obj =_db.Categories.Find(id);


            if (ModelState.IsValid)
            {
                var imagePath = Path.Combine(_HostEnvironment.WebRootPath, "Image", obj.ImageName);
                if(System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);

                }
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category deleted seccessfuly!";
                return RedirectToAction("Index");
            }
            return View();

        }

        


    }


   }


