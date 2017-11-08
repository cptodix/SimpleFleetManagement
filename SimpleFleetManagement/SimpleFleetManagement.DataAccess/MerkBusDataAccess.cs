using SimpleFleetManagement.DataModel;
using SimpleFleetManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFleetManagement.DataAccess
{
    public class MerkBusDataAccess
    {
        public static string Message = string.Empty;
        public static List<MerkBusViewModel> GetAll()
        {
            List<MerkBusViewModel> result = new List<MerkBusViewModel>();
            using (var db = new FleetManagementContext())
            {
                result = (from mb in db.MstMerkBus
                          select new MerkBusViewModel
                          {
                              Id = mb.Id,
                              MerkId = mb.MerkId,
                              Description = mb.Description,
                              IsActive = mb.IsActive,
                              CreatedBy = mb.CreatedBy,
                              Created = mb.Created,
                              ModifiedBy = mb.ModifiedBy,
                              Modified = mb.Modified
                          }).ToList();
            }
            return result;
        }

        public static bool Update (MerkBusViewModel model)
        {
            bool result = true;
            try
            {
                using (var db = new FleetManagementContext())
                {
                    if(model.Id==0)
                    {
                        MstMerkBu merkbus = new MstMerkBu();
                        merkbus.MerkId = model.MerkId;
                        merkbus.Description = model.Description;
                        merkbus.IsActive = model.IsActive;
                        merkbus.CreatedBy = model.CreatedBy;
                        merkbus.Created = model.Created;
                        merkbus.ModifiedBy = model.ModifiedBy;
                        merkbus.Modified = model.Modified;
                        db.MstMerkBus.Add(merkbus);
                        db.SaveChanges();
                    }
                    else
                    {
                        MstMerkBu merkbus = db.MstMerkBus.Where(o => o.Id == model.Id).FirstOrDefault();
                        if (merkbus != null)
                        {
                            merkbus.MerkId = model.MerkId;
                            merkbus.Description = model.Description;
                            merkbus.IsActive = model.IsActive;
                            merkbus.CreatedBy = model.CreatedBy;
                            merkbus.Created = model.Created;
                            merkbus.ModifiedBy = model.ModifiedBy;
                            merkbus.Modified = model.Modified;
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

        public static MerkBusViewModel GetById (int id)
        {
            MerkBusViewModel result = new MerkBusViewModel();
            using (var db = new FleetManagementContext())
            {
                result = (from mb in db.MstMerkBus
                          where mb.Id == id
                          select new MerkBusViewModel
                          {
                              Id = mb.Id,
                              MerkId = mb.MerkId,
                              Description = mb.Description,
                              IsActive = mb.IsActive,
                              CreatedBy = mb.CreatedBy,
                              Created = mb.Created,
                              ModifiedBy = mb.ModifiedBy,
                              Modified = mb.Modified
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
                    MstMerkBu merkbus = db.MstMerkBus.Where(o => o.Id == id).FirstOrDefault();
                    if (merkbus != null)
                    {
                        db.MstMerkBus.Remove(merkbus);
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
