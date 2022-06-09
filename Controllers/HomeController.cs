using Microsoft.AspNetCore.Mvc;
using StaffManagement_.Net_5.Models;
using StaffManagement_.Net_5.ViewModels;

namespace StaffManagement_.Net_5.Controllers
{
    //[Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IStaffRepository _staffRepository;
        public HomeController(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }
        public JsonResult Data()
        {
            return Json(new { id = 17, name = "Elbek", firstname = "Abdurahimov", Age = 24 });
        }
        /* Controllerdan Viewga ma'lumot uzatishning 3 ta usuli  bor . 
            1. ViewData
            2. ViewBag
            3. Strongly Typed
        */
        public ViewResult Details()
        {
            Staff model = _staffRepository.Get(1);
            //-----1-------//
            ViewData["staff"] = model;
            ViewData["title"] = "StafManagement details";
            //-----2------//
            ViewBag.staff = model;
            ViewBag.title = "Dotnet watch run!";
            return View();
        }
        //---------3--------//
        //[Route("[action]/{id?}")]
        public ViewResult Details1(int? id)
        {
            HomeDetails1ViewModel viewModel = new HomeDetails1ViewModel()
            {
                Staff = _staffRepository.Get(id ?? 3),
                Title = "Hello World!!!!!"
            };
            return View(viewModel);
        }
        //[Route("")]
        //[Route("/")]
        //[Route("[action]/{id?}")]
        public ViewResult Index1()
        {
            HomeIndex1ViewModel viewModel = new HomeIndex1ViewModel()
            {
                Staffs = _staffRepository.GetAll()
            };
            return View(viewModel);
        }
        public ViewResult ViewOne()
        {
            return View("View1");
        }
        //public ViewResult ViewTwo()
        //{
        //    return View("../Other/View2");
        //}
        public ViewResult ViewThree()
        {
            return View("~/Top/View3.cshtml");
        }
        //public string Staff(int id)
        //{
        //    return _staffRepository.Get(id)?.Department;
        //}
    }
}
