<<<<<<< Updated upstream
﻿

using GEMDataAccess;

namespace GEMBusinessLogic
{
    public class Service
    {
        private readonly GEMEquipStorage storage;

        public Service()
        {
            storage = new GEMEquipStorage(new TextFileDataService());
            // storage = new GEMEquipStorage(new InMemoryDataService());
            // storage = new GEMEquipStorage(new JsonFileDataService());

        }
        public GEMEquipStorage GetStorage()
        {
            return storage;
        }

    }
=======
﻿

using GEMDataAccess;

namespace GEMBusinessLogic
{
    public class Service
    {
        private readonly GEMEquipStorage storage;

        public Service()
        {
            storage = new GEMEquipStorage(new TextFileDataService());
            // storage = new GEMEquipStorage(new InMemoryDataService());
            // storage = new GEMEquipStorage(new JsonFileDataService());

        }
        public GEMEquipStorage GetStorage()
        {
            return storage;
        }

    }
>>>>>>> Stashed changes
}