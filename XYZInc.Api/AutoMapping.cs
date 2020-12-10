using AutoMapper;
using XYZInc.Api.Models;
using XYZInc.Domain.Transaction;

namespace XYZInc.Api
{
    /// <summary>
    /// Auto mapper for domain and api models
    /// </summary>
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<PaymentGateway, PaymentGatewayInfo>().ReverseMap();
            CreateMap<OrderStatus, OrderStatusInfo>().ReverseMap();
            CreateMap<Receipt, ReceiptModel>().ReverseMap(); 
            CreateMap<Order, CreateOrderRequest>().ReverseMap(); 
        }
    }
}
