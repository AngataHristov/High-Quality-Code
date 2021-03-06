﻿namespace HotelBookingSystem.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    public class Repository<T> : IRepository<T> where T : IDbEntity
    {
        private int nextAddId = 1;
        private Dictionary<int, T> items;

        public Repository()
        {
            this.items = new Dictionary<int, T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.items
                .OrderBy(item => item.Key)
                .Select(item => item.Value);
        }

        public virtual T Get(int id)
        {
            T item;
            try
            {
                item = this.items[id];
            }
            catch (KeyNotFoundException)
            {
                item = default(T);
            }

            return item;
        }

        public virtual void Add(T item)
        {
            item.Id = this.nextAddId;
            this.items.Add(this.nextAddId, item);
            this.nextAddId++;
        }
    }
}