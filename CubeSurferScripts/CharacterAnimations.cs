using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{

    public Animator animator;
    private int speedHash;
    public float speed;
    public int fallingHash;
    public bool isplayertouchedobs;
    public float countdown;




    private void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        speedHash = Animator.StringToHash("speed");
        fallingHash = Animator.StringToHash("falling");

    }
    private void Update()
    {

        animator.SetFloat(speedHash, speed);
        speed = Mathf.Clamp(speed, 0, 1);
        if (isplayertouchedobs)
        {
            animator.SetBool(fallingHash, true);

            speed += Time.deltaTime*2;
            if (speed >= 1)
            {
                speed = 0;
            }
            StartCoroutine(Timer());
        }
    }
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(countdown);
        animator.SetBool(fallingHash, false);
        isplayertouchedobs = false;
        countdown = 0;
    }

    
}
