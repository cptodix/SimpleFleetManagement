using SimpleFleetManagement.DataModel;
using SimpleFleetManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFleetManagement.DataAccess
{
    public class ServiceDataAccess
    {
        public static string Message = string.Empty;
        public static List<ServiceViewModel> GetAll()
        {
            List<ServiceViewModel> result = new List<ServiceViewModel>();
            using (var db = new FleetManagementContext())
            {
                result = (from sr in db.MstServices
                          select new ServiceViewModel
                          {
                              Id = sr.Id,
                              ServiceId = sr.ServiceId,
                              Description = sr.Description,
                              IsActive = sr.IsActive,
                              CreatedBy = sr.CreatedBy,
                              Created = sr.Created,
                              ModifiedBy = sr.ModifiedBy,
                              Modified = sr.Modified,
                          }).ToList();
            }
            return result;
        }
        public static bool Update(ServiceViewModel model)
        {
            bool result = true;
            try
            {
                using (var db = new FleetManagementContext())
                {
                    if (model.Id == 0)
                    {
                        MstService service = new MstService();
                        service.ServiceId = model.ServiceId;
                        service.Description = model.Description;
                        service.IsActive = model.IsActive;
                        service.CreatedBy = model.CreatedBy;
                        service.Created = model.Created;
                        service.ModifiedBy = model.ModifiedBy;
                        service.Modified = model.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        MstService service = db.MstServices.Where(o => o.Id == model.Id).FirstOrDefault();
                        if (service != null)
                        {
                            service.ServiceId = model.ServiceId;
                            service.Description = model.Description;                            
                            service.IsActive = model.IsActive;
                            service.CreatedBy = model.CreatedBy;
                            service.Created = model.Created;
                            service.ModifiedBy = model.ModifiedBy;
                            service.Modified = model.Modified;
                            db.MstServices.Add(service);
                            db.SaveChanges();    
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                result = false;
            }
            return result;
        }

        public static ServiceViewModel GetById (int id)
        {
            ServiceViewModel result = new ServiceViewModel();
            using (var db = new FleetManagementContext())
            {
                result = (from sr in db.MstServices
                          where sr.Id == id
                          select new ServiceViewModel
                          {
                              Id = sr.Id,
                              ServiceId = sr.ServiceId,
                              Description = sr.Description,
                              IsActive = sr.IsActive,
                              CreatedBy = sr.CreatedBy,
                              Created = sr.Created,
                              ModifiedBy = sr.ModifiedBy,
                              Modified = sr.Modified,
                          }).FirstOrDefault();
            }
            return result;
        }

        public static bool Delete (int id)
        {
            bool result = true;
            try
            {
                using (var db = new FleetManagementContext())
                {
                    MstService service = db.MstServices.Where(o => o.Id == id).FirstOrDefault();
                    if (service != null)
                    {
                        db.MstServices.Remove(service);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                result = false;
            }
            return result;
        }
    }
}
