using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class StyleDataManager : MonoBehaviour
{
    public static StyleDataManager Instance;

    private string styleLibraryRootPath = "E:/Antik/JCKIC_Data/StyleLibrary/";
    private string styleName = "BoneAndHorn";

    private ModelUploader _modelUploader = new ModelUploader();
    private bool _uploadingStyle = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    public void StoreStyleElement(UnityWebRequest modelWeb)
    {
        if (!_uploadingStyle)
        {
            _uploadingStyle = true;
            StartCoroutine(StoreStyle(modelWeb));
        }
    }

    private IEnumerator StoreStyle(UnityWebRequest modelWeb)
    {
        string path = styleLibraryRootPath + styleName;

        Debug.Log("Looking for directory");
        if (!Directory.Exists(path))
        {
            Debug.Log("Created directory");
            Directory.CreateDirectory(path);
        }
        else
        {
            Debug.Log("Directory exists");
        }

        Debug.Log("Type recieved =" + modelWeb.GetType());
        yield return null;
    }
}
