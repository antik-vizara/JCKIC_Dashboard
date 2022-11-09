using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArtefactInput : MonoBehaviour
{
    public int Index;

    private Artefact _currentArtifact;
    public TMP_InputField ArtefactNameInput;
    public TMP_Dropdown ArtefactSizeInput;
    public TMP_InputField ArtefactDescriptionInput;
    public TMP_InputField ArtefactDimensionInput;
    public TMP_InputField ArtefactMaterialInput;
    public TMP_InputField ArtefactWeightInput;
    public TMP_InputField ArtefactPriceInput;


    private void Awake()
    {
        _currentArtifact = new Artefact();

        ArtefactNameInput.onEndEdit.RemoveAllListeners();
        ArtefactNameInput.onEndEdit.AddListener(delegate { UpdateArtifactName(ArtefactNameInput); });

        ArtefactSizeInput.onValueChanged.RemoveAllListeners();
        ArtefactSizeInput.onValueChanged.AddListener(delegate { UpdateArtefactSize(ArtefactSizeInput); });

        ArtefactDescriptionInput.onEndEdit.RemoveAllListeners();
        ArtefactDescriptionInput.onEndEdit.AddListener(delegate { UpdateArtefactDescription(ArtefactDescriptionInput); });

        ArtefactDimensionInput.onEndEdit.RemoveAllListeners();
        ArtefactDimensionInput.onEndEdit.AddListener(delegate { UpdateArtefactDimension(ArtefactDimensionInput); });

        ArtefactMaterialInput.onEndEdit.RemoveAllListeners();
        ArtefactMaterialInput.onEndEdit.AddListener(delegate { UpdateArtefactMaterial(ArtefactMaterialInput); });

        ArtefactWeightInput.onEndEdit.RemoveAllListeners();
        ArtefactWeightInput.onEndEdit.AddListener(delegate { UpdateArtefactWeight(ArtefactWeightInput); });

        ArtefactPriceInput.onEndEdit.RemoveAllListeners();
        ArtefactPriceInput.onEndEdit.AddListener(delegate { UpdateArtefactPrice(ArtefactPriceInput); });
    }

    public void SetIndex(int index)
    {
        Index = index;
    }

    #region Update
    public void UpdateData()
    {
        ClustersManager.Instance.MainData.Clusters[ArtisansUIManager.Instance.CurrentClusterIndex].Artisans[ArtifactsUIManager.Instance.CurrentArtisanIndex].Artefacts[Index] = _currentArtifact;
    }

    public void UpdateArtifactName(TMP_InputField input)
    {
        _currentArtifact.ArtefactName = input.text;
        UpdateData();
    }

    public void UpdateArtefactSize(TMP_Dropdown input)
    {
        _currentArtifact.ArtefactSize = input.options[input.value].text;
        UpdateData();
    }

    public void UpdateArtefactDescription(TMP_InputField input)
    {
        _currentArtifact.ArtefactDescription = input.text;
        UpdateData();
    }

    public void UpdateArtefactDimension(TMP_InputField input)
    {
        _currentArtifact.ArtefactDimension = input.text;
        UpdateData();
    }

    public void UpdateArtefactMaterial(TMP_InputField input)
    {
        _currentArtifact.ArtefactMaterial = input.text;
        UpdateData();
    }

    public void UpdateArtefactWeight(TMP_InputField input)
    {
        _currentArtifact.ArtefactWeight = input.text;
        UpdateData();
    }

    public void UpdateArtefactPrice(TMP_InputField input)
    {
        _currentArtifact.ArtefactPrice = int.Parse(input.text);
        UpdateData();
    }
    #endregion


    #region Set
    public void SetArtefactName(string input)
    {
        ArtefactNameInput.text = input;
        _currentArtifact.ArtefactName = input;
    }

    public void SetArtefactSize(string input)
    {
        int correctValueIndex = 0;
        for (int i = 0; i < ArtefactSizeInput.options.Count; ++i)
        {
            Debug.Log("Checking " + input + " vs " + ArtefactSizeInput.options[i].text);
            if (input == ArtefactSizeInput.options[i].text)
            {
                correctValueIndex = i;
                break;
            }
        }

        ArtefactSizeInput.value = correctValueIndex;
        _currentArtifact.ArtefactSize = input;
    }

    public void SetArtefactDescription(string input)
    {
        ArtefactDescriptionInput.text = input;
        _currentArtifact.ArtefactDescription = input;
    }

    public void SetArtefactDimension(string input)
    {
        ArtefactDimensionInput.text = input;
        _currentArtifact.ArtefactDimension = input;
    }

    public void SetArtefactMaterial(string input)
    {
        ArtefactMaterialInput.text = input;
        _currentArtifact.ArtefactMaterial = input;
    }

    public void SetArtefactWeight(string input)
    {
        ArtefactWeightInput.text = input;
        _currentArtifact.ArtefactWeight = input;
    }

    public void SetArtefactPrice(int input)
    {
        ArtefactPriceInput.text = input.ToString();
        _currentArtifact.ArtefactPrice = input;
    }
    #endregion

    public Artefact GetArtifact()
    {
        return _currentArtifact;
    }
}
