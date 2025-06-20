using GEMDataAccess;
namespace GEMBusinessLogic
{
    public class Service
    {
        private readonly GEMEquipStorage storage;
        public Service()
        {
            // Initialize with the appropriate data service
            storage = new GEMEquipStorage(new TextFileDataService());
            // storage = new GEMEquipStorage(new JsonFileDataService());
        }
        public GEMEquipStorage GetStorage() => storage;
    }
}