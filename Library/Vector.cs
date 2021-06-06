using System;

namespace Library
{
    /// <summary>
    ///  This struct creates the immutable vector object.
    /// </summary>
    public struct Vector
    {
        private readonly double _x;
        private readonly double _y;
        private readonly double _z;

        public double X { get { return this._x; } }
        public double Y { get { return this._y; } }
        public double Z { get { return this._z; } }

        public Vector(double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        /// <summary>
        /// Returns the length or magnitude of the given vector v1
        /// </summary>
        public double length()
        {
            double resultantScalar = Math.Sqrt(Math.Pow(this.X, 2) + Math.Pow(this.Y, 2) + Math.Pow(this.Z, 2));
            return resultantScalar;
        }

        /// <summary>
        /// Returns the angle between two vectors v1 and v2
        /// </summary>
        public double angleBetween(Vector v)
        {
            double lengthOfVector1 = this.length();
            double lengthOfVector2 = v.length();
            double dotProductOfVectors = (this.X * v.X) + (this.Y * v.Y) + (this.Z * v.Z);
            double angleBetweenVectors = Math.Acos(dotProductOfVectors / (lengthOfVector1 * lengthOfVector2)) * (180 / Math.PI);
            return angleBetweenVectors;
        }

        /// <summary>
        /// Overloading the Addition operator
        /// </summary>
        public static Vector operator +(Vector v1, Vector v2)
        {
            Vector resultantVector = new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
            return resultantVector;
        }

        /// <summary>
        /// Overloading the Subtraction operator
        /// </summary>
        public static Vector operator -(Vector v1, Vector v2)
        {
            Vector resultantVector = new Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
            return resultantVector;
        }

        /// <summary>
        /// Overloading the Equals operator
        /// </summary>
        public static bool operator ==(Vector v1, Vector v2)
        {
            if (v1.length() == v2.length() && v1.angleBetween(v2) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Overloading the Not-Equals operator
        /// </summary>
        public static bool operator !=(Vector v1, Vector v2)
        {
            if (v1.length() != v2.length() || v1.angleBetween(v2) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Overloading the Built-in Equals operator
        /// </summary>
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Vector v = (Vector)obj;
                return this == v;
            }
        }

        /// <summary>
        /// Overriding and generating a unique Hashcode for the vector objects
        /// </summary>
        public override int GetHashCode()
        {
            return (this.X.GetHashCode() % this.Y.GetHashCode()) + (this.Y.GetHashCode() % this.Z.GetHashCode())
                + (this.Z.GetHashCode() % this.X.GetHashCode());
        }

    }
}
