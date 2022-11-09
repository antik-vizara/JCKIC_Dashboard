using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysticalBookUIManager : MonoBehaviour
{
    public static MysticalBookUIManager Instance;

    public int CurrentMysticalBookIndex;
    public GameObject MysticalBookPrefab;
    public GameObject MysticalBookParent;
    public List<MysticalBookInput> MysticalBookList = new List<MysticalBookInput>();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    private void OnEnable()
    {
        Initialize();
    }

    public void Initialize()
    {
        if (!ClustersManager.Instance)
        {
            return;
        }
        ResetMysticalBookPanel();
        List<MysticalBook> currentMysticalBook = ClustersManager.Instance.MainData.Clusters[ArtisansUIManager.Instance.CurrentClusterIndex].MysticalBooks;
        foreach (MysticalBook mysticalBook in currentMysticalBook)
        {
            AddMysticalBook();
            MysticalBookList[MysticalBookList.Count - 1].SetPageID(mysticalBook.PageID);
            MysticalBookList[MysticalBookList.Count - 1].SetHeading(mysticalBook.Heading);
            MysticalBookList[MysticalBookList.Count - 1].SetSubHeading(mysticalBook.SubHeading);
            MysticalBookList[MysticalBookList.Count - 1].SetBodyText(mysticalBook.BodyText);
        }
    }

    public void AddMysticalBook()
    {
        int correctIdx = MysticalBookParent.transform.childCount - 1;
        GameObject newMysticalBook = Instantiate(MysticalBookPrefab, MysticalBookParent.transform);
        newMysticalBook.transform.SetSiblingIndex(MysticalBookList.Count);
        newMysticalBook.GetComponent<MysticalBookInput>().SetIndex(MysticalBookList.Count);

        MysticalBookList.Add(newMysticalBook.GetComponent<MysticalBookInput>());
        if (MysticalBookList.Count > ClustersManager.Instance.GetTempData().Clusters[ArtisansUIManager.Instance.CurrentClusterIndex].MysticalBooks.Count)
        {
            ClustersManager.Instance.MainData.Clusters[ArtisansUIManager.Instance.CurrentClusterIndex].MysticalBooks.Add(new MysticalBook());
            //ClustersManager.Instance.MainData.Clusters[ArtisansUIManager.Instance.CurrentClusterIndex].Artisans[CurrentMysticalBookIndex].NumberOfArtifacts++;
        }
    }

    public void SubmitMysticalBook()
    {
        ResetMysticalBookPanel();
        UIManager.Instance.MysticalBookPanel.SetActive(false);
        UIManager.Instance.ClusterPanel.SetActive(true);
    }

    public void ResetMysticalBookPanel()
    {
        foreach (MysticalBookInput mysticalBookInput in MysticalBookList)
        {
            Destroy(mysticalBookInput.gameObject);
        }
        MysticalBookList.Clear();
    }
}
