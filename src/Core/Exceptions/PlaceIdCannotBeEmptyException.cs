using Tickmill.Common.Types;

namespace Tickmill.Integrations.Google.Core.Exceptions
{
    internal sealed class PlaceIdCannotBeEmptyException : CustomException
    {
        public PlaceIdCannotBeEmptyException() : base("PlaceId cannot be empty!")
        { }
    }
}
