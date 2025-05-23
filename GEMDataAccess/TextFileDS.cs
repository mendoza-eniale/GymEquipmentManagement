using System.IO;

namespace GEMDataAccess
{
    public class TextFileDS : IGEMDataService
    {
        private string equipmentFilePath = "equipment.txt";
        private string historyFilePath = "history.txt";

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
            File.AppendAllText(equipmentFilePath, data + "\n");
        }

        public void SetHistoryData(string data)
        {
            File.AppendAllText(historyFilePath, data + "\n");
        }

        public void ReplaceEquipmentData(string newData)
        {
            File.WriteAllText(equipmentFilePath, newData);
        }
    }
}
