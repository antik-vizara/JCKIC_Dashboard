using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClusterInput : MonoBehaviour
{
    private Cluster _currentCluster;

    public TMP_InputField ClusterNameInput;
    public TMP_InputField ArtisanCountInput;

    private void Start()
    {
        _currentCluster = new Cluster();

        ClusterNameInput.onEndEdit.RemoveAllListeners();
        ClusterNameInput.onEndEdit.AddListener(delegate { UpdateClusterName(ClusterNameInput); });

        ArtisanCountInput.onEndEdit.RemoveAllListeners();
        ArtisanCountInput.onEndEdit.AddListener(delegate { UpdateArtisansCount(ArtisanCountInput); });
    }

    public void UpdateClusterName(TMP_InputField input)
    {
        _currentCluster.ClusterName = input.text;
    }

    public void UpdateArtisansCount(TMP_InputField input)
    {
        _currentCluster.NumberOfArtisans = int.Parse(input.text);
    }

    public Cluster GetCluster()
    {
        return _currentCluster;
    }
}