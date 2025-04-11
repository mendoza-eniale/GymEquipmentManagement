using System;

namespace GEMDataAccess{
    public class EquipStorage{

        private DataService dataService = new DataService();
        private LoginService loginService = new LoginService();

        public string GetEquipmentData(){
            return dataService.GetEquipmentData();
        }

        public string GetHistoryData(){
            return dataService.GetHistoryData();
        }

        public void SetEquipmentData(string data){
            dataService.SetEquipmentData(data);
        }

        public void SetHistoryData(string data) {
            dataService.SetHistoryData(data);
        }

        public void ReplaceEquipmentData(string newData) {
            dataService.ReplaceEquipmentData(newData);
        }

        public bool LogIn(string inputUsername, string inputPassword){
            return loginService.LogIn(inputUsername, inputPassword);
        }
    }
}
