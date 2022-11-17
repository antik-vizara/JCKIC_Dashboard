using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DirectJSONMaker : MonoBehaviour
{
    public string ArtifactCSVPath = "C:/Users/MADDY/Downloads/Artifacts-Sheet1.csv";
    public string MysticalCSVPath;
    public string JSONPath;

    private void Start()
    {
        CreateJSON();
    }
    ClusterData clusterData = new ClusterData();

    public void CreateJSON()
    {
        ReadArtifactCSV();
    }

    public void ReadArtifactCSV()
    {
        string[] Lines = System.IO.File.ReadAllLines(ArtifactCSVPath);
        string[] Columns = Lines[0].Split(',');
        for (int i = 1; i <= Lines.Length - 1; i++)
        {
            string[] Fields = Lines[i].Split(',');
            int clusterIndex = GetClusterIndex(Fields[0]);
            int artisanIndex = GetArtisanIndex(clusterIndex, Fields[1]);

            Artefact newArtefact = new Artefact();
            newArtefact.ArtefactName = Fields[2];
            newArtefact.ArtefactSize = Fields[3];
            newArtefact.ArtefactDescription = Fields[4];
            newArtefact.ArtefactDimension = Fields[5];
            newArtefact.ArtefactMaterial = Fields[6];
            newArtefact.ArtefactWeight = Fields[7];
            newArtefact.ArtefactPrice = int.Parse(Fields[8]);

            clusterData.Clusters[clusterIndex].Artisans[artisanIndex].Artefacts.Add(newArtefact);
        }

        for (int i = 0; i < clusterData.Clusters.Count; ++i)
        {
            clusterData.Clusters[i].NumberOfArtisans = clusterData.Clusters[i].Artisans.Count;
            for (int j = 0; j < clusterData.Clusters[i].Artisans.Count; ++j)
            {
                clusterData.Clusters[i].Artisans[j].NumberOfArtifacts = clusterData.Clusters[i].Artisans[j].Artefacts.Count;
            }
        }

        string clusterStringData = JsonUtility.ToJson(clusterData);
        File.WriteAllText(JSONPath, clusterStringData);
    }

    public int GetClusterIndex(string targetClusterName)
    {
        for (int i = 0; i < clusterData.Clusters.Count; ++i)
        {
            if (clusterData.Clusters[i].ClusterName == targetClusterName)
            {
                return i;
            }
        }
        // make new
        Cluster target = new Cluster();
        target.ClusterName = targetClusterName;
        clusterData.Clusters.Add(target);
        return clusterData.Clusters.Count - 1;
    }

    public int GetArtisanIndex(int clusterIndex, string targetArtisanName)
    {
        for (int i = 0; i < clusterData.Clusters[clusterIndex].Artisans.Count; ++i)
        {
            if (clusterData.Clusters[clusterIndex].Artisans[i].ArtisanName == targetArtisanName)
            {
                return i;
            }
        }
        // make new
        Artisan target = new Artisan();
        target.ArtisanName = targetArtisanName;
        clusterData.Clusters[clusterIndex].Artisans.Add(target);
        return clusterData.Clusters[clusterIndex].Artisans.Count - 1;
    }
}
