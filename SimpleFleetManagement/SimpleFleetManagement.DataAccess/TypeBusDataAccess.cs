using SimpleFleetManagement.DataModel;
using SimpleFleetManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFleetManagement.DataAccess
{
    public class TypeBusDataAccess
    {
        public static string Message = string.Empty;
        public static List<TypeBusViewModel> GetAll()
        {
            List<TypeBusViewModel> result = new List<TypeBusViewModel>();
            using (var db = new FleetManagementContext())
            {
                result = (from tb in db.MstTypeBus
                          join mb in db.MstMerkBus
                          on tb.MerkId equals mb.MerkId
                          select new TypeBusViewModel
                          {
                              Id = tb.Id,
                              MerkId = tb.MerkId,
                              TypeId = tb.TypeId,
                              Description = tb.Description,
                              IsActive = tb.IsActive,
                              CreatedBy = tb.CreatedBy,
                              Created = tb.Created,
                              ModifiedBy = tb.ModifiedBy,
                              Modified = tb.Modified
                          }).ToList();
            }
            return result;
        }

        public static TypeBusViewModel GetById(int id)
        {
            TypeBusViewModel result = new TypeBusViewModel();
            using (var db = new FleetManagementContext())
            {
                result = (from tb in db.MstTypeBus
                          join mb in db.MstMerkBus
                          on tb.MerkId equals mb.MerkId
                          where tb.Id == id
                          select new TypeBusViewModel
                          {
                              Id = tb.Id,
                              MerkId = tb.MerkId,
                              TypeId = tb.TypeId,
                              Description = tb.Description,
                              IsActive = tb.IsActive,
                              CreatedBy = tb.CreatedBy,
                              Created = tb.Created,
                              ModifiedBy = tb.ModifiedBy,
                              Modified = tb.Modified
                          }).FirstOrDefault();
            }
            return result;
        }

        public static List<TypeBusViewModel> GetByMerkBus (string merkbusid)
        {
            List<TypeBusViewModel> result = new List<TypeBusViewModel>();
            using (var db = new FleetManagementContext())
            {
                result = (from tb in db.MstTypeBus
                          join mb in db.MstMerkBus
                          on tb.MerkId equals mb.MerkId
                          select new TypeBusViewModel
                          {
                              Id = tb.Id,
                              MerkId = tb.MerkId,
                              TypeId = tb.TypeId,
                              Description = tb.Description,
                              IsActive = tb.IsActive,
                              CreatedBy = tb.CreatedBy,
                              Created = tb.Created,
                              ModifiedBy = tb.ModifiedBy,
                              Modified = tb.Modified
                          }).ToList();
            }
            return result;
        }

        public static bool Update(TypeBusViewModel model)
        {
            bool result = true;
            try
            {
                using (var db = new FleetManagementContext())
                {
                    if (model.Id == 0)
                    {
                        MstTypeBu typebus = new MstTypeBu();
                        typebus.MerkId = model.MerkId;
                        typebus.TypeId = model.TypeId;
                        typebus.Description = model.Description;
                        typebus.IsActive = model.IsActive;
                        typebus.CreatedBy = model.CreatedBy;
                        typebus.Created = model.Created;
                        typebus.ModifiedBy = model.ModifiedBy;
                        typebus.Modified = model.Modified;
                        db.MstTypeBus.Add(typebus);
                        db.SaveChanges();
                    }
                    else
                    {
                        MstTypeBu typebus = db.MstTypeBus.Where(o => o.Id == model.Id).FirstOrDefault();
                        if (typebus != null)
                        {
                            typebus.MerkId = model.MerkId;
                            typebus.TypeId = model.TypeId;
                            typebus.Description = model.Description;
                            typebus.IsActive = model.IsActive;
                            typebus.CreatedBy = model.CreatedBy;
                            typebus.Created = model.Created;
                            typebus.ModifiedBy = model.ModifiedBy;
                            typebus.Modified = model.Modified;
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

        public static bool Delete(int id)
        {
            bool result = true;
            try
            {
                using(var db = new FleetManagementContext())
                {
                    MstTypeBu typebus = db.MstTypeBus.Where(o => o.Id == o.Id).FirstOrDefault();
                        if (typebus != null)
                        {
                            db.MstTypeBus.Remove(typebus);
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
