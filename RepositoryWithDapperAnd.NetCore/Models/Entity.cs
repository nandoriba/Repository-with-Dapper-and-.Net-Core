using System;

namespace RepositoryWithDapperAnd.NetCore.Models
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id
        {
            get { return _id; }
            set
            {
                if (Guid.Empty == value)
                    _id = Guid.NewGuid();
                else _id = value;
            }
        }

        private Guid _id;
    }
}

