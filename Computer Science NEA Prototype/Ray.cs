using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vector3 = Vec3;
using Point3 = Vec3;

namespace NEA_prototype_V1._2
{
    class Ray
    {
        private Point3 orig;
        private Vector3 dir;
        public Ray(Point3 origin, Vector3 direction)
        {
            orig = origin;
            dir = direction;
        }

        public Vector3 Dir
        { get => dir; set => dir = value; }

        public Point3 Orig
        { get => orig; set => orig = value; }

        public Point3 At(double t)
        {
            return orig.Add(dir.Scalar_Multiply(t));
        }
    }
}
