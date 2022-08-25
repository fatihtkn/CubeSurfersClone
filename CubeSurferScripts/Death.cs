using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
    
{   
    private GameObject main_cube;
    
    private void Awake()
    {
        main_cube = GameObject.Find("MainCube");
        
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Obstacle":
                main_cube.GetComponent<MainCubeManager>().isPlayerDeath = true;
                break;
            case "Finish":
                main_cube.GetComponent<MainCubeManager>().isPlayerDeath = true;
                break;
            case "Water":
                main_cube.GetComponent<MainCubeManager>().isPlayerDeath = true;
                break;
            case "Stairs":
                main_cube.GetComponent<MainCubeManager>().isPlayerDeath = true;
                break;

        }
       
    }
    
}
