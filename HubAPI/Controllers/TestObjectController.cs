using HubAPI.Models;
using HubAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HubAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestObjectController : ControllerBase
    {
        private readonly TestObjectService _tOS;

        public TestObjectController(TestObjectService tOS)
        {
            _tOS = tOS;
        }

        [HttpGet]
        public ActionResult<List<TestObjectModel>> GetAllTestObjects()
        {
            try
            {
                List<TestObjectModel> TestObjects = _tOS.GetAllTestObjects();
                return Ok(TestObjects);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<List<TestObjectModel>> CreateTestObject([FromBody] TestObjectModel TestObjectData)
        {
            try
            {
                TestObjectModel TestObject = _tOS.CreateTestObject(TestObjectData);
                return Ok(TestObject);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<string> RemoveTestObject(int id) 
        {
            try
            {
                return _tOS.RemoveTestObject(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
