using Google.Protobuf;

namespace Data
{
    public interface IMap<T> where T : IMessage<T>
    {
        T ToInformation() => throw new NotImplementedException();
        void FromInformation(T information) => throw new NotImplementedException();
    }
}
