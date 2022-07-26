//using BLL.Interfaces;
//using BLL.Models;
//using Microsoft.AspNetCore.Mvc;
//using System.Linq;
//using Web_API.Models;

//namespace Web_API.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly IUserService _userService;
//        public HomeController(IUserService userService)
//        {
//            _userService = userService;
//        }

//        public IActionResult HomePage()
//        {
//            return View();
//        }

//        public IActionResult About()
//        {
//            return View();
//        }

//        [HttpGet]
//        public IActionResult SignIn()
//        {
//            return View();
//        }
        
//        [HttpPost]
//        public IActionResult SignIn(Models.UserRegistrationModel model)
//        {
//            if (string.IsNullOrEmpty(model.Email) && string.IsNullOrEmpty(model.Password))
//            {
//                return NotFound();
//            }
//            else
//            {
//                var users = _userService.GetAllAsync().Result;

//                var signIn = users.Where(x=>x.Email == model.Email && x.Password == model.Password).FirstOrDefault(); 

//                if (signIn != null)
//                {
//                    model.Name = signIn.Name;
//                    return View("SuccessfulMessage", model);
//                }
//                else
//                {
//                    return View("NotFound");
//                }
//            }
//        }


//        [HttpGet]
//        public IActionResult RegistrationUser()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult RegistrationUser(Models.UserRegistrationModel userModel)
//        {
//            if (ModelState.IsValid) {
//                if (userModel != null /*&& userModel.IsAgree == true*/)
//                {
//                    var newUser = new BLL.Models.UserModel
//                    {
//                        Name = userModel.Name,
//                        Surname = userModel.Surname,
//                        Location = userModel.Location,
//                        PhoneNumber = userModel.PhoneNumber,
//                        Email = userModel.Email,
//                        Password = userModel.Password,
//                        AccessLevel = DAL.Entities.Role.RegUser

//                    };

//                    _userService.AddAsync(newUser);
//                    return View("SuccessfulMessage", userModel);
//                }
//                else
//                {
//                    return View("NotFound");
//                }
//            }
//            else
//            {
//                return View(userModel);
//            }
//        }
//    }
//}
