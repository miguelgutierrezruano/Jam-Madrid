using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering;

public class piece : MonoBehaviour
{
    [SerializeField] private float  fallSpeedMultiplier;
    [HideInInspector]public float fallSpeed;
    private float FastFall, baseSpeed;
    private Rigidbody rb;
    private int n_pos = 5;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        FastFall = fallSpeed * fallSpeedMultiplier;
        baseSpeed = fallSpeed;
    }

    void Update()
    {
        Fall(fallSpeed);
        ManageFallSpeed();
        HorizontalMovement();
       
    }

    private void Fall(float speed)
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime); 
    }

    private void ManageFallSpeed()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            fallSpeed = FastFall;
        }
        else fallSpeed = baseSpeed;
    }

    private void FreezePiece()
    {
        
        rb.constraints = RigidbodyConstraints.FreezeAll;
        fallSpeed = 0;
    }

    private void DisableScript()
    {
        Debug.Log("desactivado");
        piece pieza = this;
        pieza.enabled = false;
    }

   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            this.tag = "floor";
            FreezePiece();
            PieceSpawner.instance.generatepiece = true;
             DisableScript();
            
        }
    }

    private void HorizontalMovement()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && n_pos > 0)
        {
            transform.position += Vector3.back;
            n_pos--;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && n_pos < 10)
        {
            transform.position += Vector3.forward;
            n_pos++;
        }
    }

   
}
