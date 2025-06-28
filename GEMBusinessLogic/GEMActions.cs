using GEMCommon;
using GEMDataAccess;
using System.Collections.Generic;
using System.Text;

namespace GEMBusinessLogic
{
    public class GEMActions
    {
        private readonly GEMEquipStorage storage;
        private int idCounter;

        public GEMActions(GEMEquipStorage storage)
        {
            this.storage = storage ?? throw new ArgumentNullException(nameof(storage));
            this.idCounter = GetMaxId() + 1;
        }

        public GEMActions()
        {
            storage = new GEMEquipStorage(new InMemoryDataService());
            idCounter = GetMaxId() + 1;
        }

        public void AddEquipment(string name, string status, int quantity)
        {
            var item = new EquipmentItem
            {
                Id = idCounter++,
                Name = name,
                Status = status,
                Quantity = quantity
            };

            storage.SetEquipmentData(item);
            storage.SetHistoryData($"Added: {item}");
        }

        public void UpdateEquipment(int id, string newName, string newStatus, int newQuantity)
        {
            var data = storage.GetEquipmentData();
            var entries = data.Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);
            var updatedList = new List<string>();
            bool updated = false;

            foreach (var entry in entries)
            {
                if (entry.StartsWith($"ID: {id}\n"))
                {
                    var updatedItem = new EquipmentItem
                    {
                        Id = id,
                        Name = newName,
                        Status = newStatus,
                        Quantity = newQuantity
                    };
                    updatedList.Add(updatedItem.ToString());
                    storage.SetHistoryData($"Updated: {entry} → {updatedItem}");
                    updated = true;
                }
                else
                {
                    updatedList.Add(entry);
                }
            }

            if (updated)
            {
                storage.ReplaceEquipmentData(string.Join("\n\n", updatedList));
            }
            else
            {
                storage.SetHistoryData($"Update Failed: Equipment ID {id} not found.");
            }
        }

        public bool DeleteEquipment(int id)
        {
            var data = storage.GetEquipmentData();
            var entries = data.Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);
            var updatedList = new List<string>();
            bool deleted = false;

            foreach (var entry in entries)
            {
                var lines = entry.Split('\n');
                var idLine = lines.FirstOrDefault(l => l.StartsWith("ID: "));
                if (idLine != null && int.TryParse(idLine.Substring(4), out int entryId) && entryId == id)
                {
                    storage.SetHistoryData($"Deleted: {entry}");
                    deleted = true;
                }
                else
                {
                    updatedList.Add(entry);
                }
            }

            if (deleted)
            {
                storage.ReplaceEquipmentData(string.Join("\n\n", updatedList));
            }
            else
            {
                storage.SetHistoryData($"Delete Failed: Equipment ID {id} not found.");
            }

            return deleted;
        }


        public string SearchEquipment(int id)
        {
            try
            {
                var data = storage.GetEquipmentData();
                if (string.IsNullOrWhiteSpace(data))
                {
                    return $"No equipment available in the database.";
                }

                var entries = data.Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var entry in entries)
                {
                    var lines = entry.Split('\n');
                    foreach (var line in lines)
                    {
                        if (line.StartsWith("ID: ") && int.TryParse(line.Substring(4), out int currentId) && currentId == id)
                        {
                            StringBuilder result = new StringBuilder();
                            result.AppendLine(entry);
                            return result.ToString().Trim();
                        }
                    }
                }

                return $"No equipment found with ID: {id}";
            }
            catch (Exception ex)
            {
                return $"An error occurred while searching for equipment: {ex.Message}";
            }
        }


        public string ViewEquipmentList()
        {
            var data = storage.GetEquipmentData();
            return string.IsNullOrWhiteSpace(data) ? "No equipment available." : data;
        }

        public string ViewHistory()
        {
            var data = storage.GetHistoryData();
            return string.IsNullOrWhiteSpace(data) ? "No history available." : data;
        }

        private int GetMaxId()
        {
            var data = storage.GetEquipmentData();
            var entries = data.Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);
            int maxId = 0;

            foreach (var entry in entries)
            {
                var lines = entry.Split('\n');
                foreach (var line in lines)
                {
                    if (line.StartsWith("ID: "))
                    {
                        if (int.TryParse(line.Substring(4), out int id))
                        {
                            if (id > maxId) maxId = id;
                        }
                    }
                }
            }

            return maxId;
        }
    }
}
