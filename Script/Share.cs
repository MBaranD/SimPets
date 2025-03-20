using UnityEngine;
using UnityEngine.UI;

public class Share : MonoBehaviour
{
    public string linkToShare = "www.iku.edu.tr";

    void Start()
    {
        // Button and click
        Button shareButton = GetComponent<Button>();
        if (shareButton != null)
        {
            shareButton.onClick.AddListener(OnShareButtonClick);
        }
        else
        {
            Debug.LogError("ShareButton script is attached to a GameObject without a Button component!");
        }
    }

    void OnShareButtonClick()
    {
        // Copy link to clipboard
        GUIUtility.systemCopyBuffer = linkToShare;

        // Show the message
        Debug.Log("Link copied to clipboard: " + linkToShare);
    }
}
