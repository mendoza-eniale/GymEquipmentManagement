
using System;

namespace GEMDataAccess
{
    public class EquipStorage
    {
        private string equipmentData = "";
        private string historyData = "";

        public string GetEquipmentData() => equipmentData;
        public string GetHistoryData() => historyData;

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
