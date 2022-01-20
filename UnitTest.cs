using System;
using NUnit.Framework;

namespace moveRobot
{
    [TestFixture, Author("David Dwyer", "dave@apostrophe-software.com"), Description("Testing the robotMove class")]
    public class UnitTest
    {
        // static object containing the test data
        static object[] TestData =
        {
        new object[] { "5x5", "FFRFLFLF" },
        new object[] { "3x4", "FRFFRFLF" },
        new object[] { "8x5", "FFFRRFLFLF" },
        new object[] { "10x10", "FFRFLFLF" },
        };

        private IRobotMover _mover;

        [SetUp]
        protected void Setup()
        {
            _mover = new RobotMover();
        }

        [TearDown]
        protected void TearDown()
        {

        }

        [TestCaseSource(nameof(TestData))]
        public void TestRobotMove(string gridSize, string commands)
        {
            _mover.GridSize = gridSize;
            _mover.Commands = commands;

            string result = _mover.Move();
            Assert.IsFalse(result.Equals(String.Empty));
        }
    }
}
