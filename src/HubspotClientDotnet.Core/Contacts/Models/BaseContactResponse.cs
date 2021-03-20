//-----------------------------------------------------------------------
// <copyright file="BaseContactResponse.cs" company="Jose Manuel Marron Ruiz">
//     Copyright (c) Jose Manuel Marron Ruiz. All rights reserved.
//     Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------
namespace HubspotClientDotnet.Core.Contacts.Models
{
    /// <summary>
    /// Defines the data model for a Hubspot contact response.
    /// </summary>
    public abstract class BaseContactResponse
    {
        /// <summary>Gets the response type.</summary>
        public abstract ContactResponseType ResponseType { get; }
    }
}