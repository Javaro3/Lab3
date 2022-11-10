using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Tests
{
    [TestClass()]
    public class MatrixTests
    {

        [TestMethod()]
        public void GetSumSqueradTest()
        {
            Matrix matrix = new Matrix(new int[,] { {-1, 2}, {-2, -4} });
            int expect = 21;
            Assert.IsTrue(expect == matrix.GetSumSquerad());
        }

        [TestMethod()]
        public void GetSumSqueradTest1()
        {
            Matrix matrix = new Matrix(new int[,] { { -10, 2 }, { 2, 4 } });
            int expect = 20;
            Assert.IsTrue(expect == matrix.GetSumSquerad(1));
        }

        [TestMethod()]
        public void OperatorTest1()
        {
            Matrix expect = new Matrix(new int[,] { { 0, 0 }, { 0, 0 } });
            Matrix matrix1 = new Matrix(new int[,] { { -10, 2 }, { 2, 4 } });
            Matrix matrix2 = new Matrix(new int[,] { { -10, 2 }, { 2, 4 } });
            Matrix act = new Matrix();
            act = matrix2 - matrix1;
            Assert.IsTrue(expect == act);
        }

        [TestMethod()]
        public void OperatorTest2()
        {
            Matrix matrix1 = new Matrix(new int[,] { { 1, 1 }, { 1, 1 } });
            Matrix matrix2 = new Matrix(new int[,] { { 2, 2 }, { 2,2 } });
            Assert.IsTrue(matrix1 <= matrix2);
        }

        [TestMethod()]
        public void GetSumSquaredForOperatorTest()
        {
            Matrix matrix2 = new Matrix(new int[,] { { 2, -2 }, { 2, -2 } });
            int expect = 8;
            Assert.IsTrue(expect <= matrix2.GetSumSquaredForOperator());
        }
    }
}