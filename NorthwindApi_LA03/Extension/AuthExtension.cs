using Microsoft.AspNetCore.Authentication;
using NorthwindApi_LA03.Auth;

namespace NorthwindApi_LA03.Extension
{
    public static class AuthExtension
    {
        public static AuthenticationBuilder ApiKeySupport(this AuthenticationBuilder builder,
            Action<ApiKeyAuthenticationOptions> options)
        {
            return builder.AddScheme<ApiKeyAuthenticationOptions, ApiKeyAuthenticationHandler>(
                ApiKeyAuthenticationOptions.DefaultScheme, options
                );
        }
    }
}
