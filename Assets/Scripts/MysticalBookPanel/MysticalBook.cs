using System;
using UnityEngine;

[Serializable]
public class MysticalBook
{
    public string PageID;
    public string Heading;
    public string SubHeading;
    public string BodyText;

    public MysticalBook()
    {
        this.PageID = "";
        this.Heading = "";
        this.SubHeading = "";
        this.BodyText = "";
    }

    public MysticalBook(MysticalBook copy)
    {
        this.PageID = copy.PageID;
        this.Heading = copy.Heading;
        this.SubHeading = copy.SubHeading;
        this.BodyText = copy.BodyText;

        Debug.Log(copy);
    }
}
