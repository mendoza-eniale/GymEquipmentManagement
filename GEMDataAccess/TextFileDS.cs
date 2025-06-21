

namespace GEMDataAccess
{
    public class TextFileDataService : IGEMDataService
    {
        private readonly string equipmentFile = "equipment.txt";
        private readonly string historyFile = "history.txt";

        public string GetEquipmentData()
        {
            return File.Exists(equipmentFile) ? File.ReadAllText(equipmentFile) : "";
        }

        public string GetHistoryData()
        {
            return File.Exists(historyFile) ? File.ReadAllText(historyFile) : "";
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
            File.WriteAllText(equipmentFile, newData);
        }
    }
}
