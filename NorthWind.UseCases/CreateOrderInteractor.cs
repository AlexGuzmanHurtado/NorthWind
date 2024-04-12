using MediatR;
using NorthWind.Entities.Exceptions;
using NorthWind.Entities.Interface;
using NorthWind.Entities.POCOEntities;
using NorthWind.UseCases.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.UseCases
{
	public class CreateOrderInteractor : IRequestHandler<CreateOrderInputPort, int>
	{
		readonly IOrderRepository OrderRepository;
		readonly IOrderDetailRepository OrderDetailRepository;
		readonly IUnitOfWork UnitOfWork;

		public CreateOrderInteractor(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IUnitOfWork unitOfWork)
	    => (OrderRepository, orderDetailRepository, UnitOfWork) =
			(orderRepository, orderDetailRepository, unitOfWork);

		public async Task<int> Handle(CreateOrderInputPort request, CancellationToken cancellationToken)
		{
			Order order = new Order
			{
				CustomerId = request.CustomerId,
				OrderDate = DateTime.Now,
				ShipAdress = request.ShipAddress,
				ShipCity = request.ShipCity,
				ShipCountry = request.ShipCountry,
				ShipPostalCode = request.ShipPostalCode,
				ShippingType = Entities.Enums.ShippingType.Road,
				DiscountType = Entities.Enums.DiscountType.Percentage,
				Discount = 10
			};
			OrderRepository.create(order);
			foreach (var Item in request.OrderDetails)
			{
				OrderDetailRepository.Create(
					new OrderDetail
					{
						order = order,
						ProductId = Item.ProductId,
						UnitPrice = Item.UnitPrice,
						Quantity = Item.Quantity,
					});
			}
			try
			{
				await UnitOfWork.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw new GeneralExceptions("Error al crear la orden.",
					ex.Message);
			}
			return Order.id;
			}
		
	}
}
