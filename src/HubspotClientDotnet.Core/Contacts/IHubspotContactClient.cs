//-----------------------------------------------------------------------
// <copyright file="IHubspotContactClient.cs" company="Jose Manuel Marron Ruiz">
//     Copyright (c) Jose Manuel Marron Ruiz. All rights reserved.
//     Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------
namespace HubspotClientDotnet.Core.Contacts
{
    using System.Threading;
    using System.Threading.Tasks;
    using HubspotClientDotnet.Core.Contacts.Models;

    /// <summary>
    /// Defines behavior for a Hubspot client for Contacts.
    /// </summary>
    public interface IHubspotContactClient
    {
        /// <summary>
        /// Creates a contact in Hubspot.
        /// </summary>
        /// <param name="request">Request object to create the Hubspot contact.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task that resolves to a <see cref="BaseContactResponse" /> object.</returns>
        Task<BaseContactResponse> CreateContactAsync(ContactCreateRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Searches for the contact with the given email.
        /// </summary>
        /// <param name="request">Request object to find the Hubspot contact.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task that resolves to a <see cref="BaseContactResponse" /> object.</returns>
        Task<BaseContactResponse> FindContactByEmailAsync(ContactFindByEmailRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Updates a contact in Hubspot.
        /// </summary>
        /// <param name="request">Request object to update the Hubspot contact.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task that resolves to a <see cref="BaseContactResponse" /> object.</returns>
        Task<BaseContactResponse> UpdateContactAsync(ContactUpdateRequest request, CancellationToken cancellationToken);
    }
}
