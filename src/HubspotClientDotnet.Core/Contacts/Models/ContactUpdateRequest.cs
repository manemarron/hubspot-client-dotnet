//-----------------------------------------------------------------------
// <copyright file="ContactUpdateRequest.cs" company="Jose Manuel Marron Ruiz">
//     Copyright (c) Jose Manuel Marron Ruiz. All rights reserved.
//     Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------
namespace HubspotClientDotnet.Core.Contacts.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the data model for the create request of a Hubspot contact.
    /// </summary>
    public class ContactUpdateRequest
    {
        /// <summary>
        /// Gets or sets the id of the contact.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets the properties dictionary.
        /// </summary>
        public IDictionary<string, string> Properties { get; } = new Dictionary<string, string>();
    }
}