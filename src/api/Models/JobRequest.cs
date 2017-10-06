using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JobScheduler.Api.Models
{
    public enum ContactMethond { Phone = 1, Email = 2 };

    public class JobRequest
    {
        public ObjectId Id { get; set; }
        [BsonElement("jobNumber")]
        public string JobNumber { get; set; }
        [BsonElement("company")]
        public string Company { get; set; }
        [BsonElement("firstName")]
        public string FirstName { get; set; }
        [BsonElement("middleInitial")]
        public string MiddleInitial { get; set; }
        [BsonElement("lastName")]
        public string LastName { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("phoneNumber")]
        public string PhoneNumber { get; set; }
        [BsonElement("preferredContactMethod")]
        public ContactMethond PreferredContactMethod { get; set; }
        [BsonElement("comments")]
        public string Comments { get; set; }
        [BsonElement("inspectionRequests")]
        public ICollection<InspectionRequest> InspectionRequests { get; set; }
    }

    public class InspectionRequest
    {
        [BsonElement("inspection")]
        public string Inspection { get; set; }
        [BsonElement("classification")]
        public ObjectId Classification { get; set; }
        [BsonElement("preferredDateTime")]
        public DateTime PreferredDateTime { get; set; }
        [BsonElement("alternativeDateTime")]
        public DateTime AlternativeDateTime { get; set; }
    }

    public class JobRequestDto
    {
        public string Id { get; set; }
        public string JobNumber { get; set; }
        public string Company { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ContactMethond PreferredContactMethod { get; set; }
        public string Comments { get; set; }
        public ICollection<InspectionRequestDto> InspectionRequests { get; set; }
    }

    public class InspectionRequestDto
    {
        public string Inspection { get; set; }
        public string Classification { get; set; }
        public DateTime PreferredDateTime { get; set; }
        public DateTime AlternativeDateTime { get; set; }
    }
}
