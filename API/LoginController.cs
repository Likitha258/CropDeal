using CropAPI.Models;
using CropAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;


namespace CropAPI.Controllers
{
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {

        private ILoginRepository _loginRepository;
        public LoginController()
        {
            this._loginRepository = new LoginRepository(new CDProEntities());
        }


        [HttpPost]
        public IHttpActionResult VerifyLogin(Models.Login objlogin)
        {
            UserProfile userProfile = null;

            try
            {
                userProfile = _loginRepository.VerifyLogin(objlogin.Email, objlogin.password);
               

                if (userProfile != null)
                {
                    //return NotFound();
                    return Ok(userProfile);

                }

            }
            catch (Exception ex)
            {

            }
            return NotFound();
        }



    }
}
