using System;
using System.Collections.Generic;
using System.Threading;

class SimpleCache
{
    private Dictionary<string, (object value, DateTime expiry)> cache = new Dictionary<string, (object, DateTime)>();
    private TimeSpan ttl;

    public SimpleCache(TimeSpan ttl)
    {
        this.ttl = ttl;
    }

    public object Get(string key)
    {
        if (cache.ContainsKey(key))
        {
            (object value, DateTime expiry) = cache[key];
            if (expiry > DateTime.Now)
            {
                return value;
            }
            else
            {
                // TTL이 만료되었으므로 캐시에서 항목 제거
                cache.Remove(key);
            }
        }
        return null;
    }

    public void Set(string key, object value)
    {
        DateTime expiry = DateTime.Now.Add(ttl);
        cache[key] = (value, expiry);
    }
}

class Program
{
    static void Main(string[] args)
    {
        SimpleCache cache = new SimpleCache(TimeSpan.FromSeconds(5));

        // 캐시에 데이터 저장
        cache.Set("key1", "value1");
        Console.WriteLine("key1 저장됨");

        // 캐시에서 데이터 조회
        Thread.Sleep(3000); // 3초 대기
        Console.WriteLine($"key1 조회: {cache.Get("key1")}");

        // TTL 후 데이터 조회
        Thread.Sleep(3000); // 추가 3초 대기 (총 6초)
        Console.WriteLine($"key1 조회 (TTL 후): {cache.Get("key1")}");
        
        // 결과
        // key1 저장됨
        // key1 조회: value1
        // key1 조회 (TTL 후): 
    }
}