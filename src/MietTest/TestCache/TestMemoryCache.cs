using DbLayer.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MietTest.TestCache
{
    public class TestMemoryCache : ITestCache
    {
        private ConcurrentDictionary<Guid, CacheValueModel> _dictionary = new ConcurrentDictionary<Guid, CacheValueModel>();

        public Guid StartNewTest(string userName, int id)
        {
            Guid guid = Guid.NewGuid();
            bool res = _dictionary.TryAdd(guid, new CacheValueModel { UserName = userName, Test = new TestResult { Start = DateTime.Now, TestId = id } });
            if (res == false) throw new Exception("cache start new exception");
            return guid;
        }

        public TestResult UpdateTest(Guid guid, string userName, TestResult test)
        {
            CacheValueModel value;
            bool res = _dictionary.TryGetValue(guid, out value);
            if (value.UserName != userName || res == false) throw new Exception("cache update exception");
            _dictionary.AddOrUpdate(guid, new CacheValueModel { UserName = userName, Test = test }, (key, val) => { return new CacheValueModel { UserName = userName, Test = test }; });
            if (res == false) throw new Exception("cache update exception");
            return test;
        }

        public TestResult GetTest(Guid guid, string userName)
        {
            CacheValueModel value;
            bool res = _dictionary.TryGetValue(guid, out value);
            if (value.UserName != userName || res == false) throw new Exception("cache get exception");
            return value.Test;
        }


        public TestGuidModel[] GetTests(string userName)
        {
            return _dictionary
                .Where(p => p.Value.UserName == userName)
                .Select(p => new TestGuidModel { Guid = p.Key, Test = p.Value.Test })
                .ToArray();
        }


        public void Remove(Guid guid)
        {
            CacheValueModel toRemove = null;
            bool res = _dictionary.TryRemove(guid, out toRemove);
            if(res == false)
            {
                throw new InvalidOperationException("Не удалось удалить результат теста в кэше");
            }
        }
    }
}