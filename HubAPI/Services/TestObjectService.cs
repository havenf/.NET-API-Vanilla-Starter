using HubAPI.Models;
using HubAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HubAPI.Services
{
    public class TestObjectService
    {
        private readonly TestObjectRepository _tOR;
        public TestObjectService(TestObjectRepository tOR)
        {
            _tOR = tOR;
        }
        internal TestObjectModel CreateTestObject(TestObjectModel TestObjectData)
        {
            return _tOR.CreateTestObject(TestObjectData);
        }

        internal List<TestObjectModel> GetAllTestObjects()
        {
            return _tOR.GetAllTestObjects();
        }

        internal ActionResult<string> RemoveTestObject(int id)
        {
            return _tOR.RemoveTestObject(id);
        }

        internal TestObjectModel GetTestObjectpById(int id)
        {
            TestObjectModel found = _tOR.GetTestObjectById(id);
            if (found == null)
            {
                throw new Exception("Server Error: No object to delete with provided ID");
            }
            return found;
        }
    }
}
