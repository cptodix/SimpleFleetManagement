using SimpleFleetManagement.DataModel;
using SimpleFleetManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFleetManagement.DataAccess
{
    public class MaintenanceDataAccess
    {
        public static string Message = string.Empty;
        public static bool Update(MaintenanceHeaderViewModel model)
        {
            bool result = true;
            try
            {
                using (var db = new FleetManagementContext())
                {
                    TrxMaintenanceHeader mh = new TrxMaintenanceHeader();
                    mh.Id = 1;
                    mh.MaintenanceId = model.MaintenanceId;
                    mh.MaintenanceDate = model.MaintenanceDate;
                    mh.FleetId = model.FleetId;
                    mh.MaintenanceKm = model.MaintenanceKm;
                    mh.TotalPrice = model.TotalPrice;
                    db.TrxMaintenanceHeaders.Add(mh);

                    foreach (var item in model.MaintenanceDetails)
                    {
                        TrxMaintenanceDetail md = new TrxMaintenanceDetail();
                        md.MaintenanceId = mh.MaintenanceId;
                        md.MechanicId = item.MechanicId;
                        md.ServiceId = item.ServiceId;
                        md.PartId = item.PartId;
                        md.PartQuantity = item.PartQuantity;
                        md.SubTotalPrice = item.SubTotalPrice;
                        db.TrxMaintenanceDetails.Add(md);
                    }
                    db.SaveChanges();
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
