using System.IO;

namespace GEMDataAccess
{
    public class JsonFileDS : IGEMDataService
    {
        private string equipmentFilePath;
        private string historyFilePath;

        public JsonFileDS(string equipmentFilePath = "equipment.json", string historyFilePath = "history.json")
        {
            this.equipmentFilePath = equipmentFilePath;
            this.historyFilePath = historyFilePath;
        }

        public string GetEquipmentData()
        {
            if (File.Exists(equipmentFilePath))
            {
                return File.ReadAllText(equipmentFilePath);
            }
            else
            {
                return "";
            }
        }

        public string GetHistoryData()
        {
            if (File.Exists(historyFilePath))
            {
                return File.ReadAllText(historyFilePath);
            }
            else
            {
                return "";
            }
        }

        public void SetEquipmentData(string data)
        {
            File.AppendAllText(equipmentFilePath, data);
        }

        public void SetHistoryData(string data)
        {
            File.AppendAllText(historyFilePath, data);
        }

        public void ReplaceEquipmentData(string newData)
        {
            File.WriteAllText(equipmentFilePath, newData);
        }
    }
}
