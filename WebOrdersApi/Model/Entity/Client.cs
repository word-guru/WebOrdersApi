﻿using System.Text.Json.Serialization;

namespace WebOrdersApi.Model.Entity
{
    public class Client
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [JsonIgnore]
        public ICollection<Order>? Orders { get; set; }

        public Client() { }
        public Client(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}
