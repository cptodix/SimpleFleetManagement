using SimpleFleetManagement.DataModel;
using SimpleFleetManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFleetManagement.DataAccess
{
    public class OrderDataAccess
    {
        public static string Message = string.Empty;
        public static List<OrderViewModel> GetAll()
        {
            List<OrderViewModel> result = new List<OrderViewModel>();
            using (var db = new FleetManagementContext())
            {
                result = (from od in db.TrxOrders
                          join ctm in db.MstCustomers
                          on od.CustomerId equals ctm.CustomerId
                          select new OrderViewModel
                          {
                              Id = od.Id,
                              OrderId = od.OrderId,
                              CustomerId = od.CustomerId,
                              CustomerName = ctm.CustomerName,
                              OrderName = od.OrderName,
                              OrderDate = od.OrderDate,
                              Destination = od.Destination,
                              StartDate = od.StartDate,
                              EndDate = od.EndDate,
                              TotalPerson = od.TotalPerson,
                              OrderStatus = od.OrderStatus
                          }).ToList();
            }
            return result;
        }
    }
}
