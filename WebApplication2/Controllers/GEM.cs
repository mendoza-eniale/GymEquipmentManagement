using GEMBusinessLogic;
using GEMCommon;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{

    namespace GEM
    {
        [Route("api/[controller]")]
        [ApiController]
        public class EquipmentController : ControllerBase
        {
            GEMActions actions = new GEMActions();

            [HttpGet]
            public string GetEquipmentList()
            {
                return actions.ViewEquipmentList();
            }

            [HttpGet("{id}")]
            public string GetEquipmentById(int id)
            {
                return actions.SearchEquipment(id);
            }

            [HttpGet("history")]
            public string GetHistory()
            {
                return actions.ViewHistory();
            }

            [HttpPost]
            public IActionResult AddEquipment(EquipmentItem item)
            {
                actions.AddEquipment(item.Name, item.Status, item.Quantity);
                return Ok(true);
            }

            [HttpPatch("{id}")]
            public IActionResult UpdateEquipment(int id, EquipmentItem item)
            {
                actions.UpdateEquipment(id, item.Name, item.Status, item.Quantity);
                return Ok(true);
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteEquipment(int id)
            {
                bool result = actions.DeleteEquipment(id);
                if (!result)
                    return NotFound($"Equipment ID {id} not found.");
                return Ok(true);
            }
        }
    }
}
