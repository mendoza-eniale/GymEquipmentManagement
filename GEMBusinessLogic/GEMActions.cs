
using GEMCommon;


namespace GEMBusinessLogic
{
    public class GEMActions
    {
        private Service service;
        private int idCounter = 1;

        public GEMActions()
        {
            service = new Service();
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

            service.GetStorage().SetEquipmentData(item.ToString());
            service.GetStorage().SetHistoryData($"Added: {item}");
        }

        public void UpdateEquipment(int id, string newName, string newStatus, int newQuantity)
        {
            var data = service.GetStorage().GetEquipmentData();
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
                    service.GetStorage().SetHistoryData($"Updated: {entry} → {updatedItem}");
                    updated = true;
                }
                else
                {
                    updatedList.Add(entry);
                }
            }

            if (updated)
            {
                service.GetStorage().ReplaceEquipmentData(string.Join("\n\n", updatedList));
            }
            else
            {
                service.GetStorage().SetHistoryData($"Update Failed: Equipment ID {id} not found.");
            }
        }

        public bool DeleteEquipment(int id)
        {
            var data = service.GetStorage().GetEquipmentData();
            var entries = data.Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);
            var updatedList = new List<string>();
            bool deleted = false;

            foreach (var entry in entries)
            {
                if (entry.StartsWith($"ID: {id}\n"))
                {
                    service.GetStorage().SetHistoryData($"Deleted: {entry}");
                    deleted = true;
                }
                else
                {
                    updatedList.Add(entry);
                }
            }

            if (deleted)
            {
                service.GetStorage().ReplaceEquipmentData(string.Join("\n\n", updatedList));
            }
            else
            {
                service.GetStorage().SetHistoryData($"Delete Failed: Equipment ID {id} not found.");
            }

            return deleted;
        }

        public string SearchEquipment(int id)
        {
            var data = service.GetStorage().GetEquipmentData();
            var entries = data.Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var entry in entries)
            {
                if (entry.StartsWith($"ID: {id}\n"))
                {
                    return entry;
                }
            }
            return $"No equipment found with ID: {id}";
        }

        public string ViewEquipmentList()
        {
            var data = service.GetStorage().GetEquipmentData();
            return string.IsNullOrWhiteSpace(data) ? "No equipment available." : data;
        }

        public string ViewHistory()
        {
            var data = service.GetStorage().GetHistoryData();
            return string.IsNullOrWhiteSpace(data) ? "No history available." : data;
        }
    }
}