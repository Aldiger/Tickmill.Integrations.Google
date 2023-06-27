using Tickmill.Common.Types;

namespace Tickmill.Integrations.Google.Core.Exceptions
{
    internal sealed class ServiceApiException : CustomException
    {
        public ServiceApiException(string error) : base($"Service's API has thrown an exception: {error}")
        {
        }
    }
}
