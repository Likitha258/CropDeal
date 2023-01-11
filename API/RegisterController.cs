using CropAPI.Models;
using CropAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace CropAPI.Controllers
{
    public class RegisterController : ApiController
    {
        private IDataRepository<UserProfile> _dataRepository;

        public RegisterController()
        {
            this._dataRepository = new UserRepository(new CDProEntities());
        }
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateUser([FromBody] UserProfile userObj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _dataRepository.Add(userObj);
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(userObj);
        }
    }
}