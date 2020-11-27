using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 55f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 55f;

    [Tooltip("In m")] [SerializeField] float xRange = 20f;
    [Tooltip("In m")] [SerializeField] float yRange = 9f;

    [SerializeField] float positionPitchFactor = -5f;    
    [SerializeField] float controlPitchFactor = -20f;

    [SerializeField] float positionYawFactor = 5f;

    [SerializeField] float controlRollFactor = -25f;

    float xThrow;
    float yThrow;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        MoveHorizontally();
        MoveVertically();
    }

    private void MoveHorizontally()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawPos = xOffset + transform.localPosition.x;
        float campledXPos = Mathf.Clamp(rawPos, -xRange, xRange);
        transform.localPosition = new Vector3(campledXPos, transform.localPosition.y, transform.localPosition.z);
    }

    private void MoveVertically()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawPos = yOffset + transform.localPosition.y;
        float campledXPos = Mathf.Clamp(rawPos, -yRange, yRange);
        transform.localPosition = new Vector3(transform.localPosition.x, campledXPos, transform.localPosition.z);
    }
}
