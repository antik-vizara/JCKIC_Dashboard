using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArtisanInput : MonoBehaviour
{
    public int Index;

    private Artisan _currentArtisan;
    public TMP_InputField ArtisanNameInput;
    public TMP_InputField ArtefactCountInput;
    public EditArtefactButton EditArtifact;

    private void Awake()
    {
        _currentArtisan = new Artisan();

        ArtisanNameInput.onEndEdit.RemoveAllListeners();
        ArtisanNameInput.onEndEdit.AddListener(delegate { UpdateArtisansName(ArtisanNameInput); });

        // ArtefactCountInput.onEndEdit.RemoveAllListeners();
        // ArtefactCountInput.onEndEdit.AddListener(delegate { UpdateArtefactCount(ArtefactCountInput); });
    }

    public void SetIndex(int index)
    {
        Index = index;
        EditArtifact.ArtisanIndex = index;
    }

    public void UpdateData()
    {
        ClustersManager.Instance.MainData.Clusters[ArtisansUIManager.Instance.CurrentClusterIndex].Artisans[Index] = _currentArtisan;
    }

    public void UpdateArtisansName(TMP_InputField input)
    {
        _currentArtisan.ArtisanName = input.text;
        UpdateData();
    }

    public void UpdateArtefactCount(TMP_InputField input)
    {
        _currentArtisan.NumberOfArtifacts = int.Parse(input.text);
        // TODO update Artifacts list
        UpdateData();
    }

    public void SetArtisanName(string artisanName)
    {
        ArtisanNameInput.text = artisanName;
        _currentArtisan.ArtisanName = artisanName;
    }

    public void SetArtefactCount(int artefactCount)
    {
        // ArtefactCountInput.text = artefactCount.ToString();
        // _currentArtisan.NumberOfArtifacts = artefactCount;
        ArtefactCountInput.text = ClustersManager.Instance.MainData.Clusters[ArtisansUIManager.Instance.CurrentClusterIndex].Artisans[Index].NumberOfArtifacts.ToString();
    }

    public Artisan GetArtisan()
    {
        return _currentArtisan;
    }
}
