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
    public class CropDetailsController : Controller
    {

        public async Task<ActionResult> Crop()
        {
            
            List<CropViewModel> crops = new List<CropViewModel>();
            List<CropViewModel> cropList_by_UserID = new List<CropViewModel>();

            var service = new ServiceRepository();
            {
                using (var response = service.GetResponse("CropDetails"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    crops = JsonConvert.DeserializeObject<List<CropViewModel>>(apiResponse);

                 if((int)TempData["UserID"] != null) { 
                    int UserId = (int)TempData["UserID"];

                     cropList_by_UserID = crops.Where(s => s.User_ID == UserId).ToList();

                    }

                }
            }
            return View(cropList_by_UserID);
        }
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<ActionResult> Create(CropViewModel crop)
        {
  Random rnd = new Random();
            crop.ID = rnd.Next();

            if (ModelState.IsValid)
            {
                CropViewModel newCrop = new CropViewModel();
                var service = new ServiceRepository();
                {
                    using (var response = service.PostResponse("CropDetails", crop))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        newCrop = JsonConvert.DeserializeObject<CropViewModel>(apiResponse);
                        TempData["UserID"] = newCrop.User_ID;

                    }
                }

                return RedirectToAction("Crop");
            }
            return View(crop);
        }
        public async Task<ActionResult> Delete(int Id)
        {
            CropViewModel Crop = new CropViewModel();
            var service = new ServiceRepository();
            {
                using (var response = service.DeleteResponse("CropDetails" + "/" + Id))

                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //string apiResponse = await response.Content.ReadAsStringAsync();
                    Crop = JsonConvert.DeserializeObject<CropViewModel>(apiResponse);
                    TempData["UserID"] = Crop.User_ID;
                }

            }
            return RedirectToAction("Crop");
        }
        public async Task<ActionResult> Edit(int id)
        {
            CropViewModel crop = new CropViewModel();
            var service = new ServiceRepository();
            {
                using (var response = service.GetResponse("CropDetails" + "/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    crop = JsonConvert.DeserializeObject<CropViewModel>(apiResponse);
                }
                TempData["UserID"] = crop.User_ID;

            }
            return View(crop);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(CropViewModel crop)
        {
            CropViewModel Crops = new CropViewModel();
            var service = new ServiceRepository();
            {
                using (var response = service.PutResponse("CropDetails" + "/" + crop.ID, crop))

                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Crops = JsonConvert.DeserializeObject<CropViewModel>(apiResponse);
                }
            }
            return RedirectToAction("crop");
        }




    }
}