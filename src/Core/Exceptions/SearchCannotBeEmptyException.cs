using Tickmill.Common.Types;

namespace Tickmill.Integrations.Google.Core.Exceptions
{
    internal sealed class SearchCannotBeEmptyException : CustomException
    {
        public SearchCannotBeEmptyException() : base("Search text cannot be empty!")
        { }
    }
}
