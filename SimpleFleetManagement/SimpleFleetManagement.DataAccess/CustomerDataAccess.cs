using SimpleFleetManagement.DataModel;
using SimpleFleetManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFleetManagement.DataAccess
{
    public class CustomerDataAccess
    {
        public static string Message = string.Empty;
        public static List<CustomerViewModel> GetAll()
        {
            List<CustomerViewModel> result = new List<CustomerViewModel>();
            using (var db = new FleetManagementContext())
            {
                result = (from ctm in db.MstCustomers
                          select new CustomerViewModel
                          {
                              Id = ctm.Id,
                              CustomerId = ctm.CustomerId,
                              CustomerName = ctm.CustomerName,
                              OrganizationName = ctm.OrganizationName,
                              CustomerAddress = ctm.CustomerAddress,
                              OrganizationAddress = ctm.OrganizationAddress,
                              IdNumber = ctm.IdNumber,
                              CustomerPhone = ctm.CustomerPhone,
                              OrganizationPhone = ctm.OrganizationPhone,
                              OrganizationEmail = ctm.OrganizationEmail,
                              IsActive = ctm.IsActive
                          }).ToList();
            }
            return result;
        }

        public static CustomerViewModel GetByCustomerId(string customerid)
        {
            CustomerViewModel result = new CustomerViewModel();
            using (var db = new FleetManagementContext())
            {
                result = (from ctm in db.MstCustomers
                          where ctm.CustomerId == customerid
                          select new CustomerViewModel
                          {
                              Id = ctm.Id,
                              CustomerId = ctm.CustomerId,
                              CustomerName = ctm.CustomerName,
                              OrganizationName = ctm.OrganizationName,
                              CustomerAddress = ctm.CustomerAddress,
                              OrganizationAddress = ctm.OrganizationAddress,
                              IdNumber = ctm.IdNumber,
                              CustomerPhone = ctm.CustomerPhone,
                              OrganizationPhone = ctm.OrganizationPhone,
                              OrganizationEmail = ctm.OrganizationEmail,
                              IsActive = ctm.IsActive
                          }).FirstOrDefault();
            }
            return result;
        }

        public static List<CustomerViewModel> GetByFilter(string filterstring)
        {
            List<CustomerViewModel> result = new List<CustomerViewModel>();
            using (var db = new FleetManagementContext())
            {
                result = (from ctm in db.MstCustomers
                          select new CustomerViewModel
                          {
                              Id = ctm.Id,
                              CustomerId = ctm.CustomerId,
                              CustomerName = ctm.CustomerName,
                              OrganizationName = ctm.OrganizationName,
                              CustomerAddress = ctm.CustomerAddress,
                              OrganizationAddress = ctm.OrganizationAddress,
                              IdNumber = ctm.IdNumber,
                              CustomerPhone = ctm.CustomerPhone,
                              OrganizationPhone = ctm.OrganizationPhone,
                              OrganizationEmail = ctm.OrganizationEmail,
                              IsActive = ctm.IsActive
                          }).ToList();
                result = result.Where(o => o.CustomerId.ToLower().Contains(filterstring.ToLower()) ||
                    o.CustomerName.ToLower().Contains(filterstring.ToLower()) ||
                    o.OrganizationName.ToLower().Contains(filterstring.ToLower())).ToList();
            }
            return result;
        }

        public static CustomerViewModel GetById(int id)
        {
            CustomerViewModel result = new CustomerViewModel();
            using (var db = new FleetManagementContext())
            {
                result = (from ctm in db.MstCustomers
                          where ctm.Id == id
                          select new CustomerViewModel
                          {
                              Id = ctm.Id,
                              CustomerId = ctm.CustomerId,
                              CustomerName = ctm.CustomerName,
                              OrganizationName = ctm.OrganizationName,
                              CustomerAddress = ctm.CustomerAddress,
                              OrganizationAddress = ctm.OrganizationAddress,
                              IdNumber = ctm.IdNumber,
                              CustomerPhone = ctm.CustomerPhone,
                              OrganizationPhone = ctm.OrganizationPhone,
                              OrganizationEmail = ctm.OrganizationEmail,
                              IsActive = ctm.IsActive
                          }).FirstOrDefault();
            }
            return result;
        }

        public static bool Update(CustomerViewModel model)
        {
            bool result = true;

            try
            {
                using (var db = new FleetManagementContext())
                {
                    if (model.Id == 0)
                    {
                        MstCustomer ctm = new MstCustomer();
                        ctm.CustomerId = model.CustomerId;
                        ctm.CustomerName = model.CustomerName;
                        ctm.OrganizationName = model.OrganizationName;
                        ctm.CustomerAddress = model.CustomerAddress;
                        ctm.OrganizationAddress = model.OrganizationAddress;
                        ctm.IdNumber = model.IdNumber;
                        ctm.CustomerPhone = model.CustomerPhone;
                        ctm.OrganizationPhone = model.OrganizationPhone;
                        ctm.OrganizationEmail = model.OrganizationEmail;
                        ctm.IsActive = model.IsActive;
                        db.MstCustomers.Add(ctm);
                        db.SaveChanges();
                    }
                    else
                    {
                        MstCustomer ctm = db.MstCustomers.Where(o => o.Id == model.Id).FirstOrDefault();
                        if (ctm != null)
                        {
                            ctm.CustomerId = model.CustomerId;
                            ctm.CustomerName = model.CustomerName;
                            ctm.OrganizationName = model.OrganizationName;
                            ctm.CustomerAddress = model.CustomerAddress;
                            ctm.OrganizationAddress = model.OrganizationAddress;
                            ctm.IdNumber = model.IdNumber;
                            ctm.CustomerPhone = model.CustomerPhone;
                            ctm.OrganizationPhone = model.OrganizationPhone;
                            ctm.OrganizationEmail = model.OrganizationEmail;
                            ctm.IsActive = model.IsActive;
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                Message = Ex.Message;
                result = false;
            }

            return result;
        }

        public static bool Delete(int id)
        {
            bool result = true;
            try
            {
                using (var db = new FleetManagementContext())
                {
                    MstCustomer ctm = db.MstCustomers.Where(o => o.Id == id).FirstOrDefault();
                    if (ctm != null)
                    {
                        db.MstCustomers.Remove(ctm);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception Ex)
            {
                Message = Ex.Message;
                result = false;
            }
            return result;
        }
    }
}
