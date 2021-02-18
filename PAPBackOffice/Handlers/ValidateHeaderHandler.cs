using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using PAPBackOffice.Data.Entities;

namespace PAPBackOffice.Handlers
{
    public class ValidateHeaderHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!request.Headers.Contains("Authorization"))
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
