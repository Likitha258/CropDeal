using CropAPI.Models;
using CropAPI.Repository;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CropAPI.Controllers
{
    [RoutePrefix("api/CropDetails")]
    public class CropDetailsController : ApiController
    {
        IDataRepository<CROP> _dataRepository;
        public CropDetailsController()
        {
            this._dataRepository = new CropDetailsRepository(new CDProEntities());
        }
        [HttpGet]
        [Route("")]
        public IEnumerable<CROP> GetAllCROP()
        {
            var crops = _dataRepository.GetAll();

            return crops;
        }

        [HttpDelete]
        [Route("{id}")]

        public IHttpActionResult DeleteCrop(int id )
        {
            try
            {
                CROP crop = _dataRepository.Get(id);
                if (crop == null)
                {
                    return NotFound();
                }
                _dataRepository.Delete(id);
                return Ok(crop);
                //int abcd = crop.User_ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            //return Ok("Crop Details are deleted ..!");
            //return Ok(crops);
        }
        [HttpPost]
        //[Route("PostCrop")]
        [Route("")]
        public IHttpActionResult Post([FromBody] CROP crop)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _dataRepository.Add(crop);


            }

            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(crop);
        }
        [HttpPut]
        [Route("{id}")]

        public IHttpActionResult UpdateCrop(int id, [FromBody] CROP Cropid)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Cropid == null)
            {
                return BadRequest("Crop is Not found");
            }
            if (id != Cropid.ID)
            {
                return BadRequest();
            }
            _dataRepository.Update(Cropid);
            // _dataRepository.SaveChanges();

            return Ok(Cropid);
        }

        [HttpGet]
        [Route("{id}")]

        public IHttpActionResult GetCrop(int id)
        {
            CROP cropObj = null;
            try
            {
                cropObj = _dataRepository.Get(id);
                if (cropObj == null)
                {
                    return NotFound();
                }

            }
            catch (Exception ex) { throw ex; }
            return Ok(cropObj);
        }
    }
}

