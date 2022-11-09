using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MysticalBookInput : MonoBehaviour
{
    public int Index;

    private MysticalBook _currentMysticalBook;
    public TMP_InputField PageIDInput;
    public TMP_InputField HeadingInput;
    public TMP_InputField SubHeadingInput;
    public TMP_InputField BodyTextInput;


    private void Awake()
    {
        _currentMysticalBook = new MysticalBook();

        PageIDInput.onEndEdit.RemoveAllListeners();
        PageIDInput.onEndEdit.AddListener(delegate { UpdatePageID(PageIDInput); });

        HeadingInput.onEndEdit.RemoveAllListeners();
        HeadingInput.onEndEdit.AddListener(delegate { UpdateHeading(HeadingInput); });

        SubHeadingInput.onEndEdit.RemoveAllListeners();
        SubHeadingInput.onEndEdit.AddListener(delegate { UpdateSubHeading(SubHeadingInput); });

        BodyTextInput.onEndEdit.RemoveAllListeners();
        BodyTextInput.onEndEdit.AddListener(delegate { UpdateBodyText(BodyTextInput); });
    }

    public void SetIndex(int index)
    {
        Index = index;
    }

    #region Update
    public void UpdateData()
    {
        ClustersManager.Instance.MainData.Clusters[ArtisansUIManager.Instance.CurrentClusterIndex].MysticalBooks[MysticalBookUIManager.Instance.CurrentMysticalBookIndex] = _currentMysticalBook;
    }

    public void UpdatePageID(TMP_InputField input)
    {
        _currentMysticalBook.PageID = input.text;
        UpdateData();
    }

    public void UpdateHeading(TMP_InputField input)
    {
        _currentMysticalBook.Heading = input.text;
        UpdateData();
    }

    public void UpdateSubHeading(TMP_InputField input)
    {
        _currentMysticalBook.SubHeading = input.text;
        UpdateData();
    }

    public void UpdateBodyText(TMP_InputField input)
    {
        _currentMysticalBook.BodyText = input.text;
        UpdateData();
    }

    #endregion


    #region Set
    public void SetPageID(string input)
    {
        PageIDInput.text = input;
        _currentMysticalBook.PageID = input;
    }

    public void SetHeading(string input)
    {
        HeadingInput.text = input;
        _currentMysticalBook.Heading = input;
    }

    public void SetSubHeading(string input)
    {
        SubHeadingInput.text = input;
        _currentMysticalBook.Heading = input;
    }

    public void SetBodyText(string input)
    {
        BodyTextInput.text = input;
        _currentMysticalBook.BodyText = input;
    }

    #endregion

    public MysticalBook GetMysticalBook()
    {
        return _currentMysticalBook;
    }
}
