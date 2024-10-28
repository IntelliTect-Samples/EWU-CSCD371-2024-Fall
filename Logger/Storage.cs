﻿namespace Logger;
    public class Storage
    {
        private HashSet<IEntity> Entities { get; } = new();
        
        public void Add(IEntity item)
        {
            Entities.Add(item);
        }

        public void Remove(IEntity item)
        {
            Entities.Remove(item);
        }

        public bool Contains(IEntity item)
        {
            return Entities.Contains(item);
        }
        
        public IEntity? Get(Guid expectedGuid)
        {
            // Using dynamic to access Id
            return Entities.FirstOrDefault(entity => ((dynamic)entity).Id == expectedGuid);
        }
    }
