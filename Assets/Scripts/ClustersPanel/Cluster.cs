using System;
using System.Collections.Generic;

[Serializable]
public class Cluster
{
    private static int InfoCardsCount = 3;
    public string ClusterID;
    public string ClusterName;
    public int NumberOfArtisans;
    public List<Artisan> Artisans;
    public string Info_BodyText;
    public string[] Info_CardHeadings;
    public string[] Info_CardTexts;

    public List<MysticalBook> MysticalBooks;

    public Cluster()
    {
        this.ClusterID = "";
        this.ClusterName = "";
        this.NumberOfArtisans = 0;
        this.Artisans = new List<Artisan>();
        this.MysticalBooks = new List<MysticalBook>();

        this.Info_BodyText = "";
        this.Info_CardHeadings = new string[InfoCardsCount];
        this.Info_CardTexts = new string[InfoCardsCount];
    }

    public Cluster(Cluster copy)
    {
        this.ClusterID = copy.ClusterID;
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

        this.Info_BodyText = copy.Info_BodyText;
        for (int i = 0; i < InfoCardsCount; ++i)
        {
            this.Info_CardHeadings[i] = copy.Info_CardHeadings[i];
            this.Info_CardTexts[i] = copy.Info_CardTexts[i];
        }
    }
}
