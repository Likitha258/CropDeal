using CropsMVC.Models;
using CropsMVC.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CropsMVC.Controllers
{
    public class RegisterController : Controller
    {
        public ActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]

        public async Task<ActionResult> RegisterUser(RegisterViewModel userViewModel)
        {
          Random rnd = new Random();
            userViewModel.ID = rnd.Next();
            userViewModel.Status = "Active";
            if (ModelState.IsValid)
            {
                RegisterViewModel newUser = new RegisterViewModel();
                var service = new ServiceRepository();
                {
                    using (var response = service.PostResponse("https://localhost:44365/api/register", userViewModel))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        newUser = JsonConvert.DeserializeObject<RegisterViewModel>(apiResponse);
                    }
                }
                return RedirectToAction("Homepage", "Login");
            }
            return View(userViewModel);
        }
    }
}