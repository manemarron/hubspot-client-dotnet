//-----------------------------------------------------------------------
// <copyright file="HttpClientExtensions.cs" company="Jose Manuel Marron Ruiz">
//     Copyright (c) Jose Manuel Marron Ruiz. All rights reserved.
//     Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------
namespace HubspotClientDotnet.HttpClient.Extensions
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines extensions for HttpClient.
    /// </summary>
    internal static class HttpClientExtensions
    {
        /// <summary>
        /// Logs request data, sends http request, logs response data and returns response.
        /// </summary>
        /// <param name="httpClient">Instance of <see cref="HttpClient" />.</param>
        /// <param name="request">Instance of <see cref="HttpRequestMessage" />.</param>
        /// <param name="logger">Instance of <see cref="ILogger" />.</param>
        /// <param name="cancellationToken">Instance of <see cref="CancellationToken" />.</param>
        /// <returns>A task that resolves to a <see cref="HttpResponseMessage" /> object.</returns>
        internal static async Task<HttpResponseMessage> SendAndLogAsync(
            this HttpClient httpClient,
            HttpRequestMessage request,
            ILogger logger,
            CancellationToken cancellationToken)
        {
            await request.Content.LoadIntoBufferAsync();
            await LogRequest(logger, request);
            var response = await httpClient.SendAsync(request, cancellationToken);
            await response.Content.LoadIntoBufferAsync();
            await LogResponse(logger, response);
            return response;
        }

        /// <summary>
        /// Builds the request uri from the base address in the HttpClient and the relative uri for the request.
        /// </summary>
        /// <param name="httpClient">Instance of <see cref="HttpClient" />.</param>
        /// <param name="relativeUri">The relative part of the uri. Includes path, query, and fragment.</param>
        /// <returns>The request uri.</returns>
        internal static Uri GenerateRequestUri(this HttpClient httpClient, Uri relativeUri)
        {
            EnsureUriIsRelative(relativeUri);
            var requestUriBuilder = new UriBuilder(new Uri(httpClient.BaseAddress, relativeUri));
            requestUriBuilder.Query += !string.IsNullOrEmpty(httpClient.BaseAddress.Query)
                ? $"&{httpClient.BaseAddress.Query.Substring(1)}"
                : string.Empty;
            return requestUriBuilder.Uri;
        }

        private static void EnsureUriIsRelative(Uri uri)
        {
            if (uri is null || uri.IsAbsoluteUri)
            {
                throw new Exception("Uri must be relative");
            }
        }

        private static async Task LogRequest(
            ILogger logger,
            HttpRequestMessage request)
        {
            logger?.Log<object>(
                LogLevel.Debug,
                (EventId)8875,
                new
                {
                    message = "Sending request to hubspot",
                    body = await request.Content.ReadAsStringAsync(),
                    headers = request.Headers,
                    method = request.Method,
                    requestUri = request.RequestUri,
                },
                null,
                (log, ex) => JsonConvert.SerializeObject(log));
        }

        private static async Task LogResponse(
            ILogger logger,
            HttpResponseMessage response)
        {
            logger?.Log<object>(
                LogLevel.Debug,
                (EventId)8876,
                new
                {
                    message = "Received response from hubspot",
                    body = await response.Content.ReadAsStringAsync(),
                    headers = response.Headers,
                    statusCode = response.StatusCode,
                },
                null,
                (log, ex) => JsonConvert.SerializeObject(log));
        }
    }
}