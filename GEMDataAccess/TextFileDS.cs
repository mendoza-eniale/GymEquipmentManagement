using System;
using System.IO;

namespace GEMDataAccess
{
    public class TextFileDataService : IGEMDataService
    {
        private readonly string equipmentFile = "equipment.txt";
        private readonly string historyFile = "history.txt";

        public string GetEquipmentData()
        {
            if (File.Exists(equipmentFile))
            {
                return File.ReadAllText(equipmentFile);
            }
          
                return "";
            }
        

        public string GetHistoryData()
        {
            if (File.Exists(historyFile))
            {
                return File.ReadAllText(historyFile);
            }
            
                return "";
            }
        

        public void SetEquipmentData(string data)
        {
            File.AppendAllText(equipmentFile, data + "\n\n");
        }
        public void SetHistoryData(string data)
        {
            File.AppendAllText(historyFile, data + "\n");
        }

        public void ReplaceEquipmentData(string newData)
        {
            File.WriteAllText(equipmentFile,newData);
        }
    }
}
