using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAnim : MonoBehaviour
{
    [SerializeField]private float speed=5f;

    [SerializeField] private GameObject particle;

    private void Update()
    {
        transform.Rotate(0, 90 * speed * Time.deltaTime, 0);
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collector"))
        {
            this.gameObject.SetActive(false);
            Instantiate(particle,this.gameObject.transform.position,Quaternion.identity);
        }
    }
}
