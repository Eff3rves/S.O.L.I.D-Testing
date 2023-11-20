using UnityEngine;

public class AdditionalCameraRotation : MonoBehaviour
{
    private void OnEnable()
    {
        UpwardShake.OnCameraRotationChange += HandleCameraRotation;
    }

    private void OnDisable()
    {
        UpwardShake.OnCameraRotationChange -= HandleCameraRotation;
    }

    private void HandleCameraRotation(float extraRotation)
    {
        // Add extra rotation to the camera
        transform.Rotate(0, extraRotation, 0);
    }
}
