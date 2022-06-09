using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SignLanguage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignLanguage.Models;

namespace SignLanguage.Services
{
    public class TextService
    {
        private readonly IMongoCollection<Text> _texts;

        //public IConfiguration configuration;

        public TextService()
        {
            //var client = new MongoClient(settings.ConnectionStrings);
            //var database = client.GetDatabase(settings.DatabaseName);

            //_texts = database.GetCollection<Text>(settings.TextCollectionName);
            //this.configuration = configuration;
            //TextDatabasesetting c = new TextDatabasesetting(); 
            //c= (TextDatabasesetting)(configuration.GetSection(nameof(TextDatabasesetting)));
            var client = new MongoClient("mongodb://srv1:27017");
            var database = client.GetDatabase("213396179");
            _texts = database.GetCollection<Text>("Text");
        }


        public List<Text> Get()
        {
            int categoryId = 1;
            //await SignLanguageDBContext.Words.Where(w => w.CategoryId == categoryId).ToListAsync();
            List<Text> texts;
            texts = _texts.Find(txt => true).ToList();
            return texts;

        }

        public List<Text> Get(int categoryId)
        {
            return _texts.Find<Text>(txt => txt.CategoryId == categoryId).ToList();

        }
    }
}
