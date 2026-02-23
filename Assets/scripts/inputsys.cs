using UnityEngine;
using UnityEngine.InputSystem;

public class inputsys : MonoBehaviour
{
  public bool IsPresssing(out Vector2 screenPos)
    {
        screenPos = Vector2.zero;
        if(Mouse.current != null && Mouse.current.leftButton.isPressed)
        {
            screenPos = Mouse.current.position.ReadValue();
            return true;


        }
        if(Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            screenPos = Touchscreen.current.position.ReadValue();
            return true;
        }
        return false;

    }
    

        

  
        
        

    


    // Update is called once per frame
    void Update()
    {
        
    }
}
