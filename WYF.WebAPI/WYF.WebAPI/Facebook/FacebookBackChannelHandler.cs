using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WYF.WebAPI.Facebook
{
    public class FacebookBackChannelHandler : HttpClientHandler
    {
        // Overriding SendAsync of HttpClientHandler to handles Facebook API version 2.4
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!request.RequestUri.AbsolutePath.Contains("/oauth"))
            {
                request.RequestUri = new Uri(request.RequestUri.AbsolutePath.Replace("?access_token", "&access_token"));
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}