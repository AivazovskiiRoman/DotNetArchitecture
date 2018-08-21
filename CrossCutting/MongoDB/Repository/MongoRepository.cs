using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Solution.CrossCutting.Utils;

namespace Solution.CrossCutting.MongoDB
{
    public abstract class MongoRepository<T> : IRepository<T> where T : class
    {
        protected MongoRepository(IMongoContext context)
        {
            Database = context.Database;
            Collection = Database.GetCollection<T>(typeof(T).Name);
        }

        private IMongoCollection<T> Collection { get; }

        private IMongoDatabase Database { get; }

        public void Add(T item)
        {
            Collection.InsertOne(item);
        }

        public Task AddAsync(T item)
        {
            return Collection.InsertOneAsync(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            Collection.InsertMany(items);
        }

        public Task AddRangeAsync(IEnumerable<T> items)
        {
            return Collection.InsertManyAsync(items);
        }

        public bool Any()
        {
            return Collection.Find(new BsonDocument()).Any();
        }

        public bool Any(Expression<Func<T, bool>> where)
        {
            return Collection.Find(where).Any();
        }

        public Task<bool> AnyAsync()
        {
            return Collection.Find(new BsonDocument()).AnyAsync();
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> where)
        {
            return Collection.Find(where).AnyAsync();
        }

        public long Count()
        {
            return Collection.CountDocuments(new BsonDocument());
        }

        public long Count(Expression<Func<T, bool>> where)
        {
            return Collection.CountDocuments(where);
        }

        public Task<long> CountAsync()
        {
            return Collection.CountDocumentsAsync(new BsonDocument());
        }

        public Task<long> CountAsync(Expression<Func<T, bool>> where)
        {
            return Collection.CountDocumentsAsync(where);
        }

        public void Delete(object key)
        {
            Collection.DeleteOne(FilterId(key));
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            Collection.DeleteMany(where);
        }

        public Task DeleteAsync(object key)
        {
            return Collection.DeleteOneAsync(FilterId(key));
        }

        public Task DeleteAsync(Expression<Func<T, bool>> where)
        {
            return Collection.DeleteManyAsync(where);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> where)
        {
            return Collection.Find(where).FirstOrDefault();
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where)
        {
            return Collection.Find(where).FirstOrDefaultAsync();
        }

        public IEnumerable<T> List()
        {
            return Collection.Find(new BsonDocument()).ToList();
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> where)
        {
            return Collection.Find(where).ToList();
        }

        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where)
        {
            return await Collection.Find(where).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> ListAsync()
        {
            return await Collection.Find(new BsonDocument()).ToListAsync().ConfigureAwait(false);
        }

        public T Select(object key)
        {
            return Collection.Find(FilterId(key)).SingleOrDefault();
        }

        public Task<T> SelectAsync(object key)
        {
            return Collection.Find(FilterId(key)).SingleOrDefaultAsync();
        }

        public T SingleOrDefault(Expression<Func<T, bool>> where)
        {
            return Collection.Find(where).SingleOrDefault();
        }

        public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where)
        {
            return Collection.Find(where).SingleOrDefaultAsync();
        }

        public void Update(T item, object key)
        {
            Collection.ReplaceOne(FilterId(key), item);
        }

        public Task UpdateAsync(T item, object key)
        {
            return Collection.ReplaceOneAsync(FilterId(key), item);
        }

        private static FilterDefinition<T> FilterId(object key)
        {
            return Builders<T>.Filter.Eq("Id", key);
        }
    }
}
