using System;

[Serializable]
public class Artefact
{
    public string ArtefactName;
    public string ArtefactSize;
    public string ArtefactDescription;
    public string ArtefactDimension;
    public string ArtefactMaterial;
    public string ArtefactWeight;
    public int ArtefactPrice;

    public Artefact()
    {
        this.ArtefactName = "";
        this.ArtefactSize = "";
        this.ArtefactDescription = "";
        this.ArtefactDimension = "";
        this.ArtefactMaterial = "";
        this.ArtefactWeight = "";
        this.ArtefactPrice = 0;
    }

    public Artefact(Artefact copy)
    {
        this.ArtefactName = copy.ArtefactName;
        this.ArtefactSize = copy.ArtefactSize;
        this.ArtefactDescription = copy.ArtefactDescription;
        this.ArtefactDimension = copy.ArtefactDimension;
        this.ArtefactMaterial = copy.ArtefactMaterial;
        this.ArtefactWeight = copy.ArtefactWeight;
        this.ArtefactPrice = copy.ArtefactPrice;
    }
}
