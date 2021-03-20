//-----------------------------------------------------------------------
// <copyright file="HubspotContactUnitTestEqualityComparer.cs" company="Jose Manuel Marron Ruiz">
//     Copyright (c) Jose Manuel Marron Ruiz. All rights reserved.
//     Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------
namespace HubspotClientDotnet.HttpClient.UnitTests.Comparers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using HubspotClientDotnet.HttpClient.V3.Contacts.Dtos;

    internal class HubspotContactUnitTestEqualityComparer : IEqualityComparer<HubspotContact>
    {
        public bool Equals([AllowNull] HubspotContact x, [AllowNull] HubspotContact y)
        {
            return x == y ||
                (string.Equals(x.Id, y.Id) &&
                x.Archived == y.Archived &&
                DateTime.Equals(x.CreatedAt, y.CreatedAt) &&
                DateTime.Equals(x.UpdatedAt, y.UpdatedAt) &&
                DateTime.Equals(x.ArchivedAt, y.ArchivedAt) &&
                x.Properties.Count == y.Properties.Count &&
                x.Properties.Aggregate(true, (prev, kvPair) =>
                    prev && y.Properties.TryGetValue(kvPair.Key, out string yValue) && string.Equals(kvPair.Value, yValue)));

            throw new System.NotImplementedException();
        }

        public int GetHashCode([DisallowNull] HubspotContact obj)
        {
            throw new System.NotImplementedException();
        }
    }
}