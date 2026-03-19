using UnityEngine;

public class GyroController : MonoBehaviour
{
    private Gyroscope gyro;
    private Quaternion calibration;
    private Quaternion smoothRotation;

    [Header("Settings")]
    public float smoothSpeed = 5f;
    public float maxTilt = 30f; // limit movement

    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            Calibrate();
        }
        else
        {
            Debug.LogWarning("Gyroscope not supported");
        }
    }

    void Update()
    {
        if (gyro == null) return;

        Quaternion raw = gyro.attitude;

        // Fix coordinate system (Unity vs phone)
        Quaternion fixedRotation = new Quaternion(raw.x, raw.y, -raw.z, -raw.w);

        // Apply calibration offset
        Quaternion targetRotation = calibration * fixedRotation;

        // Smooth it
        smoothRotation = Quaternion.Slerp(smoothRotation, targetRotation, Time.deltaTime * smoothSpeed);

        // Clamp rotation
        Vector3 euler = smoothRotation.eulerAngles;
        euler.x = ClampAngle(euler.x, -maxTilt, maxTilt);
        euler.y = ClampAngle(euler.y, -maxTilt, maxTilt);
        euler.z = 0;

        transform.rotation = Quaternion.Euler(euler);
    }

    void Calibrate()
    {
        calibration = Quaternion.Inverse(Input.gyro.attitude);
        smoothRotation = Quaternion.identity;
    }

    float ClampAngle(float angle, float min, float max)
    {
        if (angle > 180) angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}