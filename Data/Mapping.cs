using Google.Protobuf;
using Google.Protobuf.Reflection;
using System.Reflection;

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
            
            FieldDescriptor fd;

            foreach (var pi in source.GetType().GetProperties())
            {
                fd = desc.FindFieldByName(pi.Name);
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

            FieldDescriptor? fd;
            PropertyInfo pi;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            foreach (var fm in _map)
            {
                fd = retT.Descriptor.FindFieldByNumber(fm.Key) ?? throw new InvalidOperationException($"Field with number {fm.Key} not found.");
                pi = sType.GetProperty(fm.Value) ?? throw new InvalidOperationException($"Property with name {fm.Value} not found.");
                
                fd.Accessor.SetValue(retT, source.GetPropertyVAlue(pi));
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

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
