using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtisansUIManager : UIPanel
{
    public int CurrentClusterIndex;

    public GameObject ArtisanPrefab;
    public GameObject ArtisanParent;

    public List<ArtisanInput> ArtisansList;

    public override void HidePanel()
    {
        throw new System.NotImplementedException();
    }

    public override void ShowPanel()
    {
        throw new System.NotImplementedException();
    }

    private void Start()
    {
        ArtisansList = new List<ArtisanInput>();
    }
}
