using System;

[Serializable]
public class Artefact
{
    public string ArtefactID;
    public string ArtefactName;
    public string ArtefactCategory;
    public string ArtefactSize;
    public string ArtefactDescription;
    public string ArtefactDimension;
    public string ArtefactMaterial;
    public string ArtefactWeight;
    public int ArtefactPrice;
    public string ArtefactLink;

    public Artefact()
    {
        this.ArtefactID = "";
        this.ArtefactName = "";
        this.ArtefactCategory = "";
        this.ArtefactSize = "";
        this.ArtefactDescription = "";
        this.ArtefactDimension = "";
        this.ArtefactMaterial = "";
        this.ArtefactWeight = "";
        this.ArtefactPrice = 0;
        this.ArtefactLink = "";
    }

    public Artefact(Artefact copy)
    {
        this.ArtefactID = copy.ArtefactID;
        this.ArtefactName = copy.ArtefactName;
        this.ArtefactCategory = copy.ArtefactCategory;
        this.ArtefactSize = copy.ArtefactSize;
        this.ArtefactDescription = copy.ArtefactDescription;
        this.ArtefactDimension = copy.ArtefactDimension;
        this.ArtefactMaterial = copy.ArtefactMaterial;
        this.ArtefactWeight = copy.ArtefactWeight;
        this.ArtefactPrice = copy.ArtefactPrice;
        this.ArtefactLink = copy.ArtefactLink;
    }
}
