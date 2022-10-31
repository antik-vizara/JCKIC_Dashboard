using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClusterUIManager : UIPanel
{
    public GameObject ClusterPrefab;
    public GameObject ClustersParent;

    public List<ClusterInput> ClustersList;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {

    }

    public void AddCluster()
    {
        int correctIdx = ClustersParent.transform.childCount - 1;
        GameObject newCluster = Instantiate(ClusterPrefab, ClustersParent.transform);
        newCluster.transform.SetSiblingIndex(correctIdx);

        ClustersList.Add(newCluster.GetComponent<ClusterInput>());
    }

    public void SubmitClusters()
    {
        ClustersManager.Instance.ClusterDataMain.Clusters.Clear();
        foreach (ClusterInput clusterInput in ClustersList)
        {
            Cluster cluster = clusterInput.GetCluster();
            Debug.Log("Cluster name = " + cluster.ClusterName);
            ClustersManager.Instance.ClusterDataMain.Clusters.Add(cluster);
        }
        Debug.Log("Clusters count = " + ClustersManager.Instance.ClusterDataMain.Clusters.Count);
        ClustersManager.Instance.SaveToJSON();
    }

    public override void ShowPanel()
    {
        throw new System.NotImplementedException();
    }

    public override void HidePanel()
    {
        throw new System.NotImplementedException();
    }
}
