using GEMCommon;

namespace GEMDataAccess
{
    public interface IGEMDataService
    {
        void SetEquipmentData(EquipmentItem equip);
        void ReplaceEquipmentData(string newData);
        string GetEquipmentData();
        string GetHistoryData();
        void SetHistoryData(string data);
        string SearchEquipment(int id);
    }
}
