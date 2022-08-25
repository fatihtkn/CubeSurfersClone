using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationManager : MonoBehaviour
{
    

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        Physics.gravity = new Vector3(0, -30, 0);

        
    }
    
}
