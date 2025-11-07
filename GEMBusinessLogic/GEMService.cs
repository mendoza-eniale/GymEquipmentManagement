using GEMCommon;
using GEMDataAccess;

namespace GEMBusinessLogic
{
    public class GEMService
    {
        private readonly GEMEquipStorage storage;

        public GEMService()
        {
            //storage = new GEMEquipStorage(new DBDataService());
            //storage = new GEMEquipStorage(new InMemoryDataService());
            // storage = new GEMEquipStorage(new TextFileDataService());
            // storage = new GEMEquipStorage(new JsonFileDataService());
             storage = new GEMEquipStorage(new DBDataService());
        }
        

        public GEMEquipStorage GetStorage()
        {
            return storage;
        }
    }
}
