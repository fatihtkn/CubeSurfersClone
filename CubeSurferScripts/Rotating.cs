using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    [SerializeField] private float speed=0.1f;
    private void Update()
    {
        transform.Rotate(0, 90*speed*Time.deltaTime, 0);
    }
}
