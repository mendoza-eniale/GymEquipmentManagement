using GEMDataAccess;

namespace GEMBusinessLogic
{
    public class Service
    {
        private GEMEquipStorage storage;

        public Service()
        {
            //storage = new GEMEquipStorage(new InMemoryDataService());
             storage = new GEMEquipStorage(new TextFileDataService());
            // storage = new GEMEquipStorage(new JsonFileDataService());
        }

        public GEMEquipStorage GetStorage() => storage;
    }
}
