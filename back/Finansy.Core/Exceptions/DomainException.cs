using System.Runtime.Serialization;

namespace Finansy.Core.Exceptions;

[Serializable]
public class DomainException : Exception
{
    public DomainException(string message) : base(message){}
    
    protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context){}
}