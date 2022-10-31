using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using TriLibCore;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

// Uploads model
public class ModelUploader : MonoBehaviour
{
    public void UploadModel()
    {
        FileUploaderHelper.RequestFile((path) =>
        {
            if (string.IsNullOrWhiteSpace(path))
                return;

            StartCoroutine(UploadModelCoroutine(path));
        });
    }

    private IEnumerator UploadModelCoroutine(string path)
    {
        using (UnityWebRequest modelWeb = new UnityWebRequest(path, UnityWebRequest.kHttpVerbGET))
        {
            // modelWeb.downloadHandler = new DownloadHandlerFile(targetLocationPath);

            // yield return modelWeb.SendWebRequest();

            StyleDataManager.Instance.StoreStyleElement(modelWeb);
        }
        yield return null;
    }
}