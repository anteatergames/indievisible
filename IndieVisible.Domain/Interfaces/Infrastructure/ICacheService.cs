namespace IndieVisible.Domain.Interfaces.Infrastructure
{
    public interface ICacheService
    {
        string Get(string key);

        T Get<TKey, T>(TKey key);

        T Get<T>(string key);

        void Set(string key, string value);

        void Set<T>(string key, T value);

        void Set<Tkey, T>(Tkey key, T value);

        string GetOrCreate(string key, string value);

        T GetOrCreate<T>(string key, T value);
    }
}