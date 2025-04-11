using System;
using GEMDataAccess;

namespace GEMBusinessLogic
{
    public class GEMProcess
    {
        private EquipStorage storage;
        private int idCounter = 1;

        public GEMProcess()
        {
            storage = new EquipStorage();

        }
        public void AddEquipment(string name, string status, int quantity)
        {
            string entry = "ID: " + idCounter + "\nName: " + name + "\nStatus: " + status + "\nQuantity: " + quantity;
            storage.SetEquipmentData(storage.GetEquipmentData() + entry + "\n");
            storage.SetHistoryData(storage.GetHistoryData() + "Added: \n" + entry + "\n");
            idCounter++;
        }

        public void UpdateEquipment(int id, string newName, string newStatus, int newQuantity)
        {
            string data = storage.GetEquipmentData();
            string[] newEntries = data.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            string newData = "";
            bool updated = true;

            for (int i = 0; i < newEntries.Length; i++)
            {
                string entry = newEntries[i];
                if (entry.Length > 0)
                {
                    if (entry.Contains("ID: " + id))
                    {
                        string updatedEntry = "ID: " + id + "\nName: " + newName + "\nStatus: " + newStatus + "\nQuantity: " + newQuantity;
                        newData += updatedEntry + "\n";
                        storage.SetHistoryData(storage.GetHistoryData() + ("Updated: " + entry + " → " + updatedEntry + "\n"));
                        updated = true;
                    }
                    else
                    {
                        newData += entry + "\n\n";
                    }
                }
            }

            if (updated)
            {
                storage.ReplaceEquipmentData(newData);
            }
            else
            {
                storage.SetHistoryData(storage.GetHistoryData() + "Update Failed: Equipment ID " + id + " not found.\n");
            }
        }
        public bool DeleteEquipment(int id)
        {
            string equipmentData = storage.GetEquipmentData();
            string[] entries = equipmentData.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            string newData = "";
            bool deleted = false;


            foreach (string entry in entries)
            {
                if (entry.Contains("ID: " + id))
                {
                    storage.SetHistoryData(storage.GetHistoryData() + "Deleted: " + entry + "\n");
                    deleted = true;
                }
                else
                {
                    newData += entry + "\n";
                }
            }
            if (deleted)
            {
                storage.ReplaceEquipmentData(newData);
            }
            else
            {
                storage.SetHistoryData(storage.GetHistoryData() + "Delete Failed: Equipment ID " + id + " not found.\n");
            }
            return deleted;
        }


        public string SearchEquipment(int ID)
        {
            string[] entries = storage.GetEquipmentData().Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            string results = "";

            foreach (string entry in entries)
            {
                if (entry.Contains("ID: " + ID))
                {
                    results += entry + "\n";
                }
            }
            return results.Length > 0 ? results : "No equipment found with ID: " + ID;
        }
        public string ViewEquipmentList()
        {
            string data = storage.GetEquipmentData();
            return string.IsNullOrWhiteSpace(data) ? "No equipment available." : data;
        }

        public string ViewHistory()
        {
            string data = storage.GetHistoryData();
            return string.IsNullOrWhiteSpace(data) ? "No history available." : data;
        }
    }
}