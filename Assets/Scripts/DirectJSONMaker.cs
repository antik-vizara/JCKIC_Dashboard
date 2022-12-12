using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public class DirectJSONMaker : MonoBehaviour
{
    public string ClusterCSVPath = "";
    public string ArtisansCSVPath = "";
    public string ArtifactsCSVPath = "";
    public string MysticalCSVPath = "";
    public string JSONPath;

    private Dictionary<string, int> ClustersIndexDict = new Dictionary<string, int>();
    private Dictionary<string, int> ArtisanIndexDict = new Dictionary<string, int>();

    private void Start()
    {
        CreateJSON();
    }
    ClusterData clusterData = new ClusterData();

    public void CreateJSON()
    {
        fgCSVReader.LoadFromFile(ClusterCSVPath, new fgCSVReader.ReadLineDelegate(ReadClustersCSV));
        fgCSVReader.LoadFromFile(MysticalCSVPath, new fgCSVReader.ReadLineDelegate(ReadMysticalCSV));
        fgCSVReader.LoadFromFile(ArtisansCSVPath, new fgCSVReader.ReadLineDelegate(ReadArtisansCSV));
        fgCSVReader.LoadFromFile(ArtifactsCSVPath, new fgCSVReader.ReadLineDelegate(ReadArtifactsCSV));

        string clusterStringData = JsonUtility.ToJson(clusterData);
        File.WriteAllText(JSONPath, clusterStringData);
    }

    void ReadLineTest(int line_index, List<string> line)
    {
        Debug.Log("\n==> Line {0}, {1} column(s)" + line_index + " " + line.Count);
        for (int i = 1; i < line.Count; i++)
        {
            Debug.Log("Cell {0}: *{1}*" + i + " " + line[i]);
        }
    }

    private void ReadClustersCSV(int line_index, List<string> line)
    {
        if (line_index == 0)
        {
            return;
        }

        Cluster newCluster = new Cluster();

        newCluster.NumberOfArtisans = 0;

        newCluster.ClusterID = line[0];
        newCluster.ClusterName = line[1];
        newCluster.Info_BodyText = line[3];
        newCluster.Info_CardHeadings[0] = line[4];
        newCluster.Info_CardTexts[0] = line[5];
        newCluster.Info_CardHeadings[1] = line[6];
        newCluster.Info_CardTexts[1] = line[7];
        newCluster.Info_CardHeadings[2] = line[8];
        newCluster.Info_CardTexts[2] = line[9];

        clusterData.Clusters.Add(newCluster);
        ClustersIndexDict.Add(newCluster.ClusterID, clusterData.Clusters.Count - 1);
    }

    private void ReadMysticalCSV(int line_index, List<string> line)
    {
        if (line_index == 0)
        {
            return;
        }

        MysticalBook newMysticalBook = new MysticalBook();

        string currentClusterId = line[0];
        if (!ClustersIndexDict.ContainsKey(currentClusterId))
        {
            Debug.Log("Cluster " + currentClusterId + " not found");
            return;
        }

        newMysticalBook.PageID = line[1];
        newMysticalBook.Heading = line[2];
        newMysticalBook.SubHeading = line[3];
        newMysticalBook.BodyText = line[4];

        clusterData.Clusters[ClustersIndexDict[currentClusterId]].MysticalBooks.Add(newMysticalBook);
    }

    private void ReadArtisansCSV(int line_index, List<string> line)
    {
        if (line_index == 0)
        {
            return;
        }

        string currentClusterId = line[0];
        if (!ClustersIndexDict.ContainsKey(currentClusterId))
        {
            Debug.Log("Cluster " + currentClusterId + " not found");
            return;
        }
        int clusterIndex = ClustersIndexDict[currentClusterId];

        Artisan newArtisan = new Artisan();
        newArtisan.ArtisanID = line[1];
        newArtisan.ArtisanName = line[2];
        // newArtisan.NumberOfArtifacts = int.Parse(line[3]);
        newArtisan.NumberOfArtifacts = 0;
        newArtisan.StoryHeadings[0] = line[4];
        newArtisan.StoryTexts[0] = line[5];
        newArtisan.StoryHeadings[1] = line[6];
        newArtisan.StoryTexts[1] = line[7];
        newArtisan.StoryHeadings[2] = line[8];
        newArtisan.StoryTexts[2] = line[9];
        newArtisan.StoryHeadings[3] = line[10];
        newArtisan.StoryTexts[3] = line[11];
        newArtisan.ArtisanBio = line[12];
        newArtisan.ArtisanShortBio = line[13];

        clusterData.Clusters[clusterIndex].Artisans.Add(newArtisan);
        clusterData.Clusters[clusterIndex].NumberOfArtisans++;
        ArtisanIndexDict.Add(newArtisan.ArtisanID, clusterData.Clusters[clusterIndex].Artisans.Count - 1);
    }

    private void ReadArtifactsCSV(int line_index, List<string> line)
    {
        if (line_index == 0)
        {
            return;
        }

        string currentClusterId = line[0];
        if (!ClustersIndexDict.ContainsKey(currentClusterId))
        {
            Debug.Log("Cluster " + currentClusterId + " not found");
            return;
        }
        int clusterIndex = ClustersIndexDict[currentClusterId];

        string currentArtisanId = line[1];
        if (!ArtisanIndexDict.ContainsKey(currentArtisanId))
        {
            Debug.Log("Artisan " + currentArtisanId + " not found");
            return;
        }
        int artisanIndex = ArtisanIndexDict[currentArtisanId];

        Artefact newArtefact = new Artefact();
        newArtefact.ArtefactID = line[2];
        newArtefact.ArtefactName = line[3];
        newArtefact.ArtefactCategory = line[4];
        newArtefact.ArtefactSize = line[5];
        newArtefact.ArtefactDescription = line[6];
        newArtefact.ArtefactDimension = line[7];
        newArtefact.ArtefactMaterial = line[8];
        newArtefact.ArtefactWeight = line[9];

        int price;
        if (int.TryParse(line[10], NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out price))
        {
            newArtefact.ArtefactPrice = price;
        }
        else
        {
            newArtefact.ArtefactPrice = -1;
        }

        if (line.Count == 12 && line[11] != "")
        {
            //Debug.Log(line[11]);
            newArtefact.ArtefactLink = line[11];
        }
        else
        {
            newArtefact.ArtefactLink = "https://cdacae.myshopify.com";
        }

        clusterData.Clusters[clusterIndex].Artisans[artisanIndex].Artefacts.Add(newArtefact);
        clusterData.Clusters[clusterIndex].Artisans[artisanIndex].NumberOfArtifacts++;
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
