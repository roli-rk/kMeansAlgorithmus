using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kMeansAlgorithmus
{
  public class Point3D
  {
    private double x;
    private double y;
    private double z;
    public Point3D(double _x, double _y, double _z)
    {
      x = _x;
      y = _y;
      z = _z;
    }

    public double GetX()
    {
      return x;
    }

    public double GetY()
    {
      return y;
    }

    public double GetZ()
    {
      return z;
    }

    public double distance(Point3D center)
    {
      int potenz = 2;
      return Math.Sqrt(Math.Pow((z - center.GetZ()), potenz) + Math.Pow((y - center.GetY()), potenz) + Math.Pow((x - center.GetX()), potenz));
    }
    public override string ToString()
    {
      return "x: " + x + " y: " + y + " z: " + z;
    }
  }
}
