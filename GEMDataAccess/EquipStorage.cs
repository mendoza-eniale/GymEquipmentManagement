
using System;

namespace GEMDataAccess
{
    public class EquipStorage
    {
        private string equipmentData = "";
        private string historyData = "";
        private string username = "admin";
        private string password = "123456";

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
        public bool LogIn (string username, string password)
        {
            if (username == username && password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
