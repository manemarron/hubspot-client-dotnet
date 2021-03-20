//-----------------------------------------------------------------------
// <copyright file="FindContactByEmailAsyncTests.cs" company="Jose Manuel Marron Ruiz">
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
        public async Task When_FindContactByEmailAsyncIsInvoked_And_HubspotReturnsOkStatusWithNonEmptyResults_Then_ResponseMustBeAContactSuccessResponse()
        {
            // arrange
            const string responseFixture = "fixtures/hubspot-contact-find-by-email-response.json";
            const string expectedEmail = "some email";
            var request = new ContactFindByEmailRequest { Email = expectedEmail };
            var cancellationToken = new CancellationTokenSource().Token;
            this.wireMockServer
                .Given(Request.Create()
                    .UsingPost()
                    .WithPath("/crm/v3/objects/contacts/search")
                    .WithParam(ApiKeyParamName, DefaultApiKey)
                    .WithBody(new JsonMatcher($@"{{""filterGroups"":[{{""filters"":[{{""value"":""{expectedEmail}"",""propertyName"":""email"",""operator"":""EQ""}}]}}],""limit"":1}}"))
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithHeader("Accept", "application/json"))
                .RespondWith(Response.Create()
                    .WithStatusCode(HttpStatusCode.OK)
                    .WithBodyFromFile(responseFixture, cache: true)
                    .WithHeader("Content-Type", "application/json; charset=utf-8"));

            // act
            var response = await this.systemUnderTest.FindContactByEmailAsync(request, cancellationToken);

            // assert
            Assert.IsType<ContactSuccessResponse>(response);
        }

        [Fact]
        public async Task When_FindContactByEmailAsyncIsInvoked_And_HubspotReturnsOkStatusWithEmptyResults_Then_ResponseMustBeAContactDoesNotExistResponse()
        {
            // arrange
            const string responseFixture = "fixtures/hubspot-contact-find-by-email-empty-response.json";
            const string expectedEmail = "some email";
            var request = new ContactFindByEmailRequest { Email = expectedEmail };
            var cancellationToken = new CancellationTokenSource().Token;
            this.wireMockServer
                .Given(Request.Create()
                    .UsingPost()
                    .WithPath("/crm/v3/objects/contacts/search")
                    .WithParam(ApiKeyParamName, DefaultApiKey)
                    .WithBody(new JsonMatcher($@"{{""filterGroups"":[{{""filters"":[{{""value"":""{expectedEmail}"",""propertyName"":""email"",""operator"":""EQ""}}]}}],""limit"":1}}"))
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithHeader("Accept", "application/json"))
                .RespondWith(Response.Create()
                    .WithStatusCode(HttpStatusCode.OK)
                    .WithBodyFromFile(responseFixture, cache: true)
                    .WithHeader("Content-Type", "application/json; charset=utf-8"));

            // act
            var response = await this.systemUnderTest.FindContactByEmailAsync(request, cancellationToken);

            // assert
            Assert.IsType<ContactDoesNotExistResponse>(response);
        }
    }
}