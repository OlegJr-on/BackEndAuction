using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Web_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        private readonly IOrderService _orderService;
        public OrderController(IConfiguration configuration, IOrderService orderService)
        {
            _orderService = orderService;
            _configuration = configuration;
        }

        /// <summary>
        /// Get all orders for user by id
        /// </summary>
        /// <remarks>
        /// Sample request
        /// 
        ///     GET api/order/
        /// 
        /// </remarks>
        /// <returns> A list of existed orders</returns>
        [HttpGet("{id}")]
        public JsonResult GetAllUserOrdersById(int id)
        {

            string query = $@"SELECT  lots.id,lots.Title,lots.EndDate,lots.CurrentPrice,orders.OperationDate,orders.Id as OrderId, ph.PhotoSrc
                             FROM dbo.Orders as orders
                             JOIN dbo.OrderDetails AS od
                             ON od.OrderId = orders.id
                             JOIN dbo.Lots AS lots
                             ON lots.Id = od.LotId
                             JOIN dbo.Photos AS ph 
                             ON ph.id = lots.PhotoId
                             WHERE orders.UserId = {id}";

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
        /// Get All orders
        /// </summary>
        /// <remarks>
        /// Sample request
        /// 
        ///     GET api/order/get
        /// 
        /// </remarks>
        /// <returns> A list of existed orders</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Not found
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Bad Request
        [ProducesResponseType(StatusCodes.Status200OK)] // Ok
        public async Task<ActionResult<IEnumerable<OrderModel>>> Get()
        {
            IEnumerable<OrderModel> orders = null;
            try
            {
                orders = await _orderService.GetAllAsync();
                if (orders == null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }


            return Ok(orders);

        }


        /// <summary>
        /// Get order by id
        /// </summary>
        /// <remarks>
        /// Sample request
        /// 
        ///     GET api/order/GetById/id
        /// 
        /// </remarks>
        /// <returns> Order with the desired id </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Not found
        [ProducesResponseType(StatusCodes.Status200OK)] // Ok
        public async Task<ActionResult<OrderModel>> GetById(int id)
        {
            var model = await _orderService.GetByIdAsync(id);

            if (model == null)
                return NotFound();

            return Ok(model);
        }

        /// <summary>
        /// Get order details by order id
        /// </summary>
        /// <remarks>
        /// Sample request
        /// 
        ///     GET api/order/GetOrderDetailsById/id
        /// 
        /// </remarks>
        /// <returns> Order details with the desired id </returns>
        [HttpGet("{orderId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Not found
        [ProducesResponseType(StatusCodes.Status200OK)] // Ok
        public async Task<ActionResult<IEnumerable<OrderDetailModel>>> GetOrderDetailsById(int orderId)
        {
            var od = await _orderService.GetOrderDetailsAsync(orderId);

            if (od == null)
                return NotFound();

            //var OrderDetailResult = od.Select(x=>x.Name).

            return Ok(od);
        }


        /// <summary>
        /// Get orders by date period
        /// </summary>
        /// <remarks>
        /// Sample request
        /// 
        ///     GET api/order/GetOrdersByPeriod
        /// 
        /// </remarks>
        /// <returns> Get orders for the specified period </returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Not found
        [ProducesResponseType(StatusCodes.Status200OK)] // Ok
        public async Task<ActionResult<IEnumerable<OrderModel>>> GetOrdersByPeriod(DateTime startDate, DateTime endDate)
        {
            var orders = await _orderService.GetOrdersByPeriodAsync(startDate, endDate);

            if (orders == null)
                return NotFound();

            return Ok(orders);
        }

        /// <summary>
        /// Add order in db
        /// </summary>
        /// <remarks>
        /// Sample request
        /// 
        ///     POST api/order/add
        /// 
        /// </remarks>
        /// <returns> Added order to database </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Bad Request
        [ProducesResponseType(StatusCodes.Status200OK)] // Ok
        public async Task<ActionResult> Add([FromBody] OrderModel order)
        {
            try
            {
                await _orderService.AddAsync(order);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Add), new { id = order.Id }, order);
        }

        /// <summary>
        /// Add order detail in db
        /// </summary>
        /// <remarks>
        /// Sample request
        /// 
        ///     POST api/order/addLot
        /// 
        /// </remarks>
        /// <returns> Added order detail to database </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Bad Request
        [ProducesResponseType(StatusCodes.Status200OK)] // Ok
        public async Task<ActionResult> AddLot(int orderId,int lotId)
        {
            try
            {
                await _orderService.AddLotAsync(lotId,orderId);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }

        /// <summary>
        /// Update order
        /// </summary>
        /// <remarks>
        /// Sample request
        /// 
        ///     PUT api/order/update
        /// 
        /// </remarks>
        /// <returns> Updated order in database </returns>
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] OrderModel value)
        {
            try
            {
                await _orderService.UpdateAsync(value);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Update), new { id = value.Id }, value);
        }


        /// <summary>
        /// Delete order by id
        /// </summary>
        /// <remarks>
        /// Sample request
        /// 
        ///     DELETE api/order/delete/id
        /// 
        /// </remarks>
        /// <returns> Remoted order </returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Not found
        [ProducesResponseType(StatusCodes.Status200OK)] // Ok
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _orderService.DeleteAsync(id);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return CreatedAtAction(nameof(Delete), new { id = id });
        }

        /// <summary>
        /// Delete order details by Lot_Id and Order_Id
        /// </summary>
        /// <remarks>
        /// Sample request
        /// 
        ///     DELETE api/order/deletelot
        /// 
        /// </remarks>
        /// <returns> Removed OrderDetailsIds</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Not found
        [ProducesResponseType(StatusCodes.Status200OK)] // Ok
        public async Task<ActionResult> DeleteLot(int lotId, int orderId)
        {
            try
            {
                await _orderService.RemoveLotAsync(lotId,orderId);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
