namespace CustomLinkedList.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DynamicListTests
    {
        private DynamicList<int> list;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
        }

        [TestInitialize]
        public void TestInitialize()
        {
            this.list = new DynamicList<int>();
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        [TestMethod]
        public void Add_EmptyList_ShouldIncrementCount()
        {
            this.list.Add(1);
            this.list.Add(8);
            this.list.Add(5);

            int count = this.list.Count;

            Assert.AreEqual(3, count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetElementAtInvalidIndex_ShouldThrow()
        {
            this.list.Add(6);
            this.list.Add(3);

            int element = this.list[2];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetElementAtInvalidIndex_ShouldThrow()
        {
            this.list.Add(6);
            this.list[-1] = 11;
        }

        [TestMethod]
        public void CheckWhetherLastElementIsCorrect()
        {
            for (int i = 0; i < 100; i++)
            {
                this.list.Add(i);
            }

            bool result = 99 == this.list[this.list.Count - 1];

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IndexOfMethod_ContainedElement_ShouldReturnCorrectIndex()
        {
            this.list.Add(1);
            this.list.Add(8);
            this.list.Add(5);

            int index = this.list.IndexOf(5);

            Assert.AreEqual(2, index);
        }

        [TestMethod]
        public void ContainsMethod_ContainedElement_ShouldReturnTrue()
        {
            this.list.Add(1);
            this.list.Add(8);
            this.list.Add(5);

            bool isContained = this.list.Contains(8);
            Assert.IsTrue(isContained);
        }

        [TestMethod]
        public void RemoveMethod_RemoveElement_ShouldNotContainThisElementInList()
        {
            this.list.Add(1);
            this.list.Add(8);
            this.list.Add(5);

            this.list.Remove(8);

            bool isContained = this.list.Contains(8);

            Assert.IsFalse(isContained);
        }

        [TestMethod]
        public void RemoveAtMethod_RemoveElementAtIndex_ShouldNotFindSameElementAtThisIndex()
        {
            this.list.Add(1);
            this.list.Add(8);
            this.list.Add(5);

            this.list.RemoveAt(1);

            bool isContained = this.list[1] == 8;

            Assert.IsFalse(isContained);
        }
    }
}
