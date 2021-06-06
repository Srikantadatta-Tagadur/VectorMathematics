using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Vector = Library.Vector;
using Library;

namespace VectorMathematicsTest
{
    [TestClass]
    public class VectorOperationsTests
    {
        /// <summary>
        /// Unit test for testing the vector negation operation
        /// <summary>
        [DataTestMethod]
        [DynamicData(nameof(GetNegationTestData), DynamicDataSourceType.Method)]
        public void Negation_Test(Vector v1, Vector expected)
        {
            Vector actual = VectorOperations.Negation(v1);
            Assert.IsTrue(NearlyEqualVector(expected, actual));
        }

        public static System.Collections.Generic.IEnumerable<object[]> GetNegationTestData()
        {
            // Test 1: Components are positive integers
            yield return new object[] { new Vector(1, 4, 8), new Vector(-1, -4, -8) };

            // Test 2: Components are negative integers
            yield return new object[] { new Vector(-3, -1, -4), new Vector(3, 1, 4) };

            // Test 3: Components are a mix of positive and negative integers
            yield return new object[] { new Vector(2, -6, 1), new Vector(-2, 6, -1) };

            // Test 4: Components are positive doubles
            yield return new object[] { new Vector(3.1, 4.5, 2.7), new Vector(-3.1, -4.5, -2.7) };

            // Test 5: Components are negative doubles
            yield return new object[] { new Vector(-1.2, -3.2, -4.9), new Vector(1.2, 3.2, 4.9) };

            // Test 6: Components are a mix of integers and doubles
            yield return new object[] { new Vector(4, -6.5, 3), new Vector(-4, 6.5, -3) };
        }

        /// <summary>
        /// Unit test for testing the addition of vectors operation
        /// <summary>
        [DataTestMethod]
        [DynamicData(nameof(GetAdditionTestData), DynamicDataSourceType.Method)]
        public void Addition_Test(Vector v1, Vector v2, Vector expected)
        {
            Vector actual = v1 + v2;
            Assert.IsTrue(NearlyEqualVector(expected, actual));
        }

        public static System.Collections.Generic.IEnumerable<object[]> GetAdditionTestData()
        {
            // Test 1: Components are positive integers
            yield return new object[] { new Vector(1, 6, 2), new Vector(3, 5, 4), new Vector(4, 11, 6) };

            // Test 2: Components are a mix of positive and negative integers
            yield return new object[] { new Vector(-5, 7, 3), new Vector(4, 0, -5), new Vector(-1, 7, -2) };

            // Test 3: Components are a mix of integers and doubles
            yield return new object[] { new Vector(-8, 7.5, 4.2), new Vector(2.5, 1.9, -5.2), new Vector(-5.5, 9.4, -1) };

            // Test 4: Components are doubles
            yield return new object[] { new Vector(1.6, 5.1, 3.3), new Vector(4.1, 2.8, 4.2), new Vector(5.7, 7.9, 7.5) };
        }

