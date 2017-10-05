using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace JobScheduler.Api.Models
{
    public class Classification 
    {
        public ObjectId Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("isactive")]
        public bool IsActive { get; set; }
        [BsonElement("inspections")]
        public ICollection<string> Inspections { get; set; }
    }

    public class ClassificationDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        [JsonProperty(PropertyName = "isactive")]
        public bool IsActive { get; set; }
        public ICollection<string> Inspections { get; set; }
    }
}