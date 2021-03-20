//-----------------------------------------------------------------------
// <copyright file="RequestMappersV3.cs" company="Jose Manuel Marron Ruiz">
//     Copyright (c) Jose Manuel Marron Ruiz. All rights reserved.
//     Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------
namespace HubspotClientDotnet.HttpClient.V3.Contacts.Mappers
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using HubspotClientDotnet.Core.Contacts.Models;
    using HubspotClientDotnet.HttpClient.Extensions;
    using Newtonsoft.Json;

    /// <summary>
    /// Implements mappers to HttpRequestMessage.
    /// </summary>
    internal static class RequestMappersV3
    {
        private const string BasePath = "/crm/v3/objects/contacts";

        /// <summary>
        /// Maps a ContactCreateRequest to HttpRequestMessage.
        /// </summary>
        /// <param name="request">Instance of <see cref="ContactCreateRequest" />.</param>
        /// <param name="httpClient">Instance of <see cref="HttpClient" />.</param>
        /// <returns>A <see cref="HttpRequestMessage" /> object.</returns>
        internal static HttpRequestMessage MapToHttpRequestMessage(
            this ContactCreateRequest request,
            HttpClient httpClient)
        {
            var method = HttpMethod.Post;
            var requestUri = new Uri(BasePath, UriKind.Relative);
            var body = new { properties = request.Properties };
            return GenerateRequestMessage(
                httpClient.GenerateRequestUri(requestUri),
                method,
                body);
        }

        /// <summary>
        /// Maps a ContactFindByEmailRequest to HttpRequestMessage.
        /// </summary>
        /// <param name="request">Instance of <see cref="ContactFindByEmailRequest" />.</param>
        /// <param name="httpClient">Instance of <see cref="HttpClient" />.</param>
        /// <returns>A <see cref="HttpRequestMessage" /> object.</returns>
        internal static HttpRequestMessage MapToHttpRequestMessage(
            this ContactFindByEmailRequest request,
            HttpClient httpClient)
        {
            var path = $"{BasePath}/search";
            var method = HttpMethod.Post;
            var requestUri = new Uri(path, UriKind.Relative);
            var filters = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "propertyName", "email" },
                    { "value", request.Email },
                    { "operator", "EQ" },
                },
            };
            var filterGroups = new List<Dictionary<string, object>>
            {
                new Dictionary<string, object>
                {
                    { "filters", filters },
                },
            };
            var body = new { filterGroups, limit = 1 };
            return GenerateRequestMessage(
                httpClient.GenerateRequestUri(requestUri),
                method,
                body);
        }

        /// <summary>
        /// Maps a ContactUpdateRequest to HttpRequestMessage.
        /// </summary>
        /// <param name="request">Instance of <see cref="ContactUpdateRequest" />.</param>
        /// <param name="httpClient">Instance of <see cref="HttpClient" />.</param>
        /// <returns>A <see cref="HttpRequestMessage" /> object.</returns>
        internal static HttpRequestMessage MapToHttpRequestMessage(
            this ContactUpdateRequest request,
            HttpClient httpClient)
        {
            var path = $"{BasePath}/{request.Id}";
            var method = new HttpMethod("PATCH");
            var requestUri = new Uri(path, UriKind.Relative);
            var body = new { properties = request.Properties };
            return GenerateRequestMessage(
                httpClient.GenerateRequestUri(requestUri),
                method,
                body);
        }

        private static HttpRequestMessage GenerateRequestMessage(
            Uri requestUri,
            HttpMethod method,
            object body)
        {
            var httpRequest = new HttpRequestMessage(method, requestUri)
            {
                Content = new StringContent(
                    JsonConvert.SerializeObject(body),
                    Encoding.UTF8,
                    "application/json"),
            };
            httpRequest.Headers.Add("Accept", "application/json");
            return httpRequest;
        }
    }
}