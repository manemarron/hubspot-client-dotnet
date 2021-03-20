//-----------------------------------------------------------------------
// <copyright file="HubspotNetworkException.cs" company="Jose Manuel Marron Ruiz">
//     Copyright (c) Jose Manuel Marron Ruiz. All rights reserved.
//     Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------
namespace HubspotClientDotnet.HttpClient.Exceptions
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Runtime.Serialization;

    /// <summary>
    /// An exception thrown when the Hubspot server responds with a 5xx status.
    /// </summary>
    public class HubspotNetworkException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HubspotNetworkException"/> class.
        /// </summary>
        public HubspotNetworkException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HubspotNetworkException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public HubspotNetworkException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HubspotNetworkException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public HubspotNetworkException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HubspotNetworkException"/> class.
        /// </summary>
        /// <param name="httpResponse">Http response associated with the exception.</param>
        public HubspotNetworkException(HttpResponseMessage httpResponse)
            : base(httpResponse.ReasonPhrase)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HubspotNetworkException"/> class.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Streaming context.</param>
        protected HubspotNetworkException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}