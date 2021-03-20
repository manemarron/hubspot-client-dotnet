//-----------------------------------------------------------------------
// <copyright file="FindContactByEmailAsyncTests.cs" company="Jose Manuel Marron Ruiz">
//     Copyright (c) Jose Manuel Marron Ruiz. All rights reserved.
//     Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------
namespace HubspotClientDotnet.HttpClient.IntegrationTests.V3.Contacts
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using HubspotClientDotnet.Core.Contacts.Models;
    using Xunit;

    public partial class HubspotContactHttpClientV3Tests
    {
        [Fact]
        public async Task When_FindContactByEmailAsyncIsInvoked_And_RequestIsNull_Then_ArgumentNullExceptionMustBeThrown()
        {
            // arrange
            var cancellationToken = new CancellationTokenSource().Token;
            ContactFindByEmailRequest request = null;

            // act and assert
            var err = await Assert.ThrowsAsync<ArgumentNullException>(() => this.systemUnderTest.FindContactByEmailAsync(request, cancellationToken));
            Assert.Equal("request", err.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public async Task When_FindContactByEmailAsyncIsInvoked_And_RequestEmailIsNullOrWhitespace_Then_ArgumentNullExceptionMustBeThrown(string email)
        {
            // arrange
            var cancellationToken = new CancellationTokenSource().Token;
            var request = new ContactFindByEmailRequest { Email = email };

            // act and assert
            var err = await Assert.ThrowsAsync<ArgumentNullException>(() => this.systemUnderTest.FindContactByEmailAsync(request, cancellationToken));
            Assert.Equal("Email", err.ParamName);
        }
    }
}