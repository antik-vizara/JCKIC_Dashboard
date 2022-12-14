using System;
using System.Collections.Generic;

[Serializable]
public class Artisan
{
    private static int StoryCount = 4;
    public string ArtisanID;
    public string ArtisanBio;
    public string ArtisanShortBio;
    public string ArtisanName;
    public int NumberOfArtifacts;
    public List<Artefact> Artefacts;
    public string[] StoryHeadings;
    public string[] StoryTexts;

    public Artisan()
    {
        this.ArtisanID = "";
        this.ArtisanBio = "";
        this.ArtisanShortBio = "";
        this.ArtisanName = "";
        this.NumberOfArtifacts = 0;
        this.Artefacts = new List<Artefact>();
        this.StoryHeadings = new string[StoryCount];
        this.StoryTexts = new string[StoryCount];
    }

    public Artisan(Artisan copy)
    {
        this.ArtisanID = copy.ArtisanID;
        this.ArtisanBio = copy.ArtisanBio;
        this.ArtisanShortBio = copy.ArtisanShortBio;
        this.ArtisanName = copy.ArtisanName;
        this.NumberOfArtifacts = copy.NumberOfArtifacts;
        this.Artefacts = new List<Artefact>();
        for (int i = 0; i < copy.Artefacts.Count; ++i)
        {
            this.Artefacts.Add(new Artefact(copy.Artefacts[i]));
        }

        for (int i = 0; i < StoryCount; ++i)
        {
            this.StoryHeadings[i] = copy.StoryHeadings[i];
            this.StoryTexts[i] = copy.StoryTexts[i];
        }
    }
}
