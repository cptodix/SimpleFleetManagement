using SimpleFleetManagement.DataModel;
using SimpleFleetManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFleetManagement.DataAccess
{
    public class CrewDataAccess
    {
        public static string Message = string.Empty;
        public static List<CrewViewModel> GetAll()
        {
            List<CrewViewModel> result = new List<CrewViewModel>();
            using (var db = new FleetManagementContext())
            {
                result = (from crw in db.MstCrews
                          select new CrewViewModel
                          {
                              Id = crw.Id,
                              CrewId = crw.CrewId,
                              CrewName = crw.CrewName,
                              DrivingLicenseNumber = crw.DrivingLicenseNumber,
                              Address = crw.Address,
                              PlaceOfBirth = crw.PlaceOfBirth,
                              DateOfBirth = crw.DateOfBirth,
                              Gender = crw.Gender,
                              Role = crw.Role,
                              IsActive = crw.IsActive
                          }).ToList();
            }
            return result;
        }

        public static CrewViewModel GetById(int id)
        {
            CrewViewModel result = new CrewViewModel();
            using (var db = new FleetManagementContext())
            {
                result = (from crw in db.MstCrews
                          where crw.Id == id
                          select new CrewViewModel
                          {
                              Id = crw.Id,
                              CrewId = crw.CrewId,
                              CrewName = crw.CrewName,
                              DrivingLicenseNumber = crw.DrivingLicenseNumber,
                              Address = crw.Address,
                              PlaceOfBirth = crw.PlaceOfBirth,
                              DateOfBirth = crw.DateOfBirth,
                              Gender = crw.Gender,
                              Role = crw.Role,
                              IsActive = crw.IsActive
                          }).FirstOrDefault();
            }
            return result;
        }

        public static bool Update(CrewViewModel model)
        {
            bool result = true;

            try
            {
                using (var db = new FleetManagementContext())
                {
                    if (model.Id == 0)
                    {
                        MstCrew crw = new MstCrew();
                        crw.CrewId = model.CrewId;
                        crw.CrewName = model.CrewName;
                        crw.DrivingLicenseNumber = model.DrivingLicenseNumber;
                        crw.Address = model.Address;
                        crw.PlaceOfBirth = model.PlaceOfBirth;
                        crw.DateOfBirth = model.DateOfBirth;
                        crw.Gender = model.Gender;
                        crw.Role = model.Role;
                        crw.IsActive = model.IsActive;
                        db.MstCrews.Add(crw);
                        db.SaveChanges();
                    }
                    else
                    {
                        MstCrew crw = db.MstCrews.Where(o => o.Id == model.Id).FirstOrDefault();
                        if (crw != null)
                        {
                            crw.CrewId = model.CrewId;
                            crw.CrewName = model.CrewName;
                            crw.DrivingLicenseNumber = model.DrivingLicenseNumber;
                            crw.Address = model.Address;
                            crw.PlaceOfBirth = model.PlaceOfBirth;
                            crw.DateOfBirth = model.DateOfBirth;
                            crw.Gender = model.Gender;
                            crw.Role = model.Role;
                            crw.IsActive = model.IsActive;
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
                    MstCrew crw = db.MstCrews.Where(o => o.Id == id).FirstOrDefault();
                    if (crw != null)
                    {
                        db.MstCrews.Remove(crw);
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
