using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditArtefactButton : MonoBehaviour
{
    public int ArtisanIndex;

    private void Awake()
    {
        Button editArtefactButton = GetComponent<Button>();

        editArtefactButton.onClick.RemoveAllListeners();
        editArtefactButton.onClick.AddListener(() =>
        {
            ArtisansUIManager.Instance.EditArtefactButton(ArtisanIndex);
        });
    }
}
