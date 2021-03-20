//-----------------------------------------------------------------------
// <copyright file="IServiceCollectionExtensions.cs" company="Jose Manuel Marron Ruiz">
//     Copyright (c) Jose Manuel Marron Ruiz. All rights reserved.
//     Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------
namespace HubspotClientDotnet.HttpClient.V3.Contacts
{
    using System;
    using HubspotClientDotnet.Core.Contacts;
    using HubspotClientDotnet.HttpClient.V3;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;

    /// <summary>
    /// Extensions for <see cref="IServiceCollection" /> to add Hubspot Client.
    /// </summary>
    public static class IServiceCollectionExtensions
    {
        private const string HubspotHttpClientConfigurationKey = "HubspotHttpClientConfiguration";

        /// <summary>
        /// Adds a <see cref="HubspotContactHttpClientV3" /> service.
        /// </summary>
        /// <param name="services">Instance of <see cref="IServiceCollection" />.</param>
        /// <param name="configuration">Instance of <see cref="IConfiguration" />.</param>
        public static void AddHubspotContactHttpClientV3(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<HubspotHttpClientConfiguration>(configuration.GetSection(HubspotHttpClientConfigurationKey));
            services.AddHttpClient<IHubspotContactClient, HubspotContactHttpClientV3>(ConfigureHttpClientBaseAddress);
        }

        private static void ConfigureHttpClientBaseAddress(
            IServiceProvider provider,
            System.Net.Http.HttpClient client)
        {
                var options = provider.GetRequiredService<IOptions<HubspotHttpClientConfiguration>>();
                var config = options.Value;
                var uriBuilder = new UriBuilder(config.BaseUri);
                uriBuilder.Query = $"hapikey={config.ApiKey}";
                client.BaseAddress = uriBuilder.Uri;
        }
    }
}