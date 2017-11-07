using SimpleFleetManagement.DataModel;
using SimpleFleetManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFleetManagement.DataAccess
{
    public class KaroseriDataAccess
    {
        public static string Message = string.Empty;
        public static List<KaroseriViewModel> GetAll()
        {
            List<KaroseriViewModel> result = new List<KaroseriViewModel>();
            using (var db = new FleetManagementContext())
            {
                result = (from kar in db.MstKaroseris
                          select new KaroseriViewModel
                          {
                              Id = kar.Id,
                              KaroseriId = kar.KaroseriId,
                              Description = kar.Description,
                              IsActive = kar.IsActive
                          }).ToList();
            }
            return result;
        }

        public static KaroseriViewModel GetById(int id)
        {
            KaroseriViewModel result = new KaroseriViewModel();
            using (var db = new FleetManagementContext())
            {
                result = (from kar in db.MstKaroseris
                          where kar.Id == id
                          select new KaroseriViewModel
                          {
                              Id = kar.Id,
                              KaroseriId = kar.KaroseriId,
                              Description = kar.Description,
                              IsActive = kar.IsActive
                          }).FirstOrDefault();
            }
            return result;
        }

        public static bool Update(KaroseriViewModel model)
        {
            bool result = true;

            try
            {
                using (var db = new FleetManagementContext())
                {
                    if (model.Id == 0)
                    {
                        MstKaroseri kar = new MstKaroseri();
                        kar.KaroseriId = model.KaroseriId;
                        kar.Description = model.Description;
                        kar.IsActive = model.IsActive;
                        db.MstKaroseris.Add(kar);
                        db.SaveChanges();
                    }
                    else
                    {
                        MstKaroseri kar = db.MstKaroseris.Where(o => o.Id == model.Id).FirstOrDefault();
                        if (kar != null)
                        {
                            kar.KaroseriId = model.KaroseriId;
                            kar.Description = model.Description;
                            kar.IsActive = model.IsActive;
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
                    MstKaroseri kar = db.MstKaroseris.Where(o => o.Id == id).FirstOrDefault();
                    if (kar != null)
                    {
                        db.MstKaroseris.Remove(kar);
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
