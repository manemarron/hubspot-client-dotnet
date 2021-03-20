//-----------------------------------------------------------------------
// <copyright file="ContactFindByEmailRequest.cs" company="Jose Manuel Marron Ruiz">
//     Copyright (c) Jose Manuel Marron Ruiz. All rights reserved.
//     Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------
namespace HubspotClientDotnet.Core.Contacts.Models
{
    /// <summary>
    /// Defines the data model for the find by email request of a Hubspot contact.
    /// </summary>
    public class ContactFindByEmailRequest
    {
        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        public string Email { get; set; }
    }
}