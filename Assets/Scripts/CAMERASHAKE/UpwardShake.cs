using System.Collections;
using UnityEngine;

public class UpwardShake : CameraShake
{
    public float shakeIntensity;
    public float upwardShakeIntensity;
    public float upwardRotationSpeed = 1.0f;

    public delegate void CameraRotationEvent(float extraRotation);
    public static event CameraRotationEvent OnCameraRotationChange;

    public override void Shake()
    {
        StartCoroutine(PerformUpwardShake());
    }

    IEnumerator PerformUpwardShake()
    {
        Quaternion startPosition = Camera.main.transform.localRotation;

        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            // Calculate the upward rotation
            float upwardRotation = Mathf.Sin(Time.time * upwardRotationSpeed) * upwardShakeIntensity;

            Quaternion newRotation = Quaternion.Euler(
                startPosition.eulerAngles.x + upwardRotation, // Rotate upwards
                startPosition.eulerAngles.y + Random.Range(-shakeIntensity, shakeIntensity),
                startPosition.eulerAngles.z + Random.Range(-shakeIntensity, shakeIntensity)
            );

            Camera.main.transform.localRotation = newRotation;

            // Trigger an event for additional rotation
            float extraRotation = Mathf.Sin(Time.time * 2.0f) * 5.0f; // Example additional rotation
            OnCameraRotationChange?.Invoke(extraRotation);

            yield return null;
        }

        Camera.main.transform.localRotation = startPosition;
    }
}
