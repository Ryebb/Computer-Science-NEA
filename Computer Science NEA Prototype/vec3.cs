using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Vec3
{
	private double x;
    private double y;
    private double z;

    public Vec3()
    {
        x = 0;
        y = 0;
        z = 0;
    }

    public Vec3(double x, double y, double z)
	{
        this.x = x;
        this.y = y;
        this.z = z;
	}

    public double X
    { get => x; set => x = value; }

    public double Y
    { get => y; set => y = value; }

    public double Z
    { get => z; set => z = value; }

    public Vec3 Negate()
    { return new Vec3(-x, -y, -z); }

    public Vec3 Add(Vec3 a)
    { return new Vec3(x + a.x, y + a.y, z + a.z); }

    public Vec3 Subtract(Vec3 a)
    { return new Vec3(x - a.x, y - a.y, z - a.z); }

    public Vec3 Scalar_Multiply(double a)
    { return new Vec3(x * a, y * a, z * a); }

    public Vec3 Scalar_Divide(double a)
    { return new Vec3(x * (1 / a), y * (1 / a), z * (1 / a)); }

    public double Length()
    { return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2)); }

    public double Squared_Length()
    { return Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2); }

    public double Dot(Vec3 a)
    { return x * a.x + y * a.y + z * a.z; }

    public Vec3 Cross(Vec3 a)
    { return new Vec3(y * a.z - z * a.y, z * a.x - x * a.z, x * a.y - y * a.z); }

    public Vec3 Hadamard(Vec3 a)
    { return new Vec3 (x * a.x, y * a.y, z * a.z); }

    public Vec3 Unit_Vector()
    {
        Scalar_Divide(Length());
        return this;
    }
}
