using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float thrust = 18.0f;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Cylinder")
        {
            Debug.Log("firce added");
            rb.velocity = Camera.main.transform.forward * thrust;
            
        }
    }
}
