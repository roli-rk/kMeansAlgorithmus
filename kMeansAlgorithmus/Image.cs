using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kMeansAlgorithmus
{
  class Image
  {
    string imgURL;
    Bitmap image;
    Bitmap newImage;
    int width;
    int height;

    public Image(string IMG_URL)
    {
      imgURL = IMG_URL;
      image = new Bitmap(imgURL);
      width = image.Width;
      height = image.Height;
      newImage = new Bitmap(width, height);
    }


    // extrahiere pixel und speichere diese in die eingabevektoren
    public void setInput(Input eingabevektoren)
    {
      for (int y = 0; y < height; y++)
      {
        for (int x = 0; x < width; x++)
        {
          //get pixel value
          Color p = image.GetPixel(x, y);

          //extract RGB value from p
          int a = p.A;
          int red = p.R;
          int green = p.G;
          int blue = p.B;

          eingabevektoren.AddPoint(new Point3D((double)red, (double)green, (double)blue));
        }
      }
    }

    public void SaveNewImage(Cluster[] clusters, string url)
    {
      for (int y = 0; y < height; y++)
      {
        for (int x = 0; x < width; x++)
        {
          Color p = image.GetPixel(x, y); // hole farben aus pixel
          int a = p.A;
          int red = p.R;
          int green = p.G;
          int blue = p.B;
          Point3D pointClusterCentre = clusters[0].GetZentrum();
          Point3D actualPoint = new Point3D(red, green, blue);
          double minColorDistance = actualPoint.distance(pointClusterCentre);
          if (clusters.Length>1)
          {
            for (int i = 1; i < clusters.Length; i++)
            {
              double tmpColorDistance = actualPoint.distance(clusters[i].GetZentrum());
              if (tmpColorDistance < minColorDistance)
              {
                pointClusterCentre = clusters[i].GetZentrum();
                minColorDistance = tmpColorDistance;
              }
            }
            int newRed = (int)pointClusterCentre.GetX();
            int newGreen = (int)pointClusterCentre.GetY();
            int newBlue = (int)pointClusterCentre.GetZ();
            newImage.SetPixel(x, y, Color.FromArgb(a, newRed, newGreen, newBlue));

          }
        }
      }

      // Bild Speichern
      string[] urlParts = url.Split('\\');
      string newUrl="";
      for (int i = 0; i < urlParts.Length-1; i++)
      {
        newUrl +=  urlParts[i] + "\\";
      }
      string imageName = urlParts[urlParts.Length - 1];
      string[] imageNameParts = imageName.Split('.');
      newUrl +=  imageNameParts[0] + "_mit_" + Program.clusterzentren + "_Farben" + ".jpg";
      newImage.Save(@newUrl);
      Console.WriteLine("Bild wurde gespeichert unter: " + newUrl);
    }
  }
}
