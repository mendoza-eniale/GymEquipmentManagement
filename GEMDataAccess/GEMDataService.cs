using System;
using GEMCommon;

namespace GEMDataAccess
{
    public class GEMDataService : IGEMDataService
    {
        private readonly DBDataService dbService = new DBDataService();

        public string GetEquipmentData()
        {
            return dbService.GetEquipmentData();
        }
        public string GetHistoryData()
        {
            return dbService.GetHistoryData();
        }

        public void SetEquipmentData(EquipmentItem equip)
        {
            dbService.SetEquipmentData(equip);
        }

        public void SetHistoryData(string data)
        {
            dbService.SetHistoryData(data);
        }

        public void ReplaceEquipmentData(string newData)
        {
            dbService.ReplaceEquipmentData(newData);
        }

        public string SearchEquipment(int id)
        {
            try
            {
                return dbService.SearchEquipment(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to search for equipment ID {id}: {ex.Message}", ex);
            }
        }
    }
}
