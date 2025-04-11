using GEMDataAccess;
using System;

namespace GEMBusinessLogic
{
    public class Service
    {
        private EquipStorage storage;

        public Service()
        {
            storage = new EquipStorage();
        }

        public EquipStorage GetStorage()
        {
            return storage;
        }
    }
}
