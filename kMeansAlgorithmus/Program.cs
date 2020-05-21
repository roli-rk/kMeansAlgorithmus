using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace kMeansAlgorithmus
{
  class Program
  {
    public static int maximumPixel = 100; // für Aufgabe 1. Maximale Pixel je Dimension
    public static int clusterzentren;
    public static int maxNumberOfWalkThrough;


    static void Main(string[] args)
    {
      Input eingabevektoren = new Input();

      Console.Write("Anzahl Clusterzentren:");
      clusterzentren = Convert.ToInt32(Console.ReadLine());
      Cluster[] clusters = new Cluster[clusterzentren];

      Console.Write("Anzahl Durchgänge:");
      maxNumberOfWalkThrough = Convert.ToInt32(Console.ReadLine());

      
      ////Aufgabe 1 a)
      //for (int x = 0; x < maximumPixel; x++)
      //{
      //  for (int y = 0; y  < maximumPixel; y ++)
      //  {
      //    for (int z = 0; z < maximumPixel; z++)
      //    {
      //      eingabevektoren.AddPoint(new Point3D(x, y,z));
      //    }
      //  }
      //}

      // Aufgabe 1 b)
      Console.WriteLine("Bitte absolute des Bildes angeben");
      Console.WriteLine("z.B. C:\\Users\\Roland\\Pictures\\img.jpg");
      //C:\Users\\Roli\\Pictures\\test2.jpg
      string url = Console.ReadLine();
      Image image = new Image(@url);

      // extract pixel from image
      image.setInput(eingabevektoren);

      void setCluter()
      {
        Input tmp = eingabevektoren;
        Cluster[] tmpCluster = new Cluster[clusterzentren];

        //Set only centre from tmp Cluster
        for (int i = 0; i < clusterzentren; i++)
        {
          tmpCluster[i] = new Cluster(clusters[i].GetZentrum());
        }

        // Allocat Point to Cluster where distance to Cluster centre is the most minimal
        for (int i = 0; i < clusterzentren; i++)
        {
          tmp.SetDistance(tmpCluster[i].GetZentrum(), i);
        }

        // Add Point to allocated Cluster
        for (int i = 0; i < clusterzentren; i++)
        {
          tmp.SetCluster(tmpCluster[i], i);
        }

        // Set Cluster mass centre & new Point next to mass centre for each cluster
        for (int i = 0; i < clusterzentren; i++)
        {
          tmpCluster[i].setSchwerpunkt();
        }

        clusters = tmpCluster;
      }

      Random zufall = new Random();

      for (int i = 0; i < clusterzentren; i++)
      {
        Point3D randomCenter = setRandomClusterCentre(i);

        clusters[i] = new Cluster(randomCenter);
      }

      Point3D setRandomClusterCentre (int index)
      {
        Point3D randomCenter = eingabevektoren.GetRandomCenter();
        for (int j = 0; j < index; j++)
        {
          if (clusters[j].GetZentrum() == randomCenter)
          {
            setRandomClusterCentre(index);
            break;
          }
        }
        return randomCenter;
      }

      for (int i = 0; i < maxNumberOfWalkThrough; i++)
      {
        Console.WriteLine("Durchgang: " + i);
        setCluter();
        Console.WriteLine("--------------------------------------");
      }

      image.SaveNewImage(clusters, url);

    }
  }
}
