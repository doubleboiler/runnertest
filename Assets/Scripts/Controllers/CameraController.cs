using UnityEngine;

public class CameraController : MonoBehaviour
{
    [HideInInspector]
    public Transform target;

    [SerializeField]
    private Vector3 offsetPosition;

    [SerializeField]
    private Space offsetPositionSpace = Space.Self;

    [SerializeField]
    private bool lookAt = true;

    public bool startLookAt;

    private void Update()
    {
        Refresh();
    }

    public void StartLookAt()
    {
        startLookAt = true;
    }

    public void Refresh()
    {
        if (target == null || !startLookAt)
        {
            return;
        }

        if (offsetPositionSpace == Space.Self)
        {
            transform.position = target.TransformPoint(offsetPosition);
        }
        else
        {
            transform.position = target.position + offsetPosition;
        }

        if (lookAt)
        {
            transform.rotation = Quaternion.Euler(30f, 0, 0);
        }

        else
        {
            transform.rotation = target.rotation;
        }
    }
}
