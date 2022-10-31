﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OrderWebApi.Models
{
    [Serializable, BsonIgnoreExtraElements]
    public class OrderDetail
    {
        [BsonId, BsonElement("product_id"), BsonRepresentation(BsonType.Int32)]
        public int ProductId { get; set; }

        [BsonId, BsonElement("quantity"), BsonRepresentation(BsonType.Decimal128)]
        public decimal Quantity { get; set; }

        [BsonId, BsonElement("unity_price"), BsonRepresentation(BsonType.Decimal128)]
        public decimal UnitPrice { get; set; }
    }
}
