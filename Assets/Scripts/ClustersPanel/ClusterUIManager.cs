using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClusterUIManager : UIPanel
{
    public static ClusterUIManager Instance;

    public GameObject ClusterPrefab;
    public GameObject ClustersParent;

    public List<ClusterInput> ClustersList = new List<ClusterInput>();


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
        ResetClusterPanel();
        // Debug.Log("Clusters count = " + ClustersManager.Instance.MainData.Clusters.Count);
        foreach (Cluster cluster in ClustersManager.Instance.MainData.Clusters)
        {
            AddCluster();
            Debug.Log("Count : " + cluster.NumberOfArtisans);
            ClustersList[ClustersList.Count - 1].SetClusterName(cluster.ClusterName);
            ClustersList[ClustersList.Count - 1].SetArtisanCount(cluster.NumberOfArtisans);
        }
    }

    public void AddCluster()
    {
        int correctIdx = ClustersParent.transform.childCount - 1;
        GameObject newCluster = Instantiate(ClusterPrefab, ClustersParent.transform);
        newCluster.transform.SetSiblingIndex(correctIdx);

        // Defining cluster index for new cluster to properly add artisans data
        newCluster.GetComponent<ClusterInput>().SetIndex(ClustersList.Count);

        ClustersList.Add(newCluster.GetComponent<ClusterInput>());
        if (ClustersList.Count > ClustersManager.Instance.MainData.Clusters.Count)
        {
            ClustersManager.Instance.MainData.Clusters.Add(new Cluster());
        }
    }

    public void SubmitClusters()
    {
        ResetClusterPanel();

        ClustersManager.Instance.SaveToJSON();
        UIManager.Instance.ClusterPanel.SetActive(false);
        UIManager.Instance.MainPanel.SetActive(true);

    }

    public void ResetClusterPanel()
    {
        foreach (ClusterInput clusterInput in ClustersList)
        {
            Destroy(clusterInput.gameObject);
        }
        ClustersList.Clear();
    }

    public override void ShowPanel()
    {
        throw new System.NotImplementedException();
    }

    public override void HidePanel()
    {
        throw new System.NotImplementedException();
    }

    public void EditArtisanButton(int clusterIndex)
    {
        Debug.Log("Index is " + clusterIndex);
        ArtisansUIManager.Instance.CurrentClusterIndex = clusterIndex;
        UIManager.Instance.ArtisanPanel.SetActive(true);
        UIManager.Instance.ClusterPanel.SetActive(false);
    }

    public void EditMysticalButton(int clusterIndex)
    {
        Debug.Log("Index is " + clusterIndex);
        ArtisansUIManager.Instance.CurrentClusterIndex = clusterIndex;
        UIManager.Instance.MysticalBookPanel.SetActive(true);
        UIManager.Instance.ClusterPanel.SetActive(false);
    }
}
