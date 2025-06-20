using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

public class Vec3
{
	private double x;
    private double y;
    private double z;

    public Vec3(double x, double y, double z)
	{
        this.x = x;
        this.y = y;
        this.z = z;
	}

    public Vec3 Add(Vec3 a, Vec3 b)
    {
        Vec3 result = new Vec3(a.x + b.x, a.y + b.y, a.z + b.z);
        return result;
    }

    public Vec3 Subtract(Vec3 a, Vec3 b)
    {
        Vec3 result = new Vec3(a.x - b.x, a.y - b.y, a.z - b.z);
        return result;
    }

    public Vec3 Scalar_Multiply(Vec3 a, int b)
    {
        Vec3 result = new Vec3(a.x * b, a.y * b, a.z * b);
        return result;
    }

    public Vec3 Scalar_Divide(Vec3 a, int b)
    {
        Vec3 result = new Vec3(a.x * (1 / b), a.y * (1 / b), a.z * (1 / b));
        return result;
    }

    public double Length(Vec3 a)
    {
        double result = Math.Sqrt(Math.Pow(a.x, 2) + Math.Pow(a.y, 2) + Math.Pow(a.z, 2));
        return result;
    }
}
