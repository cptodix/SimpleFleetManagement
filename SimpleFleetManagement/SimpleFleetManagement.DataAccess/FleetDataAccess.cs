using SimpleFleetManagement.DataModel;
using SimpleFleetManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFleetManagement.DataAccess
{
    public class FleetDataAccess
    {
        public static string Message = string.Empty;
        public static List<FleetViewModel> GetAll()
        {
            List<FleetViewModel> result = new List<FleetViewModel>();
            using (var db = new FleetManagementContext())
            {
                result = (from flt in db.MstFleets
                          join kar in db.MstKaroseris
                          on flt.KaroseriId equals kar.KaroseriId
                          join tyb in db.MstTypeBus
                          on flt.TypeId equals tyb.TypeId
                          join mrk in db.MstMerkBus
                          on tyb.MerkId equals mrk.MerkId
                          select new FleetViewModel
                          {
                              Id = flt.Id,
                              FleetId = flt.FleetId,
                              TypeId = flt.TypeId,
                              TypeName = tyb.Description,
                              MerkId = tyb.MerkId,
                              MerkName = mrk.Description,
                              LicenseNumber = flt.LicenseNumber,
                              KaroseriId = flt.KaroseriId,
                              KaroseriName = kar.Description,
                              SeatCapacity = flt.SeatCapacity,
                              IsActive = flt.IsActive
                          }).ToList();
            }
            return result;
        }

        public static FleetViewModel GetById(int id)
        {
            FleetViewModel result = new FleetViewModel();
            using (var db = new FleetManagementContext())
            {
                result = (from flt in db.MstFleets
                          join kar in db.MstKaroseris
                          on flt.KaroseriId equals kar.KaroseriId
                          join tyb in db.MstTypeBus
                          on flt.TypeId equals tyb.TypeId
                          join mrk in db.MstMerkBus
                          on tyb.MerkId equals mrk.MerkId
                          where flt.Id == id
                          select new FleetViewModel
                          {
                              Id = flt.Id,
                              FleetId = flt.FleetId,
                              TypeId = flt.TypeId,
                              TypeName = tyb.Description,
                              MerkId = tyb.MerkId,
                              MerkName = mrk.MerkId,
                              LicenseNumber = flt.LicenseNumber,
                              KaroseriId = flt.KaroseriId,
                              KaroseriName = kar.Description,
                              SeatCapacity = flt.SeatCapacity,
                              IsActive = flt.IsActive
                          }).FirstOrDefault();
            }
            return result;
        }

        public static List<FleetViewModel> GetByFleetException(FleetOrderException fleetorderexception)
        {
            List<FleetViewModel> result = new List<FleetViewModel>();
            using (var db = new FleetManagementContext())
            {
                result = (from flt in db.MstFleets
                          join tyb in db.MstTypeBus
                          on flt.TypeId equals tyb.TypeId
                          join mrk in db.MstMerkBus
                          on tyb.MerkId equals mrk.MerkId
                          select new FleetViewModel
                          {
                              Id = flt.Id,
                              FleetId = flt.FleetId,
                              TypeId = flt.TypeId,
                              TypeName = tyb.Description,
                              MerkName = mrk.Description,
                              LicenseNumber = flt.LicenseNumber,
                              KaroseriId = flt.KaroseriId,
                              SeatCapacity = flt.SeatCapacity,
                              IsActive = flt.IsActive
                          }).Where(o => !fleetorderexception.fleetexceptlist.Contains(o.FleetId)).ToList();
            }
            return result;
        }

        public static bool Update(FleetViewModel model)
        {
            bool result = true;

            try
            {
                using (var db = new FleetManagementContext())
                {
                    if (model.Id == 0)
                    {
                        MstFleet flt = new MstFleet();
                        flt.FleetId = model.FleetId;
                        flt.TypeId = model.TypeId;
                        flt.LicenseNumber = model.LicenseNumber;
                        flt.KaroseriId = model.KaroseriId;
                        flt.SeatCapacity = model.SeatCapacity;
                        flt.IsActive = model.IsActive;
                        db.MstFleets.Add(flt);
                        db.SaveChanges();
                    }
                    else
                    {
                        MstFleet flt = db.MstFleets.Where(o => o.Id == model.Id).FirstOrDefault();
                        if (flt != null)
                        {
                            flt.FleetId = model.FleetId;
                            flt.TypeId = model.TypeId;
                            flt.LicenseNumber = model.LicenseNumber;
                            flt.KaroseriId = model.KaroseriId;
                            flt.SeatCapacity = model.SeatCapacity;
                            flt.IsActive = model.IsActive;
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
                    MstFleet flt = db.MstFleets.Where(o => o.Id == id).FirstOrDefault();
                    if (flt != null)
                    {
                        db.MstFleets.Remove(flt);
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
