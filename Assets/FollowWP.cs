using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWP : MonoBehaviour
{
    public GameObject[] waypoints;
    int currentWP = 0;
    Animator anim;
    Rigidbody rb;

    public float speed = 10.0f;
    public float rotSpeed = 10.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, waypoints[currentWP].transform.position) < Random.Range(0.1f, 10f))
            currentWP++;

        if (currentWP >= waypoints.Length)
            currentWP = 0;

        //this.transform.LookAt(waypoints[currentWP].transform);

        Quaternion lookatWP = Quaternion.LookRotation(waypoints[currentWP].transform.position - this.transform.position);

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookatWP, rotSpeed * Time.deltaTime);
        
        speed = changeVelocity();
        this.transform.Translate(0, 0, speed * Time.deltaTime);
        anim.Play("Walk");
    }

    float changeVelocity () {
        float newX = Random.Range(5f, 15f);
        return newX;
    }
}
