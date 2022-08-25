using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public GameObject mainCube;
    public static GameObject cameraTarget;

    private bool isCameraActive;

    public float camera_height;
    public float targetfowValue;
    private float forwardSpeed;

    public bool stairs_controller;

    private void Awake()
    {
        Camera.main.fieldOfView = 52;
        camera_height = 2.619999f;



    }
    private void Start()
    {
        
        cameraTarget = GameObject.FindGameObjectWithTag("CameraTarget");
        isCameraActive = true;

    }
    private void Update()
    {
        

        CameraMovement();

    }
    private void FixedUpdate()
    {
        


    }
    private void LateUpdate()
    {
        ChangefoW();
        CameraHeight(stairs_controller);

    }
    private void ChangefoW()
    {
        if (isCameraActive)
        {
            targetfowValue = Mathf.Clamp(targetfowValue, 52, 84);
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, targetfowValue, Time.deltaTime * 4);
        }
    }

    private void CameraMovement()
    {
        forwardSpeed = PlayerMoveControls.forward_speed;
        cameraTarget.transform.Translate(forwardSpeed * Time.deltaTime, 0, 0);

    }
    private void CameraHeight(bool stairs_controller)
    {
        if (stairs_controller)
        {
            cameraTarget.transform.position = Vector3.Lerp(cameraTarget.transform.position, new Vector3(cameraTarget.transform.position.x, camera_height, cameraTarget.transform.position.z), Time.deltaTime * 4);
        }

    }


}
