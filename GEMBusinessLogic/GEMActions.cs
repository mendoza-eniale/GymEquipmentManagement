using GEMDataAccess;
using System;

namespace GEMBusinessLogic{
    public class GEMActions {
        private int idCounter = 1;
        private Service service;

        public GEMActions(){
            service = new Service();

            AddEquipment("Treadmill", "Working", 5);
            AddEquipment("Dumbbell", "Working", 20);
            AddEquipment("Bench Press", "Needs Repair", 3);
            AddEquipment("Stationary Bike", "Working", 4);
            AddEquipment("Rowing Machine", "Needs Repair", 2);
            AddEquipment("Pull-up Bar", "Working", 6);
            AddEquipment("Leg Press", "Needs Repair", 2);
            AddEquipment("Elliptical Trainer", "Working", 3);
        }

        public void AddEquipment(string name, string status, int quantity){

            string entry = "ID: " + idCounter + "\nName: " + name + "\nStatus: " + status + "\nQuantity: " + quantity;
            service.GetStorage().SetEquipmentData(service.GetStorage().GetEquipmentData() + entry + "\n");
            service.GetStorage().SetHistoryData(service.GetStorage().GetHistoryData() + "Added: \n" + entry + "\n");
            idCounter++;
        }

        public void UpdateEquipment(int id, string newName, string newStatus, int newQuantity) {

            string data = service.GetStorage().GetEquipmentData();
            string[] newEntries = data.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            string newData = "";
            bool updated = false;

            for (int i = 0; i < newEntries.Length; i++) {

                if (newEntries[i].StartsWith("ID: " + id)){
                    string updatedEntry = "ID: " + id + "\nName: " + newName + "\nStatus: " + newStatus + "\nQuantity: " + newQuantity;
                    newData += updatedEntry + "\n";
                    service.GetStorage().SetHistoryData(service.GetStorage().GetHistoryData() + "Updated: " + newEntries[i] + " → " + updatedEntry + "\n");
                    i += 3;
                    updated = true;
                }
                else
                {
                    newData += newEntries[i] + "\n\n";
                }
            }

            if (updated)
            {
                service.GetStorage().ReplaceEquipmentData(newData);
            }
            else
            {
                service.GetStorage().SetHistoryData(service.GetStorage().GetHistoryData() + "Update Failed: Equipment ID " + id + " not found.\n");
            }
        }

        public bool DeleteEquipment(int id) {

            string equipmentData = service.GetStorage().GetEquipmentData();
            string[] entries = equipmentData.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            string newData = "";
            bool deleted = false;

            foreach (string entry in entries){

                if (entry.Contains("ID: " + id)) {

                    service.GetStorage().SetHistoryData(service.GetStorage().GetHistoryData() + "Deleted: " + entry + "\n");
                    deleted = true;
                }
                else
                {
                    newData += entry + "\n";
                }
            }

            if (deleted)
            {
                service.GetStorage().ReplaceEquipmentData(newData);
            }
            else
            {
                service.GetStorage().SetHistoryData(service.GetStorage().GetHistoryData() + "Delete Failed: Equipment ID " + id + " not found.\n");
            }

            return deleted;
        }

        public string SearchEquipment(int ID) {
            string[] entries = service.GetStorage().GetEquipmentData().Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            string results = "";
            bool matchFound = false;

            for (int i = 0; i < entries.Length; i++){

                if (entries[i].StartsWith("ID: " + ID)) {
                    matchFound = true;
                    results += entries[i] + "\n" + entries[i + 1] + "\n" + entries[i + 2] + "\n" + entries[i + 3] + "\n";
                    break;
                }
            }

            return matchFound ? results : "No equipment found with ID: " + ID;
        }

        public string ViewEquipmentList() {

            string data = service.GetStorage().GetEquipmentData();
            return string.IsNullOrWhiteSpace(data) ? "No equipment available." : data;
        }

        public string ViewHistory(){

            string data = service.GetStorage().GetHistoryData();
            return string.IsNullOrWhiteSpace(data) ? "No history available." : data;
        }
    }
}
