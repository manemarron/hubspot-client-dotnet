//-----------------------------------------------------------------------
// <copyright file="HubspotHttpClientConfiguration.cs" company="Jose Manuel Marron Ruiz">
//     Copyright (c) Jose Manuel Marron Ruiz. All rights reserved.
//     Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------
namespace HubspotClientDotnet.HttpClient.V3
{
    using System;

    /// <summary>
    /// Defines configuration for <see cref="HubspotHttpClientConfiguration" />.
    /// </summary>
    public class HubspotHttpClientConfiguration
    {
        /// <summary>Gets or sets the api key for Hubspot.</summary>
        public string ApiKey { get; set; }

        /// <summary>Gets or sets the base uri for Hubspot.</summary>
        public Uri BaseUri { get; set; } = new Uri("https://api.hubapi.com");
    }
}