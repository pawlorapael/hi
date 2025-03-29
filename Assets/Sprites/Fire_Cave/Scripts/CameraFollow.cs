using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 
    public float smoothSpeed = 5f;
    private Vector3 offset;

    private Vector3 shakeOffset = Vector3.zero; 

    void Start()
    {
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset + shakeOffset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }

    public void ApplyShake(Vector3 shakeAmount)
    {
        shakeOffset = shakeAmount;
    }
}
