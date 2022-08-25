using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MainCubeManager : MonoBehaviour
{
    
    public Vector3 tracking_distance;
    
    private  GameObject main_cube;
    public GameObject camera_target;
    public GameObject panel;
    [SerializeField] private GameObject trailRenderer;
    


    
    public float speed = 10f;
    public float forward_speed_ = 8f;
    public static float altitude;

    public bool stairs_controller;
    public bool switchPlane;
    public bool isPlayerDeath;
    
    
    public string ClampState;
    

    private void Awake()
    {

        ClampState = "A";
        main_cube = this.gameObject;
        
        
    }
    private void Start()
    {
        switchPlane = true;
        forward_speed_ = PlayerMoveControls.forward_speed;
    }

    private void Update()
    {
        
        SwipeLimit(switchPlane);
        Death();
        
        
        
        trailRenderer.transform.position = new Vector3(main_cube.transform.position.x, trailRenderer.transform.position.y, main_cube.transform.position.z);
        

    }
    
    private void Death()
    {
        bool death = DeathController();

        if (death)
        {
            main_cube.GetComponent<PlayerMoveControls>().speed = 0f;
            forward_speed_ = PlayerMoveControls.forward_speed = 0f;
            panel.SetActive(true);
            main_cube.GetComponent<Rigidbody>().useGravity = false;
            isPlayerDeath = false;
        }


    }
    private bool DeathController()
    {
        bool controller= main_cube.transform.childCount - 4 == 0 & isPlayerDeath;
        return controller;
    }
   
   
    public void SwipeLimit(bool changePlane)
    {
       
        switch (ClampState)
        {
            case "A":
                main_cube.transform.localPosition = new Vector3(main_cube.transform.localPosition.x, main_cube.transform.localPosition.y, Mathf.Clamp(main_cube.transform.localPosition.z, (-2.00f), 2.00f));
                break;
            case "B":
                main_cube.transform.localPosition = new Vector3(Mathf.Clamp(main_cube.transform.localPosition.x, 134f, 140f), main_cube.transform.localPosition.y, main_cube.transform.localPosition.z);
                break;
            case "C":
                main_cube.transform.localPosition = new Vector3(main_cube.transform.localPosition.x, main_cube.transform.localPosition.y, Mathf.Clamp(main_cube.transform.localPosition.z, 260, 264f));
                break;


        }

    }
    

   
}

