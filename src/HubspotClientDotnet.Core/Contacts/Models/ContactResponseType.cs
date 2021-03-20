//-----------------------------------------------------------------------
// <copyright file="ContactResponseType.cs" company="Jose Manuel Marron Ruiz">
//     Copyright (c) Jose Manuel Marron Ruiz. All rights reserved.
//     Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------
namespace HubspotClientDotnet.Core.Contacts.Models
{
    /// <summary>
    /// Enum defining the types of responses from Hubspot API.
    /// </summary>
    public enum ContactResponseType
    {
        /// <summary>Value for success response.</summary>
        Success = 0,

        /// <summary>Value for response when contact already exists during POST.</summary>
        ContactAlreadyExists,

        /// <summary>Value for response when the contact does not exist.</summary>
        ContactDoesNotExist,

        /// <summary>Value for response when there is a validation error.</summary>
        ValidationError,
    }
}