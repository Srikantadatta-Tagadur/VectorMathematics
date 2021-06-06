using System;

namespace Library
{
    public class VectorOperations
    {
        /// <summary>
        /// Returns the inverse or negation of a vector by reversing the sign of the given vector components
        /// <summary>
        public static Vector Negation(Vector v1)
        {
            Vector resultantVector = new Vector(-1 * v1.X, -1 * v1.Y, -1 * v1.Z);
            return resultantVector;
        }

        /// <summary>
        /// Returns the resultant vector after multiplying the given vector components with the given scalar
        /// <summary>
        public static Vector ScalarMultiplication(Vector v1, double s)
        {
            Vector resultantVector = new Vector(v1.X * s, v1.Y * s, v1.Z * s);
            return resultantVector;
        }

        /// <summary>
        /// Returns the resultant vector after dividing the given vector components with the given scalar
        /// <summary>
        public static Vector ScalarDivision(Vector v1, double s)
        {
            if (s == 0)
            {
                throw new DivideByZeroException("Invalid input: The scalar value cannot be equal to zero.");
            }
            Vector resultantVector = new Vector(v1.X / s, v1.Y / s, v1.Z / s);
            return resultantVector;
        }

        /// <summary>
        /// Returns the resulting scalar after performing the scalar product of two vectors v1 and v2
        /// <summary>
        public static double ScalarProduct(Vector v1, Vector v2)
        {
            double resultantScalar = (v1.X * v2.X) + (v1.Y * v2.Y) + (v1.Z * v2.Z);
            return resultantScalar;
        }

        /// <summary>
        /// Returns the resulting vector after performing the cross product of two vectors v1 and v2
        /// <summary>
        public static Vector CrossProduct(Vector v1, Vector v2)
        {
            Vector resultantVector = new Vector(1 * ((v1.Y * v2.Z) - (v2.Y * v1.Z)), -1 * ((v1.X * v2.Z) - (v2.X * v1.Z)),
                1 * ((v1.X * v2.Y) - (v2.X * v1.Y)));
            return resultantVector;
        }

    }
}
