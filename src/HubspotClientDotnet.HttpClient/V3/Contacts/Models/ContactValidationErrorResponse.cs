//-----------------------------------------------------------------------
// <copyright file="ContactValidationErrorResponse.cs" company="Jose Manuel Marron Ruiz">
//     Copyright (c) Jose Manuel Marron Ruiz. All rights reserved.
//     Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------
namespace HubspotClientDotnet.HttpClient.V3.Contacts.Models
{
    using HubspotClientDotnet.Core.Contacts.Models;

    /// <summary>
    /// Defines the data model for a Hubspot contact response.
    /// </summary>
    public class ContactValidationErrorResponse : BaseContactResponse
    {
        /// <summary>Gets the response type.</summary>
        public override ContactResponseType ResponseType => ContactResponseType.ValidationError;
    }
}