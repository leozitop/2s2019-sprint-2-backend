using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufos.WebApi.Domains
{
    public class Localizacoes
    {
        // binary json
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        // caso eu queira alterar o nome da chave no banco
        [BsonElement("latitude")]
        [BsonRequired]
        public string Latitude { get; set; }
        [BsonRequired]
        public string Longitude { get; set; }
    }
}
