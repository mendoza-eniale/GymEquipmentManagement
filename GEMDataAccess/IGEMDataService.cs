using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
