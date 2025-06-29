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
        private double a;
        private double b;
        private double c;
        private double d;
        private double e;
        private double f;
        private double g;
        private double h;
        private double i;

        public Matrix3()
        {
            a = 1;
            b = 0;
            c = 0;
            d = 0;
            e = 1;
            f = 0;
            g = 0;
            h = 0;
            i = 1;
        }

        public Matrix3(double a, double b, double c, double d, double e, double f, double g, double h, double i)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.e = e;
            this.f = f;
            this.g = g;
            this.h = h;
            this.i = i;
        }

        public double A
        { get => a; set => a = value; }

        public double B
        { get => b; set => b = value; }

        public double C
        { get => c; set => c = value; }

        public double D
        { get => d; set => d = value; }

        public double E
        { get => e; set => e = value; }

        public double F
        { get => f; set => f = value; }

        public double G
        { get => g; set => g = value; }

        public double H
        { get => h; set => h = value; }

        public double I
        { get => i; set => i = value; }

        public Matrix1 Pre_Multiply(Vec3 v)
        { return new Matrix1(v.X*a + v.Y*d + v.Z*g, v.X * b + v.Y * e + v.Z * h, v.X * c + v.Y * f + v.Z * i); }
    }
}