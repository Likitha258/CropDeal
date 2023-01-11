using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CropsMVC.Models;
using CropsMVC.Repository;
using Newtonsoft.Json;

namespace CropsMVC.Controllers
{
    [RoutePrefix("api/User")]
    public class AdminController : Controller
    {
        public ActionResult Homepage()
        {
            return View();
        }
        public async Task<ActionResult> Admin(AdminViewModel adminViewModel)
        {


            try
            {
                if (ModelState.IsValid)
                {
                    AdminViewModel newUser = new AdminViewModel();
                    var service = new ServiceRepository();
                    {
                        using (var response = service.VerifyLogin("api/Admin/verifyLogin", adminViewModel))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            newUser = JsonConvert.DeserializeObject<AdminViewModel>(apiResponse);
                        }
                    }
                    if (newUser != null)
                    {
                        ViewBag.message = "Login Success";
                        return RedirectToAction("UserProfile");
                    }
                    else
                    {
                        ViewBag.message = "incorrect";



                    }
                }
            }
            catch
            {



            }




            return View("Admin");
        }
            [HttpGet]
            public async Task<ActionResult> UserProfiless()
        {
            List<UserProfileViewModel> UserProfile = new List<UserProfileViewModel>();
            var service = new ServiceRepository();
            {
                using (var response = service.GetResponse("api/Admin/UserProfile"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    UserProfile = JsonConvert.DeserializeObject<List<UserProfileViewModel>>(apiResponse);
                }
            }
            return View(UserProfile);
        }


        }
    }
