using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace kMeansAlgorithmus
{
  class Input
  {
    private int countPixle = 0;
    private class InputList
    {
      public Point3D point;
      public InputList next;
      public double distanceClusterCenter;
      public int cluster;
      public InputList(Point3D newPoint)
      {
        point = newPoint;
      }
    }

    InputList start, end;
    Random zufall = new Random();

    public void AddPoint(Point3D newPoint)
    {
      InputList neu = new InputList(newPoint);
      if (start == null)
      {
        start = end = neu;
      }
      else
      {
        end.next = neu;
        end = neu;
      }
      countPixle++;
    }

    public Point3D GetRandomCenter()
    {
      InputList tmp = start;
      int position = zufall.Next(0, countPixle);
      for (int i = 0; i < position; i++)
      {
        tmp = tmp.next;
      }
      Thread.Sleep(10);
      return tmp.point;
    }

    public void SetDistance(Point3D center, int cluster)
    {
      if(cluster == 0)
      {
        for (InputList tmp = start; tmp != null; tmp = tmp.next)
        {
          tmp.distanceClusterCenter = tmp.point.distance(center);
          tmp.cluster = cluster;
        }
      }
      else
      {
        for (InputList tmp = start; tmp != null; tmp = tmp.next)
        {
          double tmpDistance = tmp.point.distance(center);
          if (tmpDistance < tmp.distanceClusterCenter)
          {
            tmp.distanceClusterCenter = tmpDistance;
            tmp.cluster = cluster;
          }
        }
      }
    }

    public void SetCluster(Cluster cluster, int index)
    {
      for (InputList tmp = start; tmp != null; tmp = tmp.next)
      {
        if (tmp.cluster == index)
        {
          cluster.AddPoint(tmp.point);
        }
      }
    }

    public void Print()
    {
      for (InputList tmp = start; tmp != null; tmp = tmp.next)
      {
        Console.WriteLine("Punkt: " + tmp.point + " Distanz zum Zentrum: " + tmp.distanceClusterCenter);
      }
    }
  }
}
