using System;

namespace GEMDataAccess
{
    public class GEMDataService
    {
        private string equipmentData = "";
        private string historyData = "";

        public GEMDataService()
        {
            
        }

        public string GetEquipmentData()
        {
            return equipmentData;
        }

        public string GetHistoryData()
        {
            return historyData;
        }

        public void SetEquipmentData(string data)
        {
            equipmentData = data + "\n\n";
        }

        public void SetHistoryData(string data)
        {
            historyData = data + "\n";
        }

        public void ReplaceEquipmentData(string newData)
        {
            equipmentData = newData;
        }
    }
}