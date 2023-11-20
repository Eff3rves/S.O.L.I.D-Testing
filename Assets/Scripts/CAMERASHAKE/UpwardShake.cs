using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpwardShake : CameraShake
{

    private Quaternion StartRotateY;
    public float shakeIntensity;
    public float UpwardShakeIntensity;
    Quaternion startPosition;
    public override void Shake()
    {
        
        StartCoroutine(PerformUpwardShake());

    }

    IEnumerator PerformUpwardShake()
    {
        startPosition = Camera.main.transform.localRotation;
        float elapsedTime = 0.0f;

        elapsedTime += Time.deltaTime;
        startPosition.eulerAngles = new Vector3(startPosition.eulerAngles.x - UpwardShakeIntensity, startPosition.eulerAngles.y, startPosition.eulerAngles.z);

        Camera.main.transform.localRotation = Quaternion.Euler(
             startPosition.eulerAngles.x + Random.Range(-shakeIntensity, shakeIntensity),
            startPosition.eulerAngles.y + Random.Range(-shakeIntensity, shakeIntensity),
            startPosition.eulerAngles.z + Random.Range(-shakeIntensity, shakeIntensity)
            );
        yield return null;

    }
}
