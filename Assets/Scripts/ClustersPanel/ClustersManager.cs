using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

//Manages data in JSON files
public class ClustersManager : MonoBehaviour
{
    public static ClustersManager Instance;

    public string ClustersJSONPath = "E:/UnityProjects/JCKIC_Data/ClustersData.json";
    [HideInInspector]
    public ClusterData MainData;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        ReadFromJSON();
    }

    public ClusterData GetTempData()
    {
        return new ClusterData(MainData);
    }

    public void SaveToJSON()
    {
        string clustersData = JsonUtility.ToJson(MainData);
        File.WriteAllText(ClustersJSONPath, clustersData);
    }

    public void ReadFromJSON()
    {
        string clusterData = File.ReadAllText(ClustersJSONPath);
        MainData = JsonUtility.FromJson<ClusterData>(clusterData);
    }
}

[System.Serializable]
public class ClusterData
{
    public List<Cluster> Clusters;
    public List<MysticalBook> MysticalBooks;

    public ClusterData()
    {
        this.Clusters = new List<Cluster>();
        this.MysticalBooks = new List<MysticalBook>();
    }

    public ClusterData(ClusterData copy)
    {
        this.Clusters = new List<Cluster>();
        for (int i = 0; i < copy.Clusters.Count; ++i)
        {
            this.Clusters.Add(new Cluster(copy.Clusters[i]));
        }

        this.MysticalBooks = new List<MysticalBook>();
        for (int i = 0; i < copy.MysticalBooks.Count; ++i)
        {
            this.MysticalBooks.Add(new MysticalBook(copy.MysticalBooks[i]));
        }
    }
}
