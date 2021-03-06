﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Digipolis.Correlation
{
    public static class HttpClientExtensions
    {
        public static void SetCorrelationValues(this HttpClient client, ICorrelationContext context)
        {
            if (context == null) throw new NullReferenceException($"{nameof(context)} cannot be null.");

            client.DefaultRequestHeaders.Add(context.IdHeaderKey, context.Id.ToString());
            client.DefaultRequestHeaders.Add(context.SourceHeaderKey, context.SourceId);
        }

        public static void SetCorrelationValues(this HttpClient client, IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ICorrelationContext>();

            SetCorrelationValues(client, context);
        }
    }
}
