using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 3f;
    public float rotSpeed = 100f;
    public float jumpForce = 300;
    public float timeBeforeNextJump = 1.2f;
    private float canJump = 0f;
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
            //anim.SetInteger("Walk", 0);
        }
        if(isRotRigth == true){
            //anim.SetInteger("Walk", 0);
            transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
        }
        if(isRotLeft == true){
            //anim.SetInteger("Walk", 0);
            transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
        }
        if(isWalking == true){
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
            anim.SetInteger("Walk", 1);
        }
    }

    IEnumerator Wander(){
        int rotTime = Random.Range(1, 2);
        int rotWait = Random.Range(1, 3);
        int rotLoR = Random.Range(1, 2);
        int walkWait = Random.Range(1, 2);
        int walkTime = Random.Range(1, 7);

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

    void ControllPlayer()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
            anim.SetInteger("Walk", 1);
        }
        else {
            anim.SetInteger("Walk", 0);
        }

        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

        if (Input.GetButtonDown("Jump") && Time.time > canJump)
        {
                rb.AddForce(0, jumpForce, 0);
                canJump = Time.time + timeBeforeNextJump;
                anim.SetTrigger("jump");
        }
    }
}