        /// <summary>
        /// A custom method to handle the floating point error encountered while comparing doubles.
        /// The defined method checks the precision of the vector components upto eight points.
        /// <summary>
        public bool NearlyEqualVector(Vector v1, Vector v2)
        {
            const double Epsilon = 0.00000001; // Eight point precision is checked
            double absv1X = Math.Abs(v1.X);
            double absv1Y = Math.Abs(v1.Y);
            double absv1Z = Math.Abs(v1.Z);
            double absv2X = Math.Abs(v2.X);
            double absv2Y = Math.Abs(v2.Y);
            double absv2Z = Math.Abs(v2.Z);
            double diff1 = Math.Abs(absv1X - absv2X);
            double diff2 = Math.Abs(absv1Y - absv2Y);
            double diff3 = Math.Abs(absv1Z - absv2Z);

            if (diff1 < Epsilon && diff2 < Epsilon && diff3 < Epsilon)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// A custom method to handle the floating point error encountered while comparing doubles.
        /// The defined method checks the precision of the resulting scalar upto six points.
        /// <summary>
        public bool NearlyEqualScalar(double s1, double s2)
        {
            const double Epsilon = 0.000001; // Six point precision is checked
            double absS1 = Math.Abs(s1);
            double absS2 = Math.Abs(s2);
            double diff = Math.Abs(absS1 - absS2);

            if (diff < Epsilon)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Unit test for testing the subtraction of vectors operation
        /// <summary>
        [DataTestMethod]
        [DynamicData(nameof(GetSubtractionTestData), DynamicDataSourceType.Method)]
        public void Subtraction_Test(Vector v1, Vector v2, Vector expected)
        {
            Vector actual = v1 - v2;
            Assert.IsTrue(NearlyEqualVector(expected, actual));
        }

        public static System.Collections.Generic.IEnumerable<object[]> GetSubtractionTestData()
        {
            // Test 1: Components are positive integers
            yield return new object[] { new Vector(1, 6, 2), new Vector(3, 5, 4), new Vector(-2, 1, -2) };

            // Test 2: Components are a mix of positive and negative integers
            yield return new object[] { new Vector(-5, 7, 3), new Vector(4, 0, -5), new Vector(-9, 7, 8) };

            // Test 3: Components are a mix of integers and doubles
            yield return new object[] { new Vector(-8, 7.5, 4.2), new Vector(2.5, 1.9, -5.2), new Vector(-10.5, 5.6, 9.4) };

            // Test 4: Components are doubles
            yield return new object[] { new Vector(1.6, 5.1, 3.3), new Vector(4.1, 2.8, 4.2), new Vector(-2.5, 2.3, -0.9) };
        }

        /// <summary>
        /// Unit test for testing the multiplication of a vector by a scalar operation
        /// <summary>
        [DataTestMethod]
        [DynamicData(nameof(GetScalarMultiplicationTestData), DynamicDataSourceType.Method)]
        public void ScalarMultiplication_Test(Vector v1, double s1, Vector expected)
        {
            Vector actual = VectorOperations.ScalarMultiplication(v1, s1);
            Assert.IsTrue(NearlyEqualVector(expected, actual));
        }

        public static System.Collections.Generic.IEnumerable<object[]> GetScalarMultiplicationTestData()
        {
            // Test 1: Scalar is a positive integer
            yield return new object[] { new Vector(4, 8, 1), 4, new Vector(16, 32, 4) };

            // Test 2: Scalar is a negative integer
            yield return new object[] { new Vector(2, -3, 7), -5, new Vector(-10, 15, -35) };

            // Test 3: Vector components are double and the scalar is a positive integer
            yield return new object[] { new Vector(2.3, -7.4, 5.1), 6, new Vector(13.8, -44.4, 30.6) };

            // Test 4: Scalar is a positive double
            yield return new object[] { new Vector(3, 8, -2), 2.7, new Vector(8.1, 21.6, -5.4) };

            // Test 5: Scalar is zero
            yield return new object[] { new Vector(3, 8, -2), 0, new Vector(0, 0, 0) };
        }

        /// <summary>
        /// Unit test for testing the division of a vector by a scalar operation
        /// <summary>
        [DataTestMethod]
        [DynamicData(nameof(GetScalarDivisionTestData), DynamicDataSourceType.Method)]
        public void ScalarDivision_Test(Vector v1, double s1, Vector expected)
        {
            Vector actual = VectorOperations.ScalarDivision(v1, s1);
            Assert.IsTrue(NearlyEqualVector(expected, actual));
        }

        public static System.Collections.Generic.IEnumerable<object[]> GetScalarDivisionTestData()
        {
            // Test 1: Scalar is a positive integer
            yield return new object[] { new Vector(4, 8, 1), 4, new Vector(1, 2, 0.25) };

            // Test 2: Scalar is a negative integer
            yield return new object[] { new Vector(2, -3, 7), -5, new Vector(-0.4, 0.6, -1.4) };

            // Test 3: Vector components are double and the scalar is a positive integer
            yield return new object[] { new Vector(2.3, -7.4, 5.1), 6, new Vector(0.38333333, -1.23333333, 0.85) };

            // Test 4: Scalar is a positive double
            yield return new object[] { new Vector(3, 8, -2), 2.7, new Vector(1.11111111, 2.96296296, -0.74074074) };
        }

        /// <summary>
        /// Unit test for testing the division of a vector by a scalar operation, while handling the exception 
        /// when the given scalar is zero.
        /// <summary>
        [TestMethod]
        public void ScalarDivisionZeroException_Test()
        {
            Vector v1 = new Vector(4.7, 3.2, -9);
            double s1 = 0;

            var ex = Assert.ThrowsException<DivideByZeroException>(() => VectorOperations.ScalarDivision(v1, s1));
            Assert.AreEqual("Invalid input: The scalar value cannot be equal to zero.", ex.Message);
        }

        /// <summary>
        /// Unit test for testing the scalar product of two vectors operation
        /// <summary>
        [DataTestMethod]
        [DynamicData(nameof(GetScalarProductTestData), DynamicDataSourceType.Method)]
        public void ScalarProduct_Test(Vector v1, Vector v2, double expected)
        {
            double actual = VectorOperations.ScalarProduct(v1, v2);
            Assert.IsTrue(NearlyEqualScalar(expected, actual));
        }

        public static System.Collections.Generic.IEnumerable<object[]> GetScalarProductTestData()
        {
            // Test 1: Components are positive integers
            yield return new object[] { new Vector(1, 6, 2), new Vector(3, 5, 4), 41 };

            // Test 2: Components are a mix of positive and negative integers
            yield return new object[] { new Vector(-5, 7, 3), new Vector(4, 0, -5), -35 };

            // Test 3: Components are a mix of integers and doubles
            yield return new object[] { new Vector(-8, 7.5, 4.2), new Vector(2.5, 1.9, -5.2), -27.59 };

            // Test 4: Components are doubles
            yield return new object[] { new Vector(1.6, 5.1, 3.3), new Vector(4.1, 2.8, 4.2), 34.7 };
        }

        /// <summary>
        /// Unit test for testing the cross product of two vectors operation
        /// <summary>
        [DataTestMethod]
        [DynamicData(nameof(GetCrossProductTestData), DynamicDataSourceType.Method)]
        public void CrossProduct_Test(Vector v1, Vector v2, Vector expected)
        {
            Vector actual = VectorOperations.CrossProduct(v1, v2);
            Assert.IsTrue(NearlyEqualVector(expected, actual));
        }

        public static System.Collections.Generic.IEnumerable<object[]> GetCrossProductTestData()
        {
            // Test 1: Components are positive integers
            yield return new object[] { new Vector(1, 6, 2), new Vector(3, 5, 4), new Vector(14, 2, -13) };

            // Test 2: Components are a mix of positive and negative integers
            yield return new object[] { new Vector(-5, 7, 3), new Vector(4, 0, -5), new Vector(-35, -13, -28) };

            // Test 3: Components are a mix of integers and doubles
            yield return new object[] { new Vector(-8, 7.5, 4.2), new Vector(2.5, 1.9, -5.2), new Vector(-46.98, -31.1, -33.95) };

            // Test 4: Components are doubles
            yield return new object[] { new Vector(1.6, 5.1, 3.3), new Vector(4.1, 2.8, 4.2), new Vector(12.18, 6.81, -16.43) };
        }

        /// <summary>
        /// Unit test for testing the length or magnitude of a given vector method
        /// <summary>
        [DataTestMethod]
        [DynamicData(nameof(GetLengthOfVectorTestData), DynamicDataSourceType.Method)]
        public void LengthOfVector_Test(Vector v1, double expected)
        {
            double actual = v1.length();
            Assert.IsTrue(NearlyEqualScalar(expected, actual));
        }

        public static System.Collections.Generic.IEnumerable<object[]> GetLengthOfVectorTestData()
        {
            // Test 1: Components are positive integers
            yield return new object[] { new Vector(1, 6, 2), 6.40312423 };

            // Test 2: Components are a mix of positive and negative integers
            yield return new object[] { new Vector(6, 0, -5), 7.81024967 };

            // Test 3: Components are a mix of integers and doubles
            yield return new object[] { new Vector(-8, 7.5, 4.2), 11.74265728 };

            // Test 4: Components are doubles
            yield return new object[] { new Vector(1.6, 5.1, 3.3), 6.28171951 };
        }

        /// <summary>
        /// Unit test for testing the angle between two vectors method
        /// <summary>
        [DataTestMethod]
        [DynamicData(nameof(GetAngleBetweenVectorsTestData), DynamicDataSourceType.Method)]
        public void AngleBetweenVectors_Test(Vector v1, Vector v2, double expected)
        {
            double actual = v1.angleBetween(v2);
            Assert.IsTrue(NearlyEqualScalar(expected, actual));
        }

        public static System.Collections.Generic.IEnumerable<object[]> GetAngleBetweenVectorsTestData()
        {
            // Test 1: Components are positive integers
            yield return new object[] { new Vector(1, 6, 2), new Vector(3, 5, 4), 25.10409008 };

            // Test 2: Components are a mix of positive and negative integers
            yield return new object[] { new Vector(-5, 7, 3), new Vector(4, 0, -5), 126.8684947 };

            // Test 3: Components are a mix of integers and doubles
            yield return new object[] { new Vector(-8, 7.5, 4.2), new Vector(2.5, 1.9, -5.2), 112.7547389 };

            // Test 4: Components are doubles
            yield return new object[] { new Vector(1.6, 5.1, 3.3), new Vector(4.1, 2.8, 4.2), 31.84931796 };
        }

        /// <summary>
        /// Unit test for testing the equality of two vectors method
        /// <summary>
        [DataTestMethod]
        [DynamicData(nameof(GetEqualityOfVectorsTestData), DynamicDataSourceType.Method)]
        public void EqualityOfVectors_Test(Vector v1, Vector v2, bool expected)
        {
            bool actual = v1.Equals(v2);
            Assert.AreEqual(expected, actual);

            actual = v1 == v2;
            Assert.AreEqual(expected, actual);
        }

        public static System.Collections.Generic.IEnumerable<object[]> GetEqualityOfVectorsTestData()
        {
            // Test 1: Components are positive integers
            yield return new object[] { new Vector(1, 6, 2), new Vector(1, 6, 2), true };

            // Test 2: Components are a mix of positive and negative integers
            yield return new object[] { new Vector(-5, 7, -3), new Vector(-5, 7, -3), true };

            // Test 3: Components are a mix of integers and doubles
            yield return new object[] { new Vector(-8, 7.5, 4.2), new Vector(2.5, 1.9, -5.2), false };

            // Test 4: Components are doubles
            yield return new object[] { new Vector(1.6, 5.1, 3.3), new Vector(1.6, 5.1, 3.3), true };

            // Test 5: Components are doubles
            yield return new object[] { new Vector(1.6, 5.1, 3.3), new Vector(0.7, 4.3, 6.2), false };
        }

        /// <summary>
        /// Unit test for testing the inequality of two vectors method
        /// <summary>
        [DataTestMethod]
        [DynamicData(nameof(GetInequalityOfVectorsTestData), DynamicDataSourceType.Method)]
        public void InequalityOfVectors_Test(Vector v1, Vector v2, bool expected)
        {
            bool actual = v1 != v2;
            Assert.AreEqual(expected, actual);
        }

        public static System.Collections.Generic.IEnumerable<object[]> GetInequalityOfVectorsTestData()
        {
            // Test 1: Components are positive integers
            yield return new object[] { new Vector(1, 6, 2), new Vector(1, 6, 2), false };

            // Test 2: Components are a mix of positive and negative integers
            yield return new object[] { new Vector(-5, 7, -3), new Vector(-5, 7, -3), false };

            // Test 3: Components are a mix of integers and doubles
            yield return new object[] { new Vector(-8, 7.5, 4.2), new Vector(2.5, 1.9, -5.2), true };

            // Test 4: Components are doubles
            yield return new object[] { new Vector(1.6, 5.1, 3.3), new Vector(1.6, 5.1, 3.3), false };

            // Test 5: Components are doubles
            yield return new object[] { new Vector(1.6, 5.1, 3.3), new Vector(0.7, 4.3, 6.2), true };
        }

    }
}
