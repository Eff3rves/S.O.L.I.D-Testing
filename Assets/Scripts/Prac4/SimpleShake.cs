using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShake : CameraShake
{
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
            Camera.main.transform.localRotation = Quaternion.Euler(startPosition.eulerAngles.x + Random.Range(-1.0f,1.0f), startPosition.eulerAngles.y+ Random.Range(-1.0f, 1.0f), startPosition.eulerAngles.z+ Random.Range(-1.0f, 1.0f));

            yield return null;
        }
        Camera.main.transform.localRotation = startPosition;
    }

}
