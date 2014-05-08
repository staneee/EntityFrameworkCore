// Copyright (c) Microsoft Open Technologies, Inc.
// All Rights Reserved
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR
// CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING
// WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR CONDITIONS OF
// TITLE, FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABLITY OR
// NON-INFRINGEMENT.
// See the Apache 2 License for the specific language governing
// permissions and limitations under the License.

using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Model;
using Xunit;

namespace Microsoft.Data.Entity.Relational.Tests.Model
{
    public class PrimaryKeyTest
    {
        [Fact]
        public void Create_and_initialize_primary_key()
        {
            var table = new Table("dbo.MyTable");
            var column0 = new Column("Foo", "int");
            var column1 = new Column("Bar", "int");
            table.AddColumn(column0);
            table.AddColumn(column1);
            var primaryKey = new PrimaryKey(
                "MyPrimaryKey", new[] { column0, column1, }, isClustered: true);

            Assert.Equal("MyPrimaryKey", primaryKey.Name);
            Assert.IsAssignableFrom<IReadOnlyList<Column>>(table.Columns);
            Assert.Equal(2, primaryKey.Columns.Count);
            Assert.Same(column0, primaryKey.Columns[0]);
            Assert.Same(column1, primaryKey.Columns[1]);
            Assert.Same(table, primaryKey.Table);
            Assert.True(primaryKey.IsClustered);
        }
    }
}
