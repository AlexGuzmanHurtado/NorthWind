using NorthWind.Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.Interface
{
	public interface IOrderDetailRepository
	{
		void Create(OrderDetail orderDetail);
	}
}
