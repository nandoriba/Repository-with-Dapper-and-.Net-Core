using System;

namespace RepositoryWithDapperAnd.NetCore.Models
{
    public class Product : Entity
    {
        public Guid BuyerId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal value { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Active { get; set; }
    }
}

