using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

//Manages data in JSON files
public class ClustersManager : MonoBehaviour
{
    public static ClustersManager Instance;

    public string ClustersJSONPath = "D:/Projects/JCKIC_Data/ClustersData.json";
    public ClusterData ClusterDataMain;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    public void SaveToJSON()
    {
        string clustersData = JsonUtility.ToJson(ClusterDataMain);
        File.WriteAllText(ClustersJSONPath, clustersData);
    }

    public void ReadFromJSON()
    {
        string clusterData = File.ReadAllText(ClustersJSONPath);
        ClusterDataMain = JsonUtility.FromJson<ClusterData>(clusterData);
    }
}

[System.Serializable]
public class ClusterData
{
    public List<Cluster> Clusters = new List<Cluster>();
}
