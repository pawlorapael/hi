using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    private CameraFollow cameraFollow;
    private Vector3 originalOffset;

    void Start()
    {
        cameraFollow = GetComponent<CameraFollow>();
        if (cameraFollow == null)
        {
            Debug.LogError("CameraFollow script not found!");
        }
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            Vector3 shakeAmount = new Vector3(
                Random.Range(-1f, 1f) * magnitude,
                Random.Range(-1f, 1f) * magnitude,
                0f
            );

            cameraFollow.ApplyShake(shakeAmount);

            elapsed += Time.deltaTime;
            yield return null;
        }

        cameraFollow.ApplyShake(Vector3.zero);
    }
}
