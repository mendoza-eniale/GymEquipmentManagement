using GEMCommon;
using GEMDataAccess;

namespace GEMDataAccess
{
    public class GEMEquipStorage
    {
        private readonly IGEMDataService dataService;

        public GEMEquipStorage(IGEMDataService service)
        {
            dataService = service ?? throw new ArgumentNullException(nameof(service));
        }

        public string GetEquipmentData()
        {
            return dataService.GetEquipmentData();
        }

        public string GetHistoryData()
        {
            return dataService.GetHistoryData();
        }

        public void SetEquipmentData(EquipmentItem equip)
        {
            dataService.SetEquipmentData(equip);
        }

        public void SetHistoryData(string data)
        {
            dataService.SetHistoryData(data);
        }

        public void ReplaceEquipmentData(string newData)
        {
            dataService.ReplaceEquipmentData(newData);
        }
    }
}
