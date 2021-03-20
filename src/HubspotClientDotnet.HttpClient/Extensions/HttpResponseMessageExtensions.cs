//-----------------------------------------------------------------------
// <copyright file="HttpResponseMessageExtensions.cs" company="Jose Manuel Marron Ruiz">
//     Copyright (c) Jose Manuel Marron Ruiz. All rights reserved.
//     Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------
namespace HubspotClientDotnet.HttpClient.Extensions
{
    using System.Net.Http;
    using HubspotClientDotnet.HttpClient.Exceptions;

    /// <summary>
    /// Defines extensions for HttpResponseMessage.
    /// </summary>
    internal static class HttpResponseMessageExtensions
    {
        /// <summary>
        /// Ensures that status code is not 5xx.
        /// </summary>
        /// <param name="response">Instance of <see cref="HttpResponseMessage" />.</param>
        /// <exception cref="HubspotNetworkException">When response has 5xx status.</exception>
        internal static void EnsureStatusCodeNot5xx(this HttpResponseMessage response)
        {
            if ((int)response.StatusCode >= 500)
            {
                throw new HubspotNetworkException(response);
            }
        }
    }
}