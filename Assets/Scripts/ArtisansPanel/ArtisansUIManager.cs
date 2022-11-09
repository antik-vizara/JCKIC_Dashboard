using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtisansUIManager : UIPanel
{
    public static ArtisansUIManager Instance;

    public int CurrentClusterIndex;     // Cluster for which artisans list is being editted

    public GameObject ArtisanPrefab;
    public GameObject ArtisanParent;

    public List<ArtisanInput> ArtisansList = new List<ArtisanInput>();


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    public override void HidePanel()
    {
        throw new System.NotImplementedException();
    }

    public override void ShowPanel()
    {
        throw new System.NotImplementedException();
    }

    private void OnEnable()
    {
        Initialize();
    }

    public void Initialize()
    {
        if (!ClustersManager.Instance)
        {
            return;
        }
        ResetArtisanPanel();
        foreach (Artisan artisan in ClustersManager.Instance.MainData.Clusters[CurrentClusterIndex].Artisans)
        {
            AddArtisan();
            ArtisansList[ArtisansList.Count - 1].SetArtisanName(artisan.ArtisanName);
            ArtisansList[ArtisansList.Count - 1].SetArtefactCount(artisan.NumberOfArtifacts);
        }
    }

    public void AddArtisan()
    {
        int correctIdx = ArtisanParent.transform.childCount - 1;
        GameObject newArtisan = Instantiate(ArtisanPrefab, ArtisanParent.transform);
        newArtisan.transform.SetSiblingIndex(ArtisansList.Count);
        newArtisan.GetComponent<ArtisanInput>().SetIndex(ArtisansList.Count);

        ArtisansList.Add(newArtisan.GetComponent<ArtisanInput>());
        if (ArtisansList.Count > ClustersManager.Instance.MainData.Clusters[ArtisansUIManager.Instance.CurrentClusterIndex].Artisans.Count)
        {
            ClustersManager.Instance.MainData.Clusters[ArtisansUIManager.Instance.CurrentClusterIndex].Artisans.Add(new Artisan());
            ClustersManager.Instance.MainData.Clusters[ArtisansUIManager.Instance.CurrentClusterIndex].NumberOfArtisans++;
        }
    }

    public void SubmitArtisans()
    {
        ResetArtisanPanel();
        UIManager.Instance.ArtisanPanel.SetActive(false);
        UIManager.Instance.ClusterPanel.SetActive(true);
    }

    public void ResetArtisanPanel()
    {
        foreach (ArtisanInput artisanInput in ArtisansList)
        {
            Destroy(artisanInput.gameObject);
        }
        ArtisansList.Clear();
    }

    public void EditArtefactButton(int artisanIndex)
    {
        ArtifactsUIManager.Instance.CurrentArtisanIndex = artisanIndex;
        UIManager.Instance.ArtifactsPanel.SetActive(true);
        UIManager.Instance.ArtisanPanel.SetActive(false);
    }
}
