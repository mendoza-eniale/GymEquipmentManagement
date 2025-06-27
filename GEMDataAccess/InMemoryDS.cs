using GEMCommon;

namespace GEMDataAccess
{
    public class InMemoryDataService : IGEMDataService
    {
        private string equipmentData = "";
        private string historyData = "";

        public string GetEquipmentData()
        {
            return equipmentData;
        }

        public string GetHistoryData()
        {
            return historyData;
        }

        public void SetEquipmentData(EquipmentItem equip)
        {
            equipmentData += equip + "\n\n";
        }

        public void SetHistoryData(string data)
        {
            historyData += data + "\n";
        }
        public void ReplaceEquipmentData(string newData)
        {
            equipmentData = newData;
        }
        public string SearchEquipment(int id)
        {
            var entries = equipmentData.Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var entry in entries)
            {
                if (entry.StartsWith($"ID: {id}"))
                {
                    return entry;
                }
            }
            return $"No equipment found with ID: {id}";
        }

    }
}
