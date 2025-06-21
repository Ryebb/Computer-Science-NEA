using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Point3 = Vec3;

namespace NEA_prototype_V1._2
{
    class Ray
    {
        private Point3 orig;
        private Vec3 dir;
        public Ray(Point3 origin, Vec3 direction)
        {
            orig = origin;
            dir = direction;
        }

        public Point3 At(double t)
        {
            return orig.Add(dir.Scalar_Multiply(t));
        }
    }
}
