using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARAnchorManager))]
public class AnchorController : MonoBehaviour
{
    private ARAnchorManager anchorManager;
    public Camera arCamera;
    public GameObject anchorPrefab;

    void Awake()
    {
        anchorManager = GetComponent<ARAnchorManager>();
    }

    public void AddAnchor(Vector3 position)
    {
        Pose pose = new Pose(position, Quaternion.identity);
        ARAnchor anchor = anchorManager.AddAnchor(pose);
        if (anchor == null)
        {
            Debug.Log("Anchor could not be created.");
        }
        else
        {
            Debug.Log("Anchor created.");
            if (anchorPrefab != null)
            {
                Instantiate(anchorPrefab, anchor.transform.position, anchor.transform.rotation);
            }
        }
    }
}
