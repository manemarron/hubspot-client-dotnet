//-----------------------------------------------------------------------
// <copyright file="UpdateContactAsyncTests.cs" company="Jose Manuel Marron Ruiz">
//     Copyright (c) Jose Manuel Marron Ruiz. All rights reserved.
//     Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------
namespace HubspotClientDotnet.HttpClient.IntegrationTests.V3.Contacts
{
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using HubspotClientDotnet.Core.Contacts.Models;
    using HubspotClientDotnet.HttpClient.V3.Contacts.Models;
    using WireMock.Matchers;
    using WireMock.RequestBuilders;
    using WireMock.ResponseBuilders;
    using Xunit;

    public partial class HubspotContactHttpClientV3Tests
    {
        [Fact]
        public async Task When_UpdateContactAsyncIsInvoked_And_HubspotReturnsOkStatus_Then_ResponseMustBeAContactSuccessResponse()
        {
            // arrange
            const string responseFixture = "fixtures/hubspot-contact-update-response.json";
            const string expectedId = "someid";
            var request = new ContactUpdateRequest { Id = expectedId };
            var cancellationToken = new CancellationTokenSource().Token;
            this.wireMockServer
                .Given(Request.Create()
                    .UsingPatch()
                    .WithPath($"/crm/v3/objects/contacts/{expectedId}")
                    .WithParam(ApiKeyParamName, DefaultApiKey)
                    .WithBody(new JsonMatcher(@"{""properties"":{}}"))
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithHeader("Accept", "application/json"))
                .RespondWith(Response.Create()
                    .WithStatusCode(HttpStatusCode.OK)
                    .WithBodyFromFile(responseFixture, cache: true)
                    .WithHeader("Content-Type", "application/json; charset=utf-8"));

            // act
            var response = await this.systemUnderTest.UpdateContactAsync(request, cancellationToken);

            // assert
            Assert.IsType<ContactSuccessResponse>(response);
        }
    }
}