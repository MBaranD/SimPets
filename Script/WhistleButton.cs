using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARAnchorManager))]
public class WhistleButton : MonoBehaviour
{
    private ARAnchorManager _anchorManager;
    private ARAnchor _anchor;

    void Awake()
    {
        _anchorManager = GetComponent<ARAnchorManager>();
    }

    public void AddAnchor(Vector3 position)
    {
        if (_anchor != null)
        {
            Destroy(_anchor.gameObject);
        }

        ARAnchor anchor = _anchorManager.AddAnchor(new Pose(position, Quaternion.identity));
        if (anchor == null)
        {
            Debug.Log("Anchor could not be created.");
        }
        else
        {
            _anchor = anchor;
            Debug.Log("Anchor created.");
        }
    }
}