using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CollectCube : MonoBehaviour
{

    public  GameObject main_cube;
    public bool controller = false;
    public  float altitude;
    public float collider_center;
    public float collider_size = 1f;
    public float last_cube_pos;
    public GameObject camera_target;
    public Transform rotation_target;
    
    private bool rotateAxis;
    private float yAxis_value;


    private void FixedUpdate()
    {
        MainCubePosition();
        MainCubeRotation();

    }


    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Point":

                controller = true;
                altitude += 1;
                
                last_cube_pos += 1;
                collider_size += 1;
                collider_center += -0.50f;
                other.transform.parent = main_cube.transform;
                other.transform.localPosition = new Vector3(0, -last_cube_pos, 0);
                Camera.main.GetComponent<CameraControls>().targetfowValue += 4;
                other.tag = "Untagged";

                break;

            case "A":

                main_cube.GetComponent<MainCubeManager>().switchPlane = false;
                main_cube.GetComponent<MainCubeManager>().ClampState = "B";
                main_cube.GetComponent<PlayerMoveControls>().switchSwipeAxis = false;
                rotateAxis = true;
                yAxis_value = -90;

                break;

            case "B":

                yAxis_value = 0;
                main_cube.GetComponent<MainCubeManager>().switchPlane = true;
                main_cube.GetComponent<MainCubeManager>().ClampState = "C";

                break;

        }

        
    }
    
    
   private void MainCubePosition()
    {

        if (controller)
        {

            //Set Main cube position
            main_cube.transform.position = new Vector3(main_cube.transform.position.x, altitude, main_cube.transform.position.z);

            //Set Collector's size and center
            GetComponent<BoxCollider>().size = new Vector3(1, collider_size + 1, 1);
            GetComponent<BoxCollider>().center = new Vector3(0, collider_center, 0);

            controller = false;
        }
    }

    private void MainCubeRotation()
    {
        if (rotateAxis)
        {

            main_cube.transform.rotation = Quaternion.RotateTowards(main_cube.transform.rotation, Quaternion.Euler(0, yAxis_value, 0), Time.deltaTime * 200);
            camera_target.transform.rotation = Quaternion.RotateTowards(camera_target.transform.rotation, Quaternion.Euler(0, yAxis_value, 0), Time.deltaTime * 200);

        }
    }
}
