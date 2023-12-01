using System.Collections;
using UnityEngine;

public class UpwardShake : CameraShake
{
    public float shakeIntensity;
    public float upwardShakeIntensity;
    public float upwardRotationSpeed = 5;

    public delegate void CameraRotationEvent(float extraRotation);
    public static event CameraRotationEvent OnCameraRotationChange;

    public override void Shake()
    {


        StartCoroutine(PerformUpwardShake());
    }

    IEnumerator PerformUpwardShake()
    {
 

        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            Quaternion startPosition = Camera.main.transform.localRotation;
            elapsedTime += Time.deltaTime;

            // Calculate the upward rotation
            float upwardRotation = upwardShakeIntensity;

            Quaternion newRotation = Quaternion.Euler(
                startPosition.eulerAngles.x + upwardRotation, // Rotate upwards
                startPosition.eulerAngles.y + Random.Range(-shakeIntensity, shakeIntensity),
                startPosition.eulerAngles.z + Random.Range(-shakeIntensity, shakeIntensity)
            );

            Camera.main.transform.localEulerAngles = newRotation.eulerAngles;



            yield return null;
        }

    }
}
