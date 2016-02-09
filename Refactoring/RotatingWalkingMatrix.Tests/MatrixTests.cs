
namespace RotatingWalkingMatrix.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using RotatingWalkInMatrix;
    using RotatingWalkInMatrix.Interfaces;
    using RotatingWalkInMatrix.IO;

    [TestClass]
    public class MatrixTests
    {
        private MatrixCore matrixCore;
        private IConsoleReaderWriter consoleReaderWriter;

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
            this.consoleReaderWriter = new ConsoleReaderWriter();
            this.matrixCore = new MatrixCore(this.consoleReaderWriter);
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        [TestMethod]
        public void TestMatrixSetupMethod()
        {
            int[,] matrix = new int[3, 3];
            int firstPositionInMatrix = 1;
            int row = 0;
            int col = 0;
            int horizontalDirection = 1;
            int verticalDirection = 1;

            matrixCore.SetupMatrix(matrix, row, col, firstPositionInMatrix,
                                   horizontalDirection, 1, verticalDirection);
            int[,] expected = new int[,]
            {
                { 1,7,8 },
                { 6,2,9 },
                { 5,4,3 }
            };

            CollectionAssert.AreEqual(expected, matrix);
        }

        [TestMethod]
        public void TestSmallestPossibleMatrix()
        {
            int[,] matrix = new int[1, 1];
            int firstPositionInMatrix = 1;
            int row = 0;
            int col = 0;
            int horizontalDirection = 1;
            int verticalDirection = 1;

            matrixCore.SetupMatrix(matrix, row, col, firstPositionInMatrix,
                                   horizontalDirection, 1, verticalDirection);
            int[,] expected = new int[,] { { 1 } };

            CollectionAssert.AreEqual(expected, matrix);
        }

        ////Tried to test input validation, but it is private static method.I used console mocking....
        //[TestMethod]
        //public void TestIncorrectConsoleInput()
        //{
        //    var moq = new Mock<IConsoleReaderWriter>();
        //    moq.Setup(c => c.ReadNextLine())
        //        .Returns("101");
        //}
    }
}
