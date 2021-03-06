﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace SMS_Sender.MessageHandler
{
    public class APIKeyMessageHandler : DelegatingHandler
    {
        private const string APIKeyToCheck = "PassKeyF12";

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage, CancellationToken cancellationToken)
        {

            bool validKey = false;
            IEnumerable<string> requestHeaders;

            var checkApiKeyExists = httpRequestMessage.Headers.TryGetValues("APIKey", out requestHeaders);

            if (checkApiKeyExists)
            {

                if (requestHeaders.FirstOrDefault().Equals(APIKeyToCheck))
                {

                    validKey = true;
                
                }
            }
                if (!validKey)
                {


                    return httpRequestMessage.CreateResponse(HttpStatusCode.Forbidden, "Invalid API Key");
                }

                var response = await base.SendAsync(httpRequestMessage, cancellationToken);
                return response;
        
        }
    }
}