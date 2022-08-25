using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Controller : MonoBehaviour
{
    private CollectCube cube_collector_sc;
    [SerializeField] private GameObject main_cube;
    [SerializeField] private GameObject collector;

    private string deneme;
    [HideInInspector] public bool increasefoW;
    [SerializeField]private GameObject anim_contoller_sc;
    
    
    private void Awake()
    {
        cube_collector_sc = collector.GetComponent<CollectCube>();

    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            ObstacleActions();

            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            

        }

        if (other.gameObject.CompareTag("Water"))
        {
            ObstacleActions();
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("Stairs"))
        {
            ObstacleActions();
            CameraControls camerControlSc;
            camerControlSc = Camera.main.GetComponent<CameraControls>();
            camerControlSc.camera_height += 1.2f;
            camerControlSc.stairs_controller = true;
            
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            transform.parent = null;
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
        }

    }
   

   private void ObstacleActions()
   {
        anim_contoller_sc.GetComponent<CharacterAnimations>().isplayertouchedobs = true;
        anim_contoller_sc.GetComponent<CharacterAnimations>().countdown += 0.4f;

        cube_collector_sc.controller = true;
        cube_collector_sc.last_cube_pos -= 1f;
        

        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        
        transform.parent = null;

        cube_collector_sc.altitude--;
        
        
        cube_collector_sc.collider_size--;
        cube_collector_sc.collider_center += 0.50f;
        cube_collector_sc.controller = false;



        Camera.main.GetComponent<CameraControls>().targetfowValue -= 4;
        this.gameObject.GetComponent<Rigidbody>().Sleep();
        

   }
    

   

}
