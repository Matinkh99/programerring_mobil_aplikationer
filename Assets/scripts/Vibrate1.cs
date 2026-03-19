using UnityEngine;
using UnityEngine.InputSystem;

public class PhoneVibration : MonoBehaviour
{
    private bool hasVibrated = false;

    void Update()
    {
        if (Touchscreen.current == null)
            return;

        var touch = Touchscreen.current.primaryTouch;

        // Vibrate once when touch begins
        if (touch.press.wasPressedThisFrame && !hasVibrated)
        {
            Vibrate();
            hasVibrated = true;
        }

        // Reset when touch is released
        if (touch.press.wasReleasedThisFrame)
        {
            hasVibrated = false;
        }
    }

    public void Vibrate()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        Handheld.Vibrate();
#endif
        Debug.Log("Phone vibrated");
    }
}