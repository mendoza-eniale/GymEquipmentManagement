


namespace GEMDataAccess
{
    public interface IGEMDataService
    {
        string GetEquipmentData();
        string GetHistoryData();
        void SetEquipmentData(string data);
        void SetHistoryData(string data);
        void ReplaceEquipmentData(string newData);
    }
}

// condition na dapaat lahat ng nanditong method makikita sa bl and dl
