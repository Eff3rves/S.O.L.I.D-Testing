using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShake : CameraShake
{

    public float mouseSensitivity = 2.0f;


    private float verticalRotation = 0f;
    private float horizontalRotation = 0f;

    public float shakeIntensity;
    public override void Shake()
    {
        StartCoroutine(PerformSimpleShake());
        
    }

    

    IEnumerator PerformSimpleShake()
    {

        Quaternion startPosition = Camera.main.transform.localRotation;
        float elapsedTime = 0.0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            // Implement the camera shake function by changing the x, y, z position randomly
            Camera.main.transform.localRotation = Quaternion.Euler(
                startPosition.eulerAngles.x + Random.Range(-shakeIntensity, shakeIntensity) + verticalRotation, 
                startPosition.eulerAngles.y+ Random.Range(-shakeIntensity, shakeIntensity) + horizontalRotation, 
                startPosition.eulerAngles.z+ Random.Range(-shakeIntensity, shakeIntensity)
                );

            yield return null;
        }
        //Camera.main.transform.localRotation = startPosition;
    }

}
