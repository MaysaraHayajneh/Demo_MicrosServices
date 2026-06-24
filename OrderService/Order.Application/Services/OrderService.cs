using Mapster;
using Order.Application.Contracts.Clients;
using Order.Application.Contracts.Markers;
using Order.Application.Contracts.Messaging;
using Order.Application.Contracts.Persistence;
using Order.Application.Contracts.Services;
using Order.Application.DTOs.Orders;
using Order.Domain.Entities;
using SharedContracts.Messages;

namespace Order.Application.Services
{
	public class OrderService : IOrderService, IScope
	{
		private readonly IGenericRepository<OrderEntity> orderRepos;
		private readonly IUnitOfWork unitOfWork;
		private readonly ICustomerServiceClient customerServiceClient;
		private readonly IProductServiceClient productServiceClient;
        private readonly IEventPublisher _eventPublisher;

        public OrderService(IGenericRepository<OrderEntity> productRepos,
			IUnitOfWork unitOfWork, ICustomerServiceClient customerServiceClient
			, IProductServiceClient productServiceClient, IEventPublisher eventPublisher)
		{
			this.orderRepos = productRepos;
			this.unitOfWork = unitOfWork;
			this.customerServiceClient = customerServiceClient;
			this.productServiceClient = productServiceClient;
            _eventPublisher = eventPublisher;
        }
		public async Task Create(CreateOrderDTO dto)
		{
			ArgumentNullException.ThrowIfNull(dto);
			if (dto.CustomerId <= 0) throw new InvalidOperationException("Not Authorized");

			var customer = await customerServiceClient.GetCustomerAsync(dto.CustomerId)
				?? throw new InvalidOperationException("Not Authorized");

			var productTasks = dto.OrderItems
				.Select(x => productServiceClient.GetProduct(x.ProductId));

			var products = await Task.WhenAll(productTasks);


			if (products.Any(p => p is null))
				throw new InvalidOperationException("One or more products not found");

			var order = new OrderEntity(dto.CustomerId);

			foreach (var item in dto.OrderItems)
			{
				var product = products.First(p => p.Id == item.ProductId);

				order.AddItem(
					product.Id,
					product.Name,
					product.Price,
					item.Quantity
				);
			}
			await orderRepos.Create(order);

            await _eventPublisher.PublishOrderCreated(new OrderCreatedEvent(dto.OrderItems.Select(oi => new ProductDetails { ProductId = oi.ProductId, Quantity = oi.Quantity }	).ToList()));
        
            await unitOfWork.CommitAsync();

        }
		public async Task Delete(int Id)
		{
			var product = await orderRepos.GetById(Id);
			ArgumentNullException.ThrowIfNull(product);
			orderRepos.Delete(product);
			await unitOfWork.CommitAsync();

		}

		public async Task<IReadOnlyList<GetAllOrderDTO>> GetAll()
		{
			var products = await orderRepos.GetAll();
			return products.Adapt<IReadOnlyList<GetAllOrderDTO>>();
		}

		public async Task<GetOrderDTO> GetById(int id)
		{
			var product = await orderRepos.GetById(id);
			ArgumentNullException.ThrowIfNull(product);
			return product.Adapt<GetOrderDTO>();
		}

		public async Task Update(UpdateOrderDTO dto)
		{
			var product = await orderRepos.GetById(dto.Id, false);

			product.Adapt<UpdateOrderDTO>();

			await unitOfWork.CommitAsync();

		}
	}
}
