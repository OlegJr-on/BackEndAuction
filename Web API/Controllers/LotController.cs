using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API.Controllers
{
    [Route("api/lot/[action]")]
    [ApiController]
    public class LotController : ControllerBase
    {
        private readonly ILotService _lotService;
        private readonly IConfiguration _configuration;

        public LotController(IConfiguration configuration, ILotService lotService)
        {
            _lotService = lotService;
            _configuration = configuration;
        }

        /// <summary>
        /// Get all the lots with the title photo
        /// </summary>
        /// <remarks>
        /// Sample request
        /// 
        ///     GET api/lot/GetAllLotsWithPhoto
        /// 
        /// </remarks>
        /// <returns> A list of existed lot</returns>
        [HttpGet]
        public JsonResult GetAllLotsWithPhoto()
        {

            string query = @"SELECT  lots.id,lots.Title,lots.StartPrice,lots.StartDate,lots.EndDate, ph.PhotoSrc
                             FROM dbo.Lots AS lots
                             JOIN dbo.Photos AS ph 
                             ON ph.id = lots.PhotoId";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("AppCon");
            SqlDataReader myReader;
            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    myReader = command.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    connection.Close();
                }
            }
            return new JsonResult(table);
        }


        /// <summary>
        /// Get All Lot
        /// </summary>
        /// <remarks>
        /// Sample request
        /// 
        ///     GET api/lot/get
        /// 
        /// </remarks>
        /// <returns> A list of existed lot</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Not found
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Bad Request
        [ProducesResponseType(StatusCodes.Status200OK)] // Ok
        public async Task<ActionResult<IEnumerable<LotModel>>> Get()
        {
            IEnumerable<LotModel> lots = null;
            try
            {
                lots = await _lotService.GetAllAsync();
                if (lots == null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }


            return Ok(lots);

        }

        /// <summary>
        /// Get All photos
        /// </summary>
        /// <remarks>
        /// Sample request
        /// 
        ///     GET api/lot/GetPhotos
        /// 
        /// </remarks>
        /// <returns> A list of existed photos</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Not found
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Bad Request
        [ProducesResponseType(StatusCodes.Status200OK)] // Ok
        public async Task<ActionResult<IEnumerable<PhotoModel>>> GetPhotos()
        {
            IEnumerable<PhotoModel> photos = null;
            try
            {
                photos = await _lotService.GetAllPhotosAsync();
                if (photos == null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }


            return Ok(photos);

        }

        /// <summary>
        /// Get a photo according to the set group
        /// </summary>
        /// <remarks>
        /// Sample request
        /// 
        ///     GET api/lot/GetPhotoInGroup
        /// 
        /// </remarks>
        /// <returns> A list of lot photos</returns>
        [HttpGet("{lotId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Not found
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Bad Request
        [ProducesResponseType(StatusCodes.Status200OK)] // Ok
        public async Task<ActionResult<IEnumerable<PhotoModel>>> GetPhotoInGroup(int lotId)
        {
            IEnumerable<PhotoModel> photos = null;
            try
            {
                photos = await _lotService.GetPhotosGroupByIdAsync(lotId);
                if (photos == null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
            

            return Ok(photos);

        }

        /// <summary>
        /// Get lot by id
        /// </summary>
        /// <remarks>
        /// Sample request
        /// 
        ///     GET api/lot/GetById/id
        /// 
        /// </remarks>
        /// <returns> Lot with the desired id </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Not found
        [ProducesResponseType(StatusCodes.Status200OK)] // Ok
        public async Task<ActionResult<LotModel>> GetById(int id)
        {
            var model = await _lotService.GetByIdAsync(id);

            if (model == null)
                return NotFound();

            return Ok(model);
        }

        /// <summary>
        /// Get lot by filter
        /// </summary>
        /// <remarks>
        /// Sample request
        /// 
        ///     GET api/lot/GetByFilterAsync
        /// 
        /// </remarks>
        /// <returns> Lot with the specified criteria </returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Not found
        [ProducesResponseType(StatusCodes.Status200OK)] // Ok
        public async Task<ActionResult<IEnumerable<LotModel>>> GetByFilter(FilterSearchModel filter)
        {
            var lots = await _lotService.GetByFilterAsync(filter);

            if (!lots.Any())
            {
                return NotFound("Lots not found.");
            }

            return Ok(lots);
        }

        

        /// <summary>
        /// Add lot in db
        /// </summary>
        /// <remarks>
        /// Sample request
        /// 
        ///     POST api/lot/add
        /// 
        /// </remarks>
        /// <returns> Added lot to database </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Bad Request
        [ProducesResponseType(StatusCodes.Status200OK)] // Ok
        public async Task<ActionResult> Add([FromBody] LotModel lot)
        {
            try
            {
                await _lotService.AddAsync(lot);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Add), new { id = lot.Id }, lot);
        }

        /// <summary>
        /// Add photo in db
        /// </summary>
        /// <remarks>
        /// Sample request
        /// 
        ///     POST api/lot/AddPhoto
        /// 
        /// </remarks>
        /// <returns> Added photo to database </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Bad Request
        [ProducesResponseType(StatusCodes.Status200OK)] // Ok
        public async Task<ActionResult> AddPhoto([FromBody] PhotoModel lot)
        {
            try
            {
                await _lotService.AddPhotoAsync(lot);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Add), new { id = lot.Id }, lot);
        }

        /// <summary>
        /// Update lot
        /// </summary>
        /// <remarks>
        /// Sample request
        /// 
        ///     PUT api/lot/update
        /// 
        /// </remarks>
        /// <returns> Updated lot in database </returns>
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] LotModel value)
        {
            try
            {
                await _lotService.UpdateAsync(value);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Update), new { id = value.Id }, value);
        }
        
        /// <summary>
        /// Update photo
        /// </summary>
        /// <remarks>
        /// Sample request
        /// 
        ///     PUT api/lot/updatePhoto
        /// 
        /// </remarks>
        /// <returns> Updated photo in database </returns>
        [HttpPut]
        public async Task<ActionResult> UpdatePhoto([FromBody] PhotoModel value)
        {
            try
            {
                await _lotService.UpdatePhotoAsync(value);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Update), new { id = value.Id }, value);
        }

        /// <summary>
        /// Delete lot by id
        /// </summary>
        /// <remarks>
        /// Sample request
        /// 
        ///     DELETE api/lot/delete/id
        /// 
        /// </remarks>
        /// <returns> Remoted lot </returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Not found
        [ProducesResponseType(StatusCodes.Status200OK)] // Ok
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _lotService.DeleteAsync(id);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return CreatedAtAction(nameof(Delete), new { id = id });
        }
        
        /// <summary>
        /// Delete photo by id
        /// </summary>
        /// <remarks>
        /// Sample request
        /// 
        ///     DELETE api/lot/delete/id
        /// 
        /// </remarks>
        /// <returns> Remoted photo </returns>
        [HttpDelete("{photoId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Not found
        [ProducesResponseType(StatusCodes.Status200OK)] // Ok
        public async Task<ActionResult> DeletePhoto(int photoId)
        {
            try
            {
                await _lotService.RemovePhotoAsync(photoId);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Delete), new { id = photoId });
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var lots = await _lotService.GetAllAsync();
        //    var photos = await _lotService.GetAllPhotosAsync();

        //    var res = new WrapperLot
        //    {
        //        _lots = lots,
        //        _photos = photos
        //    };

        //    return View(res);
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var photos = await _lotService.GetPhotosGroupByIdAsync(id);

        //    var lot = await _lotService.GetByIdAsync(id);

        //    var wrapper = new WrapperLot
        //    {
        //        _lot = lot,
        //        _photos = photos
        //    };

        //    return View(wrapper);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Add(LotModel lot)
        //{
        //    lot.Status = DAL.Entities.LotStatus.Created;
        //    lot.PhotoId = 2;
        //    lot.CurrentPrice = 0;
        //    lot.StartDate = DateTime.Now;
        //    lot.EndDate = new DateTime(2022,7,11);


        //    if (lot != null)
        //    {
        //        await _lotService.AddAsync(lot);
        //        return View("Success",lot.Title);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        //public IActionResult RegLot()
        //{
        //    return View();
        //}

    }


    public class WrapperLot
    {
        public IEnumerable<LotModel> _lots;
        public LotModel _lot;
        public IEnumerable<PhotoModel> _photos;
    }
}
