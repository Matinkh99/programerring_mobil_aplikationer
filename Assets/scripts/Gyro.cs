using UnityEngine;
using UnityEngine.InputSystem;
using gyro = UnityEngine.InputSystem.Gyroscope;

public class Sensors_Gyroscope : MonoBehaviour
{

    public float rotationSpeed = 50f;
    public GameObject extra_character_a;
    

   



    void Update()
    {
        if (gyro.current != null)
            InputSystem.EnableDevice(gyro.current);
        if (gyro.current != null)
        {
            Vector3 rotationRate = gyro.current.angularVelocity.ReadValue();

            Debug.Log("Rotation Rate: " + rotationRate);


            


            Vector3 rotationDegrees = rotationRate * Mathf.Rad2Deg;


            extra_character_a.transform.Rotate(0f, 0f, -rotationDegrees.z * rotationSpeed * Time.deltaTime);


            extra_character_a.transform.Translate(rotationDegrees.x, rotationDegrees.y, 0f * Time.deltaTime);


        }
    }
}

