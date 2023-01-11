using CropAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CropAPI.Repository;

namespace CropAPI.Repository
{
    public class UserRepository : IDataRepository<UserProfile>
    {
         CDProEntities _CropDealDbEntities;
        public UserRepository(CDProEntities cropDealDbEntities)
        {
            _CropDealDbEntities = cropDealDbEntities;
        }
        public void Add(UserProfile newUser)
        {
            _CropDealDbEntities.UserProfiles.Add(newUser);
            _CropDealDbEntities.SaveChanges();
        }


        public void Delete(int entity)
        {
            throw new NotImplementedException();
        }

        public UserProfile Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserProfile> GetAll()
        {
            _CropDealDbEntities.Configuration.ProxyCreationEnabled = false;
            return _CropDealDbEntities.UserProfiles.ToList();
        }

       

        public void Update(UserProfile dbEntity)
        {
            throw new NotImplementedException();
        }
    }
}
