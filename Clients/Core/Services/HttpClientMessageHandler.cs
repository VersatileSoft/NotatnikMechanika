using Autofac;
using MvvmPackage.Core;
using NotatnikMechanika.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NotatnikMechanika.Core.Services
{
    public class HttpClientMessageHandler : DelegatingHandler
    {
        public HttpClientMessageHandler()
        {
            InnerHandler = new HttpClientHandler();
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            if(response.StatusCode == HttpStatusCode.Unauthorized)
            {
                await IoC.Container.Resolve<IAuthService>().AuthorizeAsync();

                response = await base.SendAsync(request, cancellationToken);
            }

            return response;
        }
    }
}
