using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClusterInput : MonoBehaviour
{
    private Cluster _currentCluster;

    public int Index;

    public TMP_InputField ClusterNameInput;
    public TMP_InputField ArtisanCountInput;
    public EditArtisanButton EditArtisan;

    private void Awake()
    {
        _currentCluster = new Cluster();

        ClusterNameInput.onEndEdit.RemoveAllListeners();
        ClusterNameInput.onEndEdit.AddListener(delegate { UpdateClusterName(ClusterNameInput); });

        // ArtisanCountInput.onEndEdit.RemoveAllListeners();
        // ArtisanCountInput.onEndEdit.AddListener(delegate { UpdateArtisansCount(ArtisanCountInput); });
    }

    public void SetIndex(int index)
    {
        Index = index;
        EditArtisan.ClusterIndex = index;
    }

    public void UpdateData()
    {
        ClustersManager.Instance.MainData.Clusters[Index] = _currentCluster;
    }

    public void UpdateClusterName(TMP_InputField input)
    {
        _currentCluster.ClusterName = input.text;
        UpdateData();
    }

    public void UpdateArtisansCount(TMP_InputField input)
    {
        _currentCluster.NumberOfArtisans = int.Parse(input.text);
        // TODO update Artisans list
        UpdateData();
    }

    public void SetClusterName(string clusterName)
    {
        ClusterNameInput.text = clusterName;
        _currentCluster.ClusterName = clusterName;
    }

    public void SetArtisanCount(int artisanCount)
    {
        ArtisanCountInput.text = artisanCount.ToString();
        _currentCluster.NumberOfArtisans = artisanCount;
        // ArtisanCountInput.text = ClustersManager.Instance.MainData.Clusters[ArtisansUIManager.Instance.CurrentClusterIndex].NumberOfArtisans.ToString();
    }

    public Cluster GetCluster()
    {
        return _currentCluster;
    }
}