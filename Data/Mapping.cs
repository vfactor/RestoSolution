using Google.Protobuf;

namespace Data
{
    public abstract class AbstractMap<T> where T : IMessage<T>, new()
    {
        public virtual T ToInformation() => throw new NotImplementedException();
        public virtual T ToInformation(CollectionMapper maapers) => maapers.Get<T>().Parse<T>(this);
        void FromInformation(T information) => throw new NotImplementedException();
    }

    public sealed class Mapper
    {
        private Dictionary<int, string>? _map = null;

        private T Build<T>(object source) where T : IMessage<T>, new() {
            var retT = new T();
            var desc = retT.Descriptor;

            var map = new Dictionary<int, string>();

            foreach (var pi in source.GetType().GetProperties())
            {
                var fd = desc.FindFieldByName(pi.Name);
                if (fd != null)
                {
                    fd.Accessor.SetValue(retT, source.GetPropertyVAlue(pi));
                    map.Add(fd.FieldNumber, pi.Name);
                }
            }

            _map ??= map;

            return retT;
        }
        private T Map<T>(object source) where T : IMessage<T>, new() {
            
            var retT = new T();
            var sType = source.GetType();

            foreach (var fm in _map)
            {
                var fd = retT.Descriptor.FindFieldByNumber(fm.Key);
                var pi = sType.GetProperty(fm.Value);
                fd.Accessor.SetValue(retT, source.GetPropertyVAlue(pi));
            }

            return retT;
        }
        public T Parse<T>(object source) where T : IMessage<T>, new() => (_map == null) ? Build<T>(source) : Map<T>(source);
    }
    public sealed class CollectionMapper
    {
        private readonly Dictionary<int, Mapper> _mappers = [];
        public Mapper Get<T>() where T : IMessage<T>, new()
        {
            var key = typeof(T).GetHashCode();

            if (_mappers.TryGetValue(key, out var mapper))
                return mapper;

            mapper = new Mapper();
            if (_mappers.TryAdd(key, mapper))
                return mapper;

            return Get<T>();
        }
    }
}
