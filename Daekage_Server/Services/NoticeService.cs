using System.Collections.Generic;
using Daekage_Server.Models;
using MongoDB.Driver;

namespace Daekage_Server.Services
{
    public class NoticeService
    {
        private readonly IMongoCollection<Notice> _notices;

        public NoticeService(IDaekageDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _notices = database.GetCollection<Notice>(settings.NoticesCollectionName);
        }

        public List<Notice> Get() => _notices.Find(notice => true).ToList();

        public Notice Get(string id) =>
            _notices.Find(notice => notice.Id == id).FirstOrDefault();

        public Notice Create(Notice notice)
        {
            _notices.InsertOne(notice);
            return notice;
        }

        public void Update(string id, Notice noticeIn) =>
            _notices.ReplaceOne(notice => notice.Id == id, noticeIn);

        public void Remove(string id) =>
            _notices.DeleteOne(notice => notice.Id == id);
    }
}
