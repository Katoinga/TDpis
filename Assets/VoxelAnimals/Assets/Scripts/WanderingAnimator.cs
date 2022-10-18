using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WanderingAnimator : MonoBehaviour
{

    public float movementSpeed = 1f;
    public float rotSpeed = 50f;
    Animator anim;
    Rigidbody rb;
    
    private bool isWandering = false;
    private bool isRotLeft = false;
    private bool isRotRigth = false;
    private bool isWalking = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isWandering == false) {
            StartCoroutine(Wander());
        }
        if(isRotRigth == true){
            transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
            anim.Play("Idle_A");
        }
        if(isRotLeft == true){
            transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
            anim.Play("Idle_A");
        }
        if(isWalking == true){
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
            anim.Play("Walk");
        }
    }

    IEnumerator Wander(){
        int rotTime = Random.Range(1, 2);
        int rotWait = Random.Range(1, 3);
        int rotLoR = Random.Range(1, 2);
        int walkWait = Random.Range(1, 2);
        int walkTime = Random.Range(1, 5);

        isWandering = true;

        yield return new WaitForSeconds (walkWait);
        isWalking = true;
        yield return new WaitForSeconds (walkTime);
        isWalking = false;
        yield return new WaitForSeconds (rotWait);
        if(rotLoR == 1){
            isRotRigth = true;
            yield return new WaitForSeconds (rotTime);
            isRotRigth = false;
        }
        if(rotLoR == 2){
            isRotLeft = true;
            yield return new WaitForSeconds (rotTime);
            isRotLeft = false;
        }
        isWandering = false;
    }
}