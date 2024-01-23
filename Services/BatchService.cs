﻿using System.Xml.Linq;
using ZetechWebAPI.Models;

namespace ZetechWebAPI.Services
{
    public class BatchService: IBatchService
    {
        private readonly ZetechDbContext _dbContext;
        public List<Batch> Batches { get; }
        public BatchService(ZetechDbContext dbContext)
        {
            _dbContext = dbContext;
            Batches = _dbContext.Batch.ToList();
        }

        public List<Batch> GetAll() => Batches;

        public Batch? Get(int id) => Batches.FirstOrDefault(p => p.BatchId == id);

        public void Add(Batch batch)
        {
            Batches.Add(batch);
        }

        public void Delete(Batch batch)
        {
            _dbContext.Batch.Remove(batch);

            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return;
            }
        }

        public void Update(Batch batch)
        {
            var index = Batches.FindIndex(p => p.BatchId == batch.BatchId);
            if (index == -1)
                return;

            Batches[index] = batch;
        }
    }
}
