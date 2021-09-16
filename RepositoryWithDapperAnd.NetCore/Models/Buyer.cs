namespace RepositoryWithDapperAnd.NetCore.Models
{
    public class Buyer : Entity
    {
        public Buyer()
        {
        }
        public string Name { get; set; }
        public string Document { get; set; }
        public EBuyerType BuyerType { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }       
    }
}

