using Dapper;
using HubAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HubAPI.Repositories
{
    public class TestObjectRepository
    {
        private readonly IDbConnection _db;

        public TestObjectRepository(IDbConnection db)
        {
            _db = db;
        }
        internal TestObjectModel CreateTestObject(TestObjectModel testObjectData)
        {
            string sql = @"
            INSERT INTO TestObjects
            (name, description, img)
            VALUES
            (@Name, @Description, @Img);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, testObjectData);
            testObjectData.Id = id;
            return testObjectData;
        }

        internal List<TestObjectModel> GetAllTestObjects()
        {
            string sql = @"
            SELECT
            *
            FROM
            TestObjects;
            ";
            return _db.Query<TestObjectModel>(sql).ToList();
        }

        internal TestObjectModel GetTestObjectById(int id)
        {
            string sql = @"
            SELECT
            *
            FROM
            TestObjects
            WHERE
            id = @id;
            ";
            TestObjectModel result = _db.QueryFirstOrDefault<TestObjectModel>(sql, new { id });
            if(result == null)
            {
                throw new Exception("No TestObject found with the specified id.");
            }
            return result;
        }

        internal ActionResult<string> RemoveTestObject(int id)
        {
            string sql = @"
            DELETE FROM
            TestObjects
            WHERE
            id = @id
            LIMIT
            1;
            ";
            int rowsAffected = _db.Execute(sql, new { id });
            if (rowsAffected > 0)
            {
                return "Successful deletion";
            }
            throw new Exception("sql error when attempting to remove");
        }
    }
}
