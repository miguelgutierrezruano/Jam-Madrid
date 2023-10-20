using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float mov_speed, jump_force;
    private bool OnFLoor,D_Jump;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        movement();
        jump();
    }


    private void movement()
    {
        transform.position += new Vector3(0,0,Input.GetAxis("Horizontal") * mov_speed * Time.deltaTime);
    }

    private void jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jump_force);
        }
        ///////doble salto
    }
}
