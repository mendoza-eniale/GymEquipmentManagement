using GEMDataAccess;
using System;

namespace GEMBusinessLogic
{
    public class Service
    {
        private GEMEquipStorage storage;

        public Service()
        {
            storage = new GEMEquipStorage();
        }

        public GEMEquipStorage GetStorage()
        {
            return storage;
        }
    }
}
