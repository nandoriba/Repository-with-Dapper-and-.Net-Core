using System;

namespace RepositoryWithDapperAnd.NetCore.Models
{
    public class Address : Entity
    {
        public Guid BuyerId { get; set; }
        public string Street { get; set; }        
        public string Complement { get; set; }
        public string ZipCode { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }     

    }
}

