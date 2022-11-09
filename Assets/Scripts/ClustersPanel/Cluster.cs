using System;
using System.Collections.Generic;

[Serializable]
public class Cluster
{
    public string ClusterName;
    public int NumberOfArtisans;
    public List<Artisan> Artisans;

    public List<MysticalBook> MysticalBooks;

    public Cluster()
    {
        this.ClusterName = "NewCluster";
        this.NumberOfArtisans = 0;
        this.Artisans = new List<Artisan>();
        this.MysticalBooks = new List<MysticalBook>();
    }

    public Cluster(Cluster copy)
    {
        this.ClusterName = copy.ClusterName;
        this.NumberOfArtisans = copy.NumberOfArtisans;
        this.Artisans = new List<Artisan>();
        for (int i = 0; i < copy.Artisans.Count; ++i)
        {
            this.Artisans.Add(new Artisan(copy.Artisans[i]));
        }
        this.MysticalBooks = new List<MysticalBook>();
        for (int i = 0; i < copy.MysticalBooks.Count; ++i)
        {
            this.MysticalBooks.Add(new MysticalBook(copy.MysticalBooks[i]));
        }
    }
}
