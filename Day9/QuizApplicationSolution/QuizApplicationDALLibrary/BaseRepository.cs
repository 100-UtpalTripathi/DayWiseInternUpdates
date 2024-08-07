﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplicationDALLibrary
{
    public class BaseRepository<T> : IRepository<T> where T : class

    {
        protected readonly Dictionary<int, T> _data;

        public BaseRepository()
        {
            _data = new Dictionary<int, T>();
        }

        private int GetNextId()
        {
            if (_data.Count == 0)
                return 1;
            int maxKey = _data.Keys.Max();
            return maxKey + 1;
        }
        public virtual T Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            dynamic dynamicEntity = entity;
            int id = dynamicEntity.Id;
            if (_data.ContainsKey(id))
            {
                return null;
            }
            int newId = GetNextId();
            dynamicEntity.Id = newId;
            _data.Add(newId, dynamicEntity);
            return dynamicEntity;
        }

        public virtual T Delete(int id)
        {
            if (_data.ContainsKey(id))
            {
                T item = _data[id];
                _data.Remove(id);
                return item;
            }
            return null;
        }

        public virtual T Get(int key)
        {
            return _data.ContainsKey(key) ? _data[key] : null;
        }

        public virtual List<T> GetAll()
        {
            return _data.Values.ToList();
        }
        public T Update(int id, T updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ArgumentNullException(nameof(updatedEntity));
            }

            if (_data.ContainsKey(id))
            {
                _data[id] = updatedEntity;
                return _data[id];
            }
            else
            {
                return null;
            }
        }
    }
}
