using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRecoil : Recoils
{

    [SerializeField]
    private float rotateRange;

    private Quaternion StartRotate;
    //rotate range will determine max rotate of the gun while recoil Strentgh will determin how much rotation based on recoil time

    private void Start()
    {
        StartRotate = gameObject.transform.localRotation;
    }

    public override void recoil()
    {
        StartCoroutine(rotateRecoil());
    }

    IEnumerator rotateRecoil()
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < recoilDuration)
        {
            elapsedTime += Time.deltaTime;

            float t = elapsedTime / recoilDuration;
            float recoilAmount = Mathf.Sin(t * Mathf.PI) * recoilStrength * rotateRange;

            transform.localRotation = Quaternion.Euler(StartRotate.eulerAngles.x, StartRotate.eulerAngles.y, -recoilAmount);

            yield return null;
        }

        transform.localRotation = StartRotate;
    }

}
