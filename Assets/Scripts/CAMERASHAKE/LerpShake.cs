using UnityEngine;
using System.Collections;

public class LerpShake : CameraShake
{
    public float shakeIntensity;

    public override void Shake()
    {
        StartCoroutine(PerformLerpShake());
    }

    IEnumerator PerformLerpShake()
    {
        Quaternion startPosition = Camera.main.transform.localRotation;
        Quaternion targetRotation = Quaternion.identity;

        float elapsedTime = 0.0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            float randomX = Random.Range(-shakeIntensity, shakeIntensity);
            float randomY = Random.Range(-shakeIntensity, shakeIntensity);
            float randomZ = Random.Range(-shakeIntensity, shakeIntensity);

            // Generate a random rotation offset
            Quaternion randomOffset = Quaternion.Euler(randomX, randomY, randomZ);

            // Interpolate between the start position and the randomly generated offset
            targetRotation = Quaternion.Lerp(startPosition, randomOffset, elapsedTime / duration);

            Camera.main.transform.localRotation = targetRotation;

            yield return null;
        }

        // Ensure the camera returns to its original rotation
        Camera.main.transform.localRotation = startPosition;
    }
}

