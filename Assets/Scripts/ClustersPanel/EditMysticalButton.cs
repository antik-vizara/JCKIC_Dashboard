using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditMysticalButton : MonoBehaviour
{
    public int ClusterIndex;

    private void Awake()
    {
        Button editMysticalButton = GetComponent<Button>();

        editMysticalButton.onClick.RemoveAllListeners();
        editMysticalButton.onClick.AddListener(() =>
        {
            ClusterUIManager.Instance.EditMysticalButton(ClusterIndex);
        });
    }
}
