//-----------------------------------------------------------------------
// <copyright file="Initialize.cs" company="Jose Manuel Marron Ruiz">
//     Copyright (c) Jose Manuel Marron Ruiz. All rights reserved.
//     Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------
namespace HubspotClientDotnet.HttpClient.IntegrationTests.V3.Contacts
{
    using System.Net.Http;
    using HubspotClientDotnet.HttpClient.V3.Contacts;
    using Microsoft.Extensions.Logging;
    using Moq;

    public partial class HubspotContactHttpClientV3Tests
    {
        private readonly HubspotContactHttpClientV3 systemUnderTest;

        public HubspotContactHttpClientV3Tests()
        {
            var logger = new Mock<ILogger<HubspotContactHttpClientV3>>();
            this.systemUnderTest = new HubspotContactHttpClientV3(
                new HttpClient(),
                logger.Object);
        }
    }
}