using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kMeansAlgorithmus
{
  public class Point2D
  {
    private double x;
    private double y;
    public Point2D(double _x, double _y)
    {
      x = _x;
      y = _y;
    }

    public double GetX()
    {
      return x;
    }

    public double GetY()
    {
      return y;
    }

    public double distance(Point2D center)
    {
      int potenz = 2;
      return Math.Sqrt(Math.Pow((y - center.GetY()), potenz) + Math.Pow((x - center.GetX()), potenz));
    }
    public override string ToString()
    {
      return "x: " + x + " y: " + y;
    }
  }
}
