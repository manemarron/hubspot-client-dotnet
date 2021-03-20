//-----------------------------------------------------------------------
// <copyright file="HubspotContact.cs" company="Jose Manuel Marron Ruiz">
//     Copyright (c) Jose Manuel Marron Ruiz. All rights reserved.
//     Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------
namespace HubspotClientDotnet.HttpClient.V3.Contacts.Dtos
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the data model for a Hubspot contact response.
    /// </summary>
    public class HubspotContact
    {
        /// <summary>
        /// Gets or sets the id of the contact.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets the properties dictionary of the contact.
        /// </summary>
        public IDictionary<string, string> Properties { get; } = new Dictionary<string, string>();

        /// <summary>
        /// Gets or sets the creation time of the contact.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the last update time of the contact.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the contact is archived or not.
        /// </summary>
        public bool Archived { get; set; }

        /// <summary>
        /// Gets or sets the archived time of the contact. Null if Archived == false.
        /// </summary>
        public DateTime? ArchivedAt { get; set; }
    }
}
