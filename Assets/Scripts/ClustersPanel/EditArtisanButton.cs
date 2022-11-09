using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditArtisanButton : MonoBehaviour
{
    public int ClusterIndex;

    private void Awake()
    {
        Button editArtisanButton = GetComponent<Button>();

        editArtisanButton.onClick.RemoveAllListeners();
        editArtisanButton.onClick.AddListener(() =>
        {
            ClusterUIManager.Instance.EditArtisanButton(ClusterIndex);
        });
    }
}
