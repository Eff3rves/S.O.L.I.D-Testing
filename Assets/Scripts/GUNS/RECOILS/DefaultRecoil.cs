using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultRecoil : Recoils
{
    private Vector3 startPos;
    private Vector3 targetPos;
    private bool isRecoiling = false;

    private void Start()
    {
        startPos = transform.localPosition;
        targetPos = startPos;
    }

    public override void recoil()
    {
        if (!isRecoiling)
        {
            StartCoroutine(SimpleRecoil());
        }
    }

    IEnumerator SimpleRecoil()
    {
        isRecoiling = true;

        float elapsedTime = 0.0f;
        Vector3 initialPos = transform.localPosition;

        while (elapsedTime < recoilDuration)
        {
            elapsedTime += Time.deltaTime;

            float t = elapsedTime / recoilDuration;
            float recoilAmount = Mathf.Sin(t * Mathf.PI) * recoilStrength;

            transform.localPosition = initialPos + Vector3.back * recoilAmount;

            yield return null;
        }



        // Gradually return to the original position
        float returnTime = 0.0f;
        while (returnTime < recoilDuration)
        {
            returnTime += Time.deltaTime;
            float t = returnTime / recoilDuration;
            transform.localPosition = Vector3.Lerp(initialPos, targetPos, t);
            yield return null;
        }
        isRecoiling = false;
        //// Ensure the final position is exactly the target position
        transform.localPosition = targetPos;
    }
}
