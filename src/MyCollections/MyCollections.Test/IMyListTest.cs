using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MyCollections.Test
{
    public abstract class IMyListTest<T>
    {
        [Fact]
        // Returns 0 for a newly created List.
        public void Count_ZeroElementsInList_ReturnZero()
        {
            var lst = this.CreateSut();

            Assert.Equal(0, lst.Count());
        }

        [Fact]
        // Count: Returns value > 0 for a List with added items.
        // Append: If called n x times, Count returns n.
        public void Count_NElementsInList_ReturnN()
        {
            // Arrange
            var lst = this.CreateSut();
            var elements = this.GetElements().ToList();

            // Act 
            elements.ForEach(e => lst.Append(e));

            // Assert
            Assert.Equal(elements.Count, lst.Count());
        }

        [Fact]
        // Clear: Count returns 0 if n items have been in the list.
        public void Clear_NonEmptyList_CountReturnsZero()
        {
            // Arrange
            var lst = this.CreateSut();
            var elements = this.GetElements().ToList();

            elements.ForEach(e => lst.Append(e));

            // Act 
            lst.Clear();

            // Assert
            Assert.Equal(0, lst.Count());
        }

        [Fact]
        // Index doesn’t exist, Exception is thrown.
        public void GetElementAtIndex_ListIsEmpty_ThrowException()
        {
            // Arrange
            var lst = this.CreateSut();

            // Act 
            // Assert
            Assert.ThrowsAny<Exception>(() => lst.GetElementAt(1));
        }

        [Fact]
        // Index is negative, Exception is thrown.
        public void GetElementAtIndex_IndexIsNegative_ThrowException()
        {
            // Arrange
            var lst = this.CreateSut();

            // Act 
            // Assert
            Assert.ThrowsAny<Exception>(() => lst.GetElementAt(-1));
        }

        [Fact]
        // Index = n, Append was called n x times. Element at index n is returned.
        public void GetElementAtIndex_SingleElementInList_ElementAtIndexIsReturned()
        {
            // Arrange
            var lst = this.CreateSut();
            var elementToAppend = this.GetElement();
            lst.Append(elementToAppend);

            // Act 
            var fetchedElement = lst.GetElementAt(0);

            // Assert
            AssertAreEqual(elementToAppend, fetchedElement);
        }

        [Fact]
        public void GetElementAtIndex_MultipleElementInList_ElementAtIndexIsReturned()
        {
            // Arrange
            var lst = this.CreateSut();
            var elements = this.GetElements().ToList();

            elements.ForEach(e => lst.Append(e));
            var expectedElement = elements.Last();

            // Act 
            var fetchedElement = lst.GetElementAt(elements.Count -1);

            // Assert
            AssertAreEqual(expectedElement, fetchedElement);
        }

        protected abstract IMyList<T> CreateSut();
        protected abstract IEnumerable<T> GetElements();
        protected abstract T GetElement();

        protected abstract void AssertAreEqual(T val1, T val2);
    }
}
