using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class Changecolor : MonoBehaviour
{
    [SerializeField] GameObject character;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    bool fourFingerActive = false;

    void Awake()
    {
        EnhancedTouchSupport.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (touch.activeTouches.Count == 4)
        {
            if (!fourFingerActive)
            {
                Changecolor();
                fourFingerActive = true;

            }
        }
        else
        {
            fourFingerActive = false;
        }
        void Changecolor()
        {
            character.GetComponent<SpriteRenderer>().color = Random.ColorHSV();

            }
    }
}