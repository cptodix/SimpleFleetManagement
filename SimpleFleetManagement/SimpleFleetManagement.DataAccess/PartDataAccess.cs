using SimpleFleetManagement.DataModel;
using SimpleFleetManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFleetManagement.DataAccess
{
    public class PartDataAccess
    {
        public static string Message = string.Empty;
        public static List<PartViewModel> GetAll()
        {
            List<PartViewModel> result = new List<PartViewModel>();
            using (var db = new FleetManagementContext ())
            {
                result = (from pt in db.MstParts
                          select new PartViewModel
                          {
                              Id = pt.Id,
                              PartId = pt.PartId,
                              Description = pt.Description,
                              Price = pt.Price,
                              IsActive = pt.IsActive,
                              CreatedBy = pt.CreatedBy,
                              Created = pt.Created,
                              ModifiedBy = pt.ModifiedBy,
                              Modified = pt.Modified
                          }).ToList();
            }
            return result;
        }
        public static bool Update (PartViewModel model)
        {
            bool result = true;
            try
            {
                using (var db = new FleetManagementContext())
                {
                    if(model.Id==0)
                    {
                        MstPart part = new MstPart();                        
                        part.PartId = model.PartId;
                        part.Description = model.Description;
                        part.Price = model.Price;
                        part.IsActive = model.IsActive;
                        part.CreatedBy = model.CreatedBy;
                        part.Created = model.Created;
                        part.ModifiedBy = model.ModifiedBy;
                        part.Modified = model.Modified;
                        db.SaveChanges();                            
                    }
                    else
                    {
                        MstPart part = db.MstParts.Where(o => o.Id == model.Id).FirstOrDefault();
                        if (part != null)
                        {
                            part.PartId = model.PartId;
                            part.Description = model.Description;
                            part.Price = model.Price;
                            part.IsActive = model.IsActive;
                            part.CreatedBy = model.CreatedBy;
                            part.Created = model.Created;
                            part.ModifiedBy = model.ModifiedBy;
                            part.Modified = model.Modified;
                            db.MstParts.Add(part);
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

        public static PartViewModel GetById(int id)
        {
            PartViewModel result = new PartViewModel();
            using (var db = new FleetManagementContext())
            {
                result = (from pt in db.MstParts
                          select new PartViewModel
                          {
                              Id = pt.Id,
                              PartId = pt.PartId,
                              Description = pt.Description,
                              Price = pt.Price,
                              IsActive = pt.IsActive,
                              CreatedBy = pt.CreatedBy,
                              Created = pt.Created,
                              ModifiedBy = pt.ModifiedBy,
                              Modified = pt.Modified
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
                    MstPart part = db.MstParts.Where(o => o.Id == id).FirstOrDefault();
                    if(part != null)
                    {
                        db.MstParts.Remove(part);
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
