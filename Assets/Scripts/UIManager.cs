using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject ArtisanPanel;
    public GameObject ArtifactsPanel;
    public GameObject ClusterPanel;
    public GameObject MainPanel;

    public GameObject MysticalBookPanel;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        MainPanel.SetActive(true);
        ClusterPanel.SetActive(false);
        ArtisanPanel.SetActive(false);
        ArtifactsPanel.SetActive(false);
        MysticalBookPanel.SetActive(false);
    }
}
