using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Daekage_Server.Models;
using MongoDB.Driver;

namespace Daekage_Server.Services
{
    public class AuthService
    {
        private readonly IMongoCollection<Teacher> _teachers;

        public AuthService(IDaekageDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _teachers = database.GetCollection<Teacher>(settings.AuthCollectionName);
        }

        public Teacher Get(string email) =>
            _teachers.Find(teacher => teacher.Email == email).FirstOrDefault();

        public Teacher Create(Teacher teacher)
        {
            _teachers.InsertOne(teacher);
            return teacher;
        }
    }
}
