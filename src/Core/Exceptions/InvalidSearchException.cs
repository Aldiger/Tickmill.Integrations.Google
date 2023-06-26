using Tickmill.Common.Types;

namespace Tickmill.Integrations.Google.Core.Exceptions
{
    internal sealed class InvalidSearchException : CustomException
    {
        public InvalidSearchException(string details) : base($"Search text is not valid: {details}") 
        { }
    }
}
