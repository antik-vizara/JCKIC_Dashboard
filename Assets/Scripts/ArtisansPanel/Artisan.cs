using System;
using System.Collections.Generic;

[Serializable]
public class Artisan
{
    public string ArtisanName;
    public int NumberOfArtifacts;
    public List<Artefact> Artefacts;

    public Artisan()
    {
        this.ArtisanName = "NewArtisan";
        this.NumberOfArtifacts = 0;
        this.Artefacts = new List<Artefact>();
    }

    public Artisan(Artisan copy)
    {
        this.ArtisanName = copy.ArtisanName;
        this.NumberOfArtifacts = copy.NumberOfArtifacts;
        this.Artefacts = new List<Artefact>();
        for (int i = 0; i < copy.Artefacts.Count; ++i)
        {
            this.Artefacts.Add(new Artefact(copy.Artefacts[i]));
        }
    }
}
