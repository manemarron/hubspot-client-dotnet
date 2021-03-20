//-----------------------------------------------------------------------
// <copyright file="ContactSuccessResponse.cs" company="Jose Manuel Marron Ruiz">
//     Copyright (c) Jose Manuel Marron Ruiz. All rights reserved.
//     Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------
namespace HubspotClientDotnet.HttpClient.V3.Contacts.Models
{
    using HubspotClientDotnet.Core.Contacts.Models;
    using HubspotClientDotnet.HttpClient.V3.Contacts.Dtos;

    /// <summary>
    /// Defines the data model for a Hubspot contact response.
    /// </summary>
    public class ContactSuccessResponse : BaseContactResponse
    {
        /// <summary>Gets or sets the Hubspot contact in the response.</summary>
        public HubspotContact Contact { get; set; }

        /// <inheritdoc />
        public override ContactResponseType ResponseType { get; } = ContactResponseType.Success;
    }
}