using System.Collections.Generic;
using Xunit;

namespace MyCollections.Test
{
    public class MyListTest : IMyListTest<int>
    {
        protected override void AssertAreEqual(int val1, int val2)
            => Assert.Equal(val1, val2);

        protected override IMyList<int> CreateSut() => new MyList<int>();

        protected override int GetElement() => 42;

        protected override IEnumerable<int> GetElements()
            => new List<int> { 1, 2, 3, 4 };
    }
}
