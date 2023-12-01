using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpRecoil : Recoils
{
    private Vector3 startPos;
    private Vector3 startRot;
    private bool isRecoiling = false;

    private void Start()
    {
        startPos = transform.localPosition;
        startRot = transform.localEulerAngles;
        
    }

    public override void recoil()
    {
        if (!isRecoiling)
        {
            StartCoroutine(upRecoil());
        }
    }

    IEnumerator upRecoil()
    {
        isRecoiling = true;

        float elapsedTime = 0.0f;
        Vector3 initialPos = transform.localPosition;
        Vector3 initialRot = transform.localEulerAngles;

        while (elapsedTime < recoilDuration)
        {
            elapsedTime += Time.deltaTime;

            float t = elapsedTime / recoilDuration;
            float recoilAmount = Mathf.Sin(t * Mathf.PI) * recoilStrength;

            // Backward recoil
            Vector3 recoilBack = Vector3.back * recoilAmount;

            // Upward recoil 
            float upwardRecoilAmount =recoilAmount; 


            // Apply both recoil motions
            transform.localPosition = initialPos + recoilBack;
            transform.Rotate(0, 0, -upwardRecoilAmount);


            yield return null;
        }

        // Gradually return to the original position
        float returnTime = 0.0f;
        while (returnTime < recoilDuration)
        {
            returnTime += Time.deltaTime;
            float t = returnTime / recoilDuration;
            transform.localPosition = Vector3.Lerp(initialPos, startPos, t);
            if(Vector3.Magnitude((initialRot-startRot)) > recoilStrength*10)
            {
                Debug.Log("rotate back");
                transform.localEulerAngles = Vector3.Lerp(initialRot, startRot, t);
            }

            yield return null;
        }
        
        isRecoiling = false;
        transform.localPosition = startPos;
        transform.localEulerAngles = startRot;
    }

}
