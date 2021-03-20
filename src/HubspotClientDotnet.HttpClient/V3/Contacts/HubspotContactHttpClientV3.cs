//-----------------------------------------------------------------------
// <copyright file="HubspotContactHttpClientV3.cs" company="Jose Manuel Marron Ruiz">
//     Copyright (c) Jose Manuel Marron Ruiz. All rights reserved.
//     Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------
namespace HubspotClientDotnet.HttpClient.V3.Contacts
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using HubspotClientDotnet.Core.Contacts;
    using HubspotClientDotnet.Core.Contacts.Models;
    using HubspotClientDotnet.HttpClient.Extensions;
    using HubspotClientDotnet.HttpClient.V3.Contacts.Mappers;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Implements the <see cref="IHubspotContactClient" /> interface through an Http client.
    /// </summary>
    public class HubspotContactHttpClientV3 : IHubspotContactClient
    {
        private readonly HttpClient httpClient;
        private readonly ILogger<HubspotContactHttpClientV3> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="HubspotContactHttpClientV3"/> class.
        /// </summary>
        /// <param name="httpClient">Instance of <see cref="HttpClient" />.</param>
        /// <param name="logger">Instance of <see cref="ILogger{HubspotContactHttpClientV3}" />.</param>
        public HubspotContactHttpClientV3(
            HttpClient httpClient,
            ILogger<HubspotContactHttpClientV3> logger = null)
        {
            this.httpClient = httpClient;
            this.logger = logger;
        }

        /// <inheritdoc/>
        public async Task<BaseContactResponse> CreateContactAsync(ContactCreateRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new System.ArgumentNullException(nameof(request));
            }

            using (var httpRequest = request.MapToHttpRequestMessage(this.httpClient))
            using (var httpResponse = await this.httpClient.SendAndLogAsync(httpRequest, this.logger, cancellationToken))
            {
                return await httpResponse.MapToCreateContactResponse();
            }
        }

        /// <inheritdoc/>
        public async Task<BaseContactResponse> FindContactByEmailAsync(ContactFindByEmailRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new System.ArgumentNullException(nameof(request));
            }

            if (string.IsNullOrWhiteSpace(request.Email))
            {
                throw new System.ArgumentNullException(nameof(request.Email));
            }

            using (var httpRequest = request.MapToHttpRequestMessage(this.httpClient))
            using (var httpResponse = await this.httpClient.SendAndLogAsync(httpRequest, this.logger, cancellationToken))
            {
                return await httpResponse.MapToFindContactByEmailResponse();
            }
        }

        /// <inheritdoc/>
        public async Task<BaseContactResponse> UpdateContactAsync(ContactUpdateRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new System.ArgumentNullException(nameof(request));
            }

            if (string.IsNullOrWhiteSpace(request.Id))
            {
                throw new System.ArgumentNullException(nameof(request.Id));
            }

            using (var httpRequest = request.MapToHttpRequestMessage(this.httpClient))
            using (var httpResponse = await this.httpClient.SendAndLogAsync(httpRequest, this.logger, cancellationToken))
            {
                return await httpResponse.MapToUpdateContactResponse();
            }
        }
    }
}
