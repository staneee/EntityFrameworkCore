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

using Microsoft.Data.Entity.ChangeTracking;
using Microsoft.Data.Entity.Metadata;
using Moq;
using Xunit;

namespace Microsoft.Data.Entity.Tests.ChangeTracking
{
    public class CompositeEntityKeyTest
    {
        [Fact]
        public void Value_property_is_strongly_typed()
        {
            Assert.IsType<object[]>(new CompositeEntityKey(new Mock<IEntityType>().Object, new object[] { 77, "Kake" }).Value);
        }

        [Fact]
        public void Base_class_value_property_returns_same_as_strongly_typed_value_property()
        {
            var key = new CompositeEntityKey(new Mock<IEntityType>().Object, new object[] { 77, "Kake" });

            Assert.Equal(new object[] { 77, "Kake" }, key.Value);
            Assert.Equal(new object[] { 77, "Kake" }, (object[])((EntityKey)key).Value);
        }

        [Fact]
        public void Only_keys_with_the_same_value_and_entity_type_test_as_equal()
        {
            var type1 = new Mock<EntityType>().Object;
            var type2 = new Mock<EntityType>().Object;

            Assert.True(new CompositeEntityKey(type1, new object[] { 77, "Kake" }).Equals(new CompositeEntityKey(type1, new object[] { 77, "Kake" })));
            Assert.False(new CompositeEntityKey(type1, new object[] { 77, "Kake" }).Equals(new CompositeEntityKey(type1, new object[] { 77, "Lie" })));
            Assert.False(new CompositeEntityKey(type1, new object[] { 77, "Kake" }).Equals(new CompositeEntityKey(type1, new object[] { 88, "Kake" })));
            Assert.False(new CompositeEntityKey(type1, new object[] { 77, "Kake" }).Equals(new CompositeEntityKey(type2, new object[] { 77, "Kake" })));
        }

        [Fact]
        public void Only_keys_with_the_same_value_and_type_return_same_hashcode()
        {
            var type1 = new Mock<EntityType>().Object;
            var type2 = new Mock<EntityType>().Object;

            Assert.Equal(new CompositeEntityKey(type1, new object[] { 77, "Kake" }).GetHashCode(), new CompositeEntityKey(type1, new object[] { 77, "Kake" }).GetHashCode());
            Assert.NotEqual(new CompositeEntityKey(type1, new object[] { 77, "Kake" }).GetHashCode(), new CompositeEntityKey(type1, new object[] { 77, "Lie" }).GetHashCode());
            Assert.NotEqual(new CompositeEntityKey(type1, new object[] { 77, "Kake" }).GetHashCode(), new CompositeEntityKey(type1, new object[] { 88, "Kake" }).GetHashCode());
            Assert.NotEqual(new CompositeEntityKey(type1, new object[] { 77, "Kake" }).GetHashCode(), new CompositeEntityKey(type2, new object[] { 77, "Kake" }).GetHashCode());
        }
    }
}
