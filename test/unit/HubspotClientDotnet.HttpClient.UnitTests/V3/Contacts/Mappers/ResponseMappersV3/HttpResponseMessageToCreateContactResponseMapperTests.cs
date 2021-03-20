//-----------------------------------------------------------------------
// <copyright file="HttpResponseMessageToCreateContactResponseMapperTests.cs" company="Jose Manuel Marron Ruiz">
//     Copyright (c) Jose Manuel Marron Ruiz. All rights reserved.
//     Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------
namespace HubspotClientDotnet.HttpClient.UnitTests.V3.Contacts.Mappers.ResponseMappersV3
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using HubspotClientDotnet.HttpClient.Exceptions;
    using HubspotClientDotnet.HttpClient.UnitTests.Comparers;
    using HubspotClientDotnet.HttpClient.V3.Contacts.Dtos;
    using HubspotClientDotnet.HttpClient.V3.Contacts.Mappers;
    using HubspotClientDotnet.HttpClient.V3.Contacts.Models;
    using Xunit;

    public class HttpResponseMessageToCreateContactResponseMapperTests
    {
        [Theory]
        [InlineData(500)]
        [InlineData(501)]
        [InlineData(502)]
        [InlineData(503)]
        [InlineData(504)]
        [InlineData(505)]
        public async Task When_HttpResponseStatusIs5xx_Then_AHubspotNetworkExceptionMustBeThrown(int statusCode)
        {
            using (var httpResponse = new HttpResponseMessage())
            {
                // arrange
                httpResponse.StatusCode = (HttpStatusCode)statusCode;

                // act and assert
                var err = await Assert.ThrowsAsync<HubspotNetworkException>(() => httpResponse.MapToCreateContactResponse());
                Assert.Equal(httpResponse.ReasonPhrase, err.Message);
            }
        }

        [Fact]
        public async Task When_HttpResponseStatusIs409_Then_AContactAlreadyExistsResponseMustBeReturned()
        {
            using (var httpResponse = new HttpResponseMessage())
            {
                // arrange
                httpResponse.StatusCode = HttpStatusCode.Conflict;

                // act
                var response = await httpResponse.MapToCreateContactResponse();

                // assert
                Assert.IsType<ContactAlreadyExistsResponse>(response);
            }
        }

        [Fact]
        public async Task When_HttpResponseStatusIs400_Then_AContactValidationErrorResponseMustBeReturned()
        {
            using (var httpResponse = new HttpResponseMessage())
            {
                // arrange
                httpResponse.StatusCode = HttpStatusCode.BadRequest;

                // act
                var response = await httpResponse.MapToCreateContactResponse();

                // assert
                Assert.IsType<ContactValidationErrorResponse>(response);
            }
        }

        [Theory]
        [InlineData(401)]
        [InlineData(403)]
        [InlineData(404)]
        [InlineData(405)]
        [InlineData(414)]
        [InlineData(415)]
        public async Task When_HttpResponseStatusIsADifferent4xxStatusOfConflictAndBadRequest_Then_AnUnsupportedStatusExceptionMustBeThrown(int statusCode)
        {
            using (var httpResponse = new HttpResponseMessage())
            {
                // arrange
                httpResponse.StatusCode = (HttpStatusCode)statusCode;

                // act and assert
                var err = await Assert.ThrowsAsync<UnsupportedStatusException>(() => httpResponse.MapToCreateContactResponse());
                Assert.Equal(httpResponse.ReasonPhrase, err.Message);
            }
        }

        [Fact]
        public async Task When_HttpResponseIsSuccessful_Then_ContactSuccessResponseMustBeReturned()
        {
            using (var httpResponse = new HttpResponseMessage())
            {
                // arrange
                httpResponse.StatusCode = HttpStatusCode.Created;
                httpResponse.Content = new StreamContent(new FileStream("fixtures/hubspot-contact-create-response.json", FileMode.Open));

                // act
                var response = await httpResponse.MapToCreateContactResponse();

                // assert
                Assert.IsType<ContactSuccessResponse>(response);
            }
        }

        [Fact]
        public async Task When_HttpResponseIsSuccessful_Then_HubspotContactMustEqualTheExpected()
        {
            using (var httpResponse = new HttpResponseMessage())
            {
                // arrange
                var expectedContact = new HubspotContact
                {
                    Id = "512",
                    CreatedAt = DateTime.Parse("2019-10-30T03:30:17.883Z").ToUniversalTime(),
                    UpdatedAt = DateTime.Parse("2019-12-07T16:50:06.678Z").ToUniversalTime(),
                    Archived = false,
                };
                expectedContact.Properties.Add("company", "Biglytics");
                expectedContact.Properties.Add("createdate", "2019-10-30T03:30:17.883Z");
                expectedContact.Properties.Add("email", "bcooper@biglytics.net");
                expectedContact.Properties.Add("firstname", "Bryan");
                expectedContact.Properties.Add("lastmodifieddate", "2019-12-07T16:50:06.678Z");
                expectedContact.Properties.Add("lastname", "Cooper");
                expectedContact.Properties.Add("phone", "(877) 929-0687");
                expectedContact.Properties.Add("website", "biglytics.net");
                httpResponse.StatusCode = HttpStatusCode.Created;
                httpResponse.Content = new StreamContent(new FileStream("fixtures/hubspot-contact-create-response.json", FileMode.Open));

                // act
                var response = await httpResponse.MapToCreateContactResponse();

                // assert
                var parsedResponse = Assert.IsType<ContactSuccessResponse>(response);
                Assert.Equal(expectedContact, parsedResponse.Contact, new HubspotContactUnitTestEqualityComparer());
            }
        }
    }
}