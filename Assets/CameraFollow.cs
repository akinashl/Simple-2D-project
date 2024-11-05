using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTarget;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void LateUpdate()
    {
        Vector3 targetPosition = followTarget.position;
        targetPosition.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
    public void SwithCameraTargets(Transform newCameraTarget)
    {
        followTarget = newCameraTarget;
    }
}
