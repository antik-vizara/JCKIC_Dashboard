using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactsUIManager : MonoBehaviour
{
    public static ArtifactsUIManager Instance;

    public int CurrentArtisanIndex;
    public GameObject ArtifactPrefab;
    public GameObject ArtifactParent;
    public List<ArtefactInput> ArtifactsList = new List<ArtefactInput>();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
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
        ResetArtifactPanel();
        List<Artefact> currentArtefacts = ClustersManager.Instance.GetTempData().Clusters[ArtisansUIManager.Instance.CurrentClusterIndex].Artisans[CurrentArtisanIndex].Artefacts;
        foreach (Artefact artefact in currentArtefacts)
        {
            AddArtefact();
            ArtifactsList[ArtifactsList.Count - 1].SetArtefactName(artefact.ArtefactName);
            ArtifactsList[ArtifactsList.Count - 1].SetArtefactSize(artefact.ArtefactSize);
            ArtifactsList[ArtifactsList.Count - 1].SetArtefactDescription(artefact.ArtefactDescription);
            ArtifactsList[ArtifactsList.Count - 1].SetArtefactDimension(artefact.ArtefactDimension);
            ArtifactsList[ArtifactsList.Count - 1].SetArtefactMaterial(artefact.ArtefactMaterial);
            ArtifactsList[ArtifactsList.Count - 1].SetArtefactWeight(artefact.ArtefactWeight);
            ArtifactsList[ArtifactsList.Count - 1].SetArtefactPrice(artefact.ArtefactPrice);
        }
    }

    public void AddArtefact()
    {
        int correctIdx = ArtifactParent.transform.childCount - 1;
        GameObject newArtifact = Instantiate(ArtifactPrefab, ArtifactParent.transform);
        newArtifact.transform.SetSiblingIndex(ArtifactsList.Count);
        newArtifact.GetComponent<ArtefactInput>().SetIndex(ArtifactsList.Count);

        ArtifactsList.Add(newArtifact.GetComponent<ArtefactInput>());
        if (ArtifactsList.Count > ClustersManager.Instance.MainData.Clusters[ArtisansUIManager.Instance.CurrentClusterIndex].Artisans[CurrentArtisanIndex].Artefacts.Count)
        {
            ClustersManager.Instance.MainData.Clusters[ArtisansUIManager.Instance.CurrentClusterIndex].Artisans[CurrentArtisanIndex].Artefacts.Add(new Artefact());
            ClustersManager.Instance.MainData.Clusters[ArtisansUIManager.Instance.CurrentClusterIndex].Artisans[CurrentArtisanIndex].NumberOfArtifacts++;
        }
    }

    public void SubmitArtifact()
    {
        ResetArtifactPanel();
        UIManager.Instance.ArtifactsPanel.SetActive(false);
        UIManager.Instance.ArtisanPanel.SetActive(true);
    }

    public void ResetArtifactPanel()
    {
        foreach (ArtefactInput artefactInput in ArtifactsList)
        {
            Destroy(artefactInput.gameObject);
        }
        ArtifactsList.Clear();
    }
}
