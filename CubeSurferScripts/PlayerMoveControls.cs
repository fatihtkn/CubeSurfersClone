using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveControls : MonoBehaviour
{
    private Transform maincube;
    public bool switchSwipeAxis;
    public float speed;
    public static float forward_speed;
    float startTouch;
    float swipeDelta2;
    
    private float SwipeDelta2 => swipeDelta2;
    

    private void Start()
    {
        maincube = transform;
        switchSwipeAxis = true;
        speed = 0f;
        forward_speed = 0f;
       
       
    }

    private void Update()
    {

        //AlternativeMoveController();
        TouchControl();
        //maincube.transform.Translate(forward_speed * Time.deltaTime * Vector3.right);

    }
   


    private void TouchControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startTouch = Input.mousePosition.x;

        }
        else if (Input.GetMouseButton(0))
        {
            swipeDelta2 = Input.mousePosition.x - startTouch;
            startTouch = Input.mousePosition.x;


        }
        else if (Input.GetMouseButtonUp(0))
        {

            swipeDelta2 = 0;
            startTouch = 0;

        }
        float swerveAmount = SwipeDelta2*Time.deltaTime;
       
        

        transform.Translate(forward_speed * Time.deltaTime, 0, (swerveAmount*-1));
        
        
        
        
        
    }
    
  
}
