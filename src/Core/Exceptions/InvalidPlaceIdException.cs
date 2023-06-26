using Tickmill.Common.Types;

namespace Tickmill.Integrations.Google.Core.Exceptions
{
    internal sealed class InvalidPlaceIdException : CustomException
    {
        public InvalidPlaceIdException(string details) : base($"PlaceId is not valid: {details}")
        { }
    }
}
