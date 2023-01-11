using CropAPI.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace CropAPI.Repository
{
    public class CropDetailsRepository : IDataRepository<CROP>

    {
        CDProEntities _cropDealDbEntities;
        public CropDetailsRepository(CDProEntities cropDealDbEntities)
        {
            this._cropDealDbEntities = cropDealDbEntities;
        }
        public void Add(CROP Crop)
        {
           _cropDealDbEntities.CROPs.Add(Crop);
            _cropDealDbEntities.SaveChanges();

        }

        public void Delete(int User_ID)
        {
            CROP crop = _cropDealDbEntities.CROPs.Find(User_ID);
            _cropDealDbEntities.CROPs.Remove(crop);
            _cropDealDbEntities.SaveChanges();
        }

        public CROP Get(int id)
        {
            var crops =  _cropDealDbEntities.CROPs.Find(id);
            return crops;
        }

        public IEnumerable<CROP> GetAll()
        {
            _cropDealDbEntities.Configuration.ProxyCreationEnabled = false;
            return _cropDealDbEntities.CROPs.ToList();

        }

       
        
        public void Update(CROP CropNo)
        {
            _cropDealDbEntities.Entry(CropNo).State = System.Data.Entity.EntityState.Modified;
            _cropDealDbEntities.SaveChanges();
        }
    }
}