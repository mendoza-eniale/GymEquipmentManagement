using GEMCommon;

namespace GEMDataAccess
{

    public class GEMEquipStorage
    {
        private IGEMDataService dataService;
        private LoginService loginService = new LoginService();

        public GEMEquipStorage(IGEMDataService service)
        {
            dataService = service;
        }

        public string GetEquipmentData()
        {
            return dataService.GetEquipmentData();
        }

        public string GetHistoryData()
        {
            return dataService.GetHistoryData();
        }

        public void SetEquipmentData(string data)
        {
            dataService.SetEquipmentData(data);
        }

        public void SetHistoryData(string data)
        {
            dataService.SetHistoryData(data);
        }

        public void ReplaceEquipmentData(string newData)
        {
            dataService.ReplaceEquipmentData(newData);
        }

        public bool LogIn(string inputUsername, string inputPassword)
        {
            return loginService.LogIn(inputUsername, inputPassword);
        }
    }
    }
