//-----------------------------------------------------------------------
// <copyright file="ResponseMappersV3.cs" company="Jose Manuel Marron Ruiz">
//     Copyright (c) Jose Manuel Marron Ruiz. All rights reserved.
//     Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------
namespace HubspotClientDotnet.HttpClient.V3.Contacts.Mappers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using HubspotClientDotnet.Core.Contacts.Models;
    using HubspotClientDotnet.HttpClient.Exceptions;
    using HubspotClientDotnet.HttpClient.Extensions;
    using HubspotClientDotnet.HttpClient.V3.Contacts.Dtos;
    using HubspotClientDotnet.HttpClient.V3.Contacts.Models;
    using Newtonsoft.Json;

    /// <summary>
    /// Implements mappers from HttpResponseMessage.
    /// </summary>
    internal static class ResponseMappersV3
    {
        /// <summary>
        /// Maps a CreateContact HttpResponseMessage to BaseContactResponse.
        /// </summary>
        /// <param name="httpResponse">Instance of <see cref="HttpResponseMessage" />.</param>
        /// <returns>A <see cref="BaseContactResponse" /> object.</returns>
        /// <exception cref="HubspotNetworkException">When hubspot server responds with 5xx status.</exception>
        internal static async Task<BaseContactResponse> MapToCreateContactResponse(this HttpResponseMessage httpResponse)
        {
            httpResponse.EnsureStatusCodeNot5xx();
            if (!httpResponse.IsSuccessStatusCode)
            {
                switch (httpResponse.StatusCode)
                {
                    case HttpStatusCode.Conflict:
                        return new ContactAlreadyExistsResponse();
                    case HttpStatusCode.BadRequest:
                        return new ContactValidationErrorResponse();
                    default:
                        throw new UnsupportedStatusException(httpResponse);
                }
            }

            return new ContactSuccessResponse
            {
                Contact = JsonConvert.DeserializeObject<HubspotContact>(await httpResponse.Content.ReadAsStringAsync()),
            };
        }

        /// <summary>
        /// Maps a FindContactByEmail HttpResponseMessage to BaseContactResponse.
        /// </summary>
        /// <param name="httpResponse">Instance of <see cref="HttpResponseMessage" />.</param>
        /// <returns>A <see cref="BaseContactResponse" /> object.</returns>
        /// <exception cref="HubspotNetworkException">When hubspot server responds with 5xx status.</exception>
        internal static async Task<BaseContactResponse> MapToFindContactByEmailResponse(this HttpResponseMessage httpResponse)
        {
            httpResponse.EnsureStatusCodeNot5xx();
            var response = JsonConvert.DeserializeObject<HubspotContactSearchResponse>(await httpResponse.Content.ReadAsStringAsync());
            if (response.Total == 0)
            {
                return new ContactDoesNotExistResponse();
            }

            return new ContactSuccessResponse { Contact = response.Results[0] };
        }

        /// <summary>
        /// Maps a UpdateContact HttpResponseMessage to BaseContactResponse.
        /// </summary>
        /// <param name="httpResponse">Instance of <see cref="HttpResponseMessage" />.</param>
        /// <returns>A <see cref="BaseContactResponse" /> object.</returns>
        /// <exception cref="HubspotNetworkException">When hubspot server responds with 5xx status.</exception>
        internal static async Task<BaseContactResponse> MapToUpdateContactResponse(this HttpResponseMessage httpResponse)
        {
            httpResponse.EnsureStatusCodeNot5xx();
            if (!httpResponse.IsSuccessStatusCode)
            {
                switch (httpResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new ContactDoesNotExistResponse();
                    case HttpStatusCode.Conflict:
                        return new ContactAlreadyExistsResponse();
                    case HttpStatusCode.BadRequest:
                        return new ContactValidationErrorResponse();
                    default:
                        throw new UnsupportedStatusException(httpResponse);
                }
            }

            return new ContactSuccessResponse
            {
                Contact = JsonConvert.DeserializeObject<HubspotContact>(await httpResponse.Content.ReadAsStringAsync()),
            };
        }
    }
}