using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Linq.Expressions;
using VizeÇalışma.Models;
using VizeÇalışma.ViewModel;

namespace VizeÇalışma.Controllers
{
    public class CarController : Controller
    {
        private readonly AppDbContext _context;

        public CarController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public IActionResult Index()
        {
            var CarModel = _context.Cars.Select(x => new CarModel()
            {
                Id = x.Id,
                Model = x.Model,
                Marka = x.Marka,
                Description = x.Description,
                Price = x.Price,
                Status = x.Status

            }).ToList();
            return View(CarModel);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(CarModel carData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var car = new Car()
                    {
                        Marka = carData.Marka,
                        Model = carData.Model,
                        Description = carData.Description,
                        Price = carData.Price,
                        Status = carData.Status
                    };
                    _context.Cars.Add(car);
                    _context.SaveChanges();
                    TempData["succesMessage"] = "Araç Kaydedildi";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Yanlış veya Eksik Girdi.";
                    return View();
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return View();
            }

        }

        [HttpGet]

        public IActionResult Edit(int Id)
        {
            try
            {
                var car = _context.Cars.SingleOrDefault(x => x.Id == Id);

                if (car != null)

                {
                    var CarModel = new CarModel()
                    {
                        Id = car.Id,
                        Marka = car.Marka,
                        Model = car.Model,
                        Description = car.Description,
                        Price = car.Price,
                        Status = car.Status

                    };
                    return View(CarModel);

                }
                else
                {
                    TempData["errorMessage"] = $"Bu Id:{Id} Detaylara ulaşılamamaktadır.";
                    return RedirectToAction();
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");


            }
        }
        [HttpPost]
        public IActionResult Edit(CarModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var car = new Car()
                    {
                        Id = model.Id,
                        Marka = model.Marka,
                        Model = model.Model,
                        Description = model.Description,
                        Price = model.Price,
                        Status = model.Status
                    };
                    _context.Cars.Update(car);
                    _context.SaveChanges();
                    TempData["succesMessage"] = "Araç bilgileri güncellendi";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Araç bilgisi oluşamadı";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();

              
            }

        
        }
        [HttpGet]

        public IActionResult Delete(int Id)
        {
            
            {
                var car = _context.Cars.SingleOrDefault(x => x.Id == Id);

                if (car != null)

                {
                    var CarModel = new CarModel()
                    {
                        Id = car.Id,
                        Marka = car.Marka,
                        Model = car.Model,
                        Description = car.Description,
                        Price = car.Price,
                        Status = car.Status

                    };
                    return View(CarModel);

                }
                else
                {
                    TempData["errorMessage"] = $"Bu Id:{Id} Detaylara ulaşılamamaktadır.";
                    return RedirectToAction("Index");
                }
            }
            
        }
        [HttpPost]
        public IActionResult Delete(CarModel model) 
        {
           
            {
                var car = _context.Cars.SingleOrDefault(x => x.Id == model.Id);

                if (car != null)
                {
                    _context.Cars.Remove(car);
                    _context.SaveChanges();
                    TempData["succesMessage"] = "Araç Silindi";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = $"Bu Id:{model.Id} Detaylara ulaşılamamaktadır.";
                    return RedirectToAction("Index");
                }
            }
            
        }


    }
}
