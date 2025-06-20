using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEMDataAccess
{
    public interface IGEMDataService
    {
        public string GetEquipmentData();
        public string GetHistoryData();
        public void SetEquipmentData(string data);
        public void SetHistoryData(string data);
        public void ReplaceEquipmentData(string newData);
        // condition na dapaat lahat ng nanditong method makikita sa bl and dl
    }
}