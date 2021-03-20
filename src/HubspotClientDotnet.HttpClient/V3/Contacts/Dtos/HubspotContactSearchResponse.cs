//-----------------------------------------------------------------------
// <copyright file="HubspotContactSearchResponse.cs" company="Jose Manuel Marron Ruiz">
//     Copyright (c) Jose Manuel Marron Ruiz. All rights reserved.
//     Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------
namespace HubspotClientDotnet.HttpClient.V3.Contacts.Dtos
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the data model for a search contact operation.
    /// </summary>
    public class HubspotContactSearchResponse
    {
        /// <summary>Gets or sets the total of results.</summary>
        public int Total { get; set; }

        /// <summary>Gets the list of results.</summary>
        public IList<HubspotContact> Results { get; } = new List<HubspotContact>();
    }
}