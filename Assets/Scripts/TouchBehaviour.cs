using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBehaviour : MonoBehaviour
{
    
    /*
     * Reference pointer to method 
     * Allows for method to act as variable
     * Allows for a variable callback
     */
    public delegate void TouchPressed();
    public static event TouchPressed OnLeftPressed;
    public static event TouchPressed OnRightPressed;

#if UNITY_EDITOR
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (OnLeftPressed != null && hit.collider != null && hit.collider.tag == "Left")
                OnLeftPressed();
            else if (OnRightPressed != null && hit.collider != null && hit.collider.tag == "Right")
                OnRightPressed();
        }
    }
#elif (UNITY_IOS || UNITY_ANDROID)

	void Update()
	{
		foreach (Touch touch in Input.touches)
		{
			if (touch.phase == TouchPhase.Began)
			{
				Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
				RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
				if (OnLeftPressed != null && hit.collider != null && hit.collider.tag == "Left")
					OnLeftPressed();
				else if (OnRightPressed != null && hit.collider != null && hit.collider.tag == "Right")
					OnRightPressed();
			}
		}
	}

#endif
}
