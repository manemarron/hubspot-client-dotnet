//-----------------------------------------------------------------------
// <copyright file="Initialize.cs" company="Jose Manuel Marron Ruiz">
//     Copyright (c) Jose Manuel Marron Ruiz. All rights reserved.
//     Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------
namespace HubspotClientDotnet.HttpClient.IntegrationTests.V3.Contacts
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using HubspotClientDotnet.HttpClient.V3.Contacts;
    using WireMock.Server;

    public partial class HubspotContactHttpClientV3Tests
    {
        private const string ApiKeyParamName = "hapikey";
        private const string DefaultApiKey = "somapikey";

        private readonly WireMockServer wireMockServer;
        private readonly HubspotContactHttpClientV3 systemUnderTest;

        public HubspotContactHttpClientV3Tests()
        {
            this.wireMockServer = WireMockServer.Start();
            var logger = TestLoggerFactory.CreateLogger<HubspotContactHttpClientV3>();
            var uriBuilder = new UriBuilder(this.wireMockServer.Urls.First());
            uriBuilder.Query = $"{ApiKeyParamName}={DefaultApiKey}";
            this.systemUnderTest = new HubspotContactHttpClientV3(
                new HttpClient { BaseAddress = uriBuilder.Uri },
                logger);
        }
    }
}