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
  
    private Rigidbody rb;
    private int n_pos = 5;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
   

    void Update()
    {      
        Fall(fallSpeed);
        ManageFallSpeed();
        HorizontalMovement();
        RotatePiece();
    }

    private void RotatePiece()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            transform.Rotate(new Vector3(90, 0, 0),Space.Self);
        }
    }

    private void Fall(float speed)
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World); 
    }

    private void ManageFallSpeed()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            fallSpeed = 15;
        }
        else fallSpeed = 5;
    }

    private void FreezePiece()
    {
        
        rb.constraints = RigidbodyConstraints.FreezeAll;
        fallSpeed = 0;
    }

    private void DisableScript()
    {
      //  Debug.Log("desactivado");
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
