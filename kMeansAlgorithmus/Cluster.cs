using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kMeansAlgorithmus
{
  public class Cluster
  {
    private Point3D zentrum;
    private Point3D schwerpunkt;

    public Cluster(Point3D zentrum)
    {
      this.zentrum = zentrum;
    }

    class ClusterListe
    {
      public Point3D point;
      public ClusterListe next;
      public ClusterListe(Point3D newPoint)
      {
        point = newPoint;
      }
    }

    ClusterListe start, end;

    public void AddPoint(Point3D newPoint)
    {
      ClusterListe neu = new ClusterListe(newPoint);
      if (start == null)
      {
        start = end = neu;
      }
      else
      {
        end.next = neu;
        end = neu;
      }
    }

    public Point3D GetZentrum()
    {
      return zentrum;
    }
    public Point3D GetSchwerpunkt()
    {
      return schwerpunkt;
    }
    public void SetZentrum(Point3D newZentrum)
    {
      zentrum = newZentrum;
    }

    public void setSchwerpunkt()
    {
      // new mass centre
      double x = 0;
      double y = 0;
      double z = 0;
      int anz = 0;
      for (ClusterListe tmp = start; tmp != null; tmp = tmp.next)
      {
        x += tmp.point.GetX();
        y += tmp.point.GetY();
        z += tmp.point.GetZ();
        anz++;
      }
      schwerpunkt = new Point3D(x / anz, y / anz, z / anz);

      //-------------------------------------------------
      // new Point next to mass centre
      Console.WriteLine("Zentrum alt: " + zentrum);
      double distance;
      if (start != null)
      {
        distance = start.point.distance(schwerpunkt);
        zentrum = start.point;
        for (ClusterListe tmp = start.next; tmp != null; tmp = tmp.next)
        {
          double tmpDistance = tmp.point.distance(schwerpunkt);
          if (tmpDistance < distance)
          {
            zentrum = tmp.point;
            distance = tmpDistance;
          }
        }
      }
      else
        Console.WriteLine("Fehler"); distance = 0;




      Console.WriteLine("Zentrum neu: " + zentrum);
      Console.WriteLine("Schwerpunkt: " + schwerpunkt);
      Console.WriteLine("Distanz schwerpunkt: " + distance);
    }
    public void Print()
    {
      Console.WriteLine("----------");
      Console.WriteLine("Zentrum: " + zentrum);
      for (ClusterListe tmp = start; tmp != null; tmp = tmp.next)
      {
        Console.WriteLine("Punkt: " + tmp.point);
      }
    }

  }
}
