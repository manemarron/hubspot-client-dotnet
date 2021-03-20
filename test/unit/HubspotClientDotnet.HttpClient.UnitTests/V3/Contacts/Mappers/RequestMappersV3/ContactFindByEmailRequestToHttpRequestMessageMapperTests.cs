//-----------------------------------------------------------------------
// <copyright file="ContactFindByEmailRequestToHttpRequestMessageMapperTests.cs" company="Jose Manuel Marron Ruiz">
//     Copyright (c) Jose Manuel Marron Ruiz. All rights reserved.
//     Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------
namespace HubspotClientDotnet.HttpClient.UnitTests.V3.Contacts.Mappers.RequestMappersV3
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using HubspotClientDotnet.Core.Contacts.Models;
    using HubspotClientDotnet.HttpClient.V3.Contacts.Mappers;
    using Xunit;

    public class ContactFindByEmailRequestToHttpRequestMessageMapperTests
    {
        [Fact]
        public void When_ContactFindByEmailRequestIsPassed_If_HttpClientHasNullBaseAddress_Then_AnArgumentNullExceptionMustBeThrown()
        {
            // arrange
            var httpClient = new HttpClient();
            var request = new ContactFindByEmailRequest();

            // act and assert
            Assert.Throws<ArgumentNullException>(() => request.MapToHttpRequestMessage(httpClient));
        }

        [Fact]
        public void When_ContactFindByEmailRequestIsPassed_Then_HttpRequestMethodMustBePost()
        {
            // arrange
            var httpClient = new HttpClient { BaseAddress = new Uri("http://localhost") };
            var request = new ContactFindByEmailRequest();

            // act
            using (var httpRequest = request.MapToHttpRequestMessage(httpClient))
            {
                // assert
                Assert.Equal(HttpMethod.Post, httpRequest.Method);
            }
        }

        [Fact]
        public void When_ContactFindByEmailRequestIsPassed_Then_HttpRequestUriMustBeCorrect()
        {
            // arrange
            const string expectedUri = "http://localhost/crm/v3/objects/contacts/search";
            var httpClient = new HttpClient { BaseAddress = new Uri("http://localhost") };
            var request = new ContactFindByEmailRequest();

            // act
            using (var httpRequest = request.MapToHttpRequestMessage(httpClient))
            {
                // assert
                Assert.Equal(expectedUri, httpRequest.RequestUri.ToString());
            }
        }

        [Fact]
        public void When_ContactFindByEmailRequestIsPassed_Then_HttpRequestBodyMustBeCorrect()
        {
            // arrange
            const string expectedEmail = "some email";
            var expectedBody = $@"{{""filterGroups"":[{{""filters"":[{{""propertyName"":""email"",""value"":""{expectedEmail}"",""operator"":""EQ""}}]}}],""limit"":1}}";
            var httpClient = new HttpClient { BaseAddress = new Uri("http://localhost") };
            var request = new ContactFindByEmailRequest { Email = expectedEmail };

            // act
            using (var httpRequest = request.MapToHttpRequestMessage(httpClient))
            {
                // assert
                var body = httpRequest.Content.ReadAsStringAsync().Result;
                Assert.Equal(expectedBody, body);
            }
        }

        [Fact]
        public void When_ContactFindByEmailRequestIsPassed_Then_HttpRequestContentTypeMustBeApplicationJsonWithUtf8Charset()
        {
            // arrange
            const string expectedContentType = "application/json; charset=utf-8";
            var httpClient = new HttpClient { BaseAddress = new Uri("http://localhost") };
            var request = new ContactFindByEmailRequest();

            // act
            var httpRequest = request.MapToHttpRequestMessage(httpClient);

            // assert
            Assert.Equal(expectedContentType, httpRequest.Content.Headers.GetValues("Content-Type").First());
        }

        [Fact]
        public void When_ContactFindByEmailRequestIsPassed_Then_HttpRequestAcceptHeaderMustBeApplicationJson()
        {
            // arrange
            const string expectedAccept = "application/json";
            var httpClient = new HttpClient { BaseAddress = new Uri("http://localhost") };
            var request = new ContactFindByEmailRequest();

            // act
            using (var httpRequest = request.MapToHttpRequestMessage(httpClient))
            {
                // assert
                Assert.Equal(expectedAccept, httpRequest.Headers.GetValues("Accept").First());
            }
        }
    }
}