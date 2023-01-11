using CropAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CropAPI.Models;



namespace CropAPI.Controllers
{
    public class UserController : ApiController
    {
        IDataRepository<UserProfile> _dataRepository;
        public UserController()





        {
            this._dataRepository = new UserRepository(new CDProEntities());
        }
        [HttpGet]
        [Route("")]
        public IEnumerable<UserProfile> GetAllUsers()
        {
            var users = _dataRepository.GetAll();
            return users;
        }
    }
}