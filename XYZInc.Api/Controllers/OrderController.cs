using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using XYZInc.Api.Models;
using XYZInc.Domain.Transaction;

namespace XYZInc.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IProcessorFactory _processorFactory;
        private readonly IMapper _mapper;

        public OrderController(ILogger<OrderController> logger, IProcessorFactory processorFactory, IMapper mapper)
        {
            _logger = logger;
            _processorFactory = processorFactory;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody]CreateOrderRequest orderRequest)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(new
                {
                    Message = "request object can not be validated!"
                });
            }

            try
            {
                var order = _mapper.Map<Order>(orderRequest);

                var processor = _processorFactory.CreateProcessor(order.PaymentGateway);

                var receipt = processor.Process(order);

                return Ok(new CreateOrderResponse
                {
                    Receipt = _mapper.Map<ReceiptModel>(receipt)
                });
            }
            catch (Exception exception)
            {
                _logger.LogError("exception occured in Create", exception);

                return BadRequest(new CreateOrderResponse
                {
                    Receipt = new ReceiptModel()
                    {
                        CreationDate = DateTime.UtcNow,
                        OrderNumber = orderRequest.OrderNumber,
                        Status = OrderStatusInfo.Failed
                    }
                });
            }
        }
    }
}
