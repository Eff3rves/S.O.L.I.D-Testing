using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinShake : CameraShake
{
    public float shakeIntensity = 1.0f;
    public float frequency = 25.0f;
    public float amplitude = 0.1f;

    public override void Shake()
    {
        StartCoroutine(PerformPerlinNoiseShake());
    }

    IEnumerator PerformPerlinNoiseShake()
    {
        Vector3 startPosition = Camera.main.transform.localPosition;
        Vector3 randomOffset = Vector3.zero;

        float elapsedTime = 0.0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            // Use Perlin noise to generate smooth random values over time
            randomOffset.x = Mathf.PerlinNoise(Time.time * frequency, 0) * amplitude * shakeIntensity;
            randomOffset.y = Mathf.PerlinNoise(0, Time.time * frequency) * amplitude * shakeIntensity;
            randomOffset.z = Mathf.PerlinNoise(Time.time * frequency, Time.time * frequency) * amplitude * shakeIntensity;

            Camera.main.transform.localPosition = startPosition + randomOffset;

            yield return null;
        }

        // Ensure the camera returns to its original position
        Camera.main.transform.localPosition = startPosition;
    }
}
