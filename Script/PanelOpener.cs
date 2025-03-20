using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Panel2;
    public GameObject Panel3;

    public void OpenPanel()
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;

            Panel.SetActive(!isActive);
        }
    }

    public void ClosePanel()
    {
        if (Panel2 != null)
        {
            Panel2.SetActive(false);
        }
        if (Panel3 != null)
        {
            Panel3.SetActive(false);
        }
    }

    public void ToggleCanvas(int canvasNumber)
    {
        switch (canvasNumber)
        {
            case 1:
                Panel.SetActive(true);
                Panel2.SetActive(false);
                Panel3.SetActive(false);
                break;
            case 2:
                Panel.SetActive(false);
                Panel2.SetActive(true);
                Panel3.SetActive(false);
                break;
            case 3:
                Panel.SetActive(false);
                Panel2.SetActive(false);
                Panel3.SetActive(true);
                break;
            default:
                Debug.LogWarning("Invalid canvas number");
                break;
        }
    }
}
