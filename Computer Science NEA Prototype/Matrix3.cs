using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector3 = Vec3;
using Matrix1 = Vec3;

namespace NEA_prototype_V1._2
{
    class Matrix3
    {
        private double[,] matrix3 = new double[3, 3];

        public Matrix3()
        {
            matrix3[0, 0] = 1;
            matrix3[1, 1] = 1;
            matrix3[2, 2] = 1;
        }

        public Matrix3(double[,] matrix3)
        {
            this.matrix3 = matrix3;
        }

        public double Get(int row, int column)
        { return matrix3[row, column]; }

        public void Set(int row, int column, double value)
        { matrix3[row, column] = value; }

        public Matrix1 Pre_Multiply(Vec3 v)
        { return new Matrix1(v.X * (matrix3[0, 0] + matrix3[0, 1] + matrix3[0, 2]), v.Y * (matrix3[1, 0] + matrix3[1, 1] + matrix3[1, 2]), v.Z * (matrix3[2, 0] + matrix3[2, 1] + matrix3[2, 2])); }
    }
}