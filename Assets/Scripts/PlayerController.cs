using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float mov_speed, jump_force,raycast_FloorRange, raycast_SideRange;
    private bool grounded,D_Jump, CanMoveLeft, CanMoveRight;
    private Rigidbody rb;
    RaycastHit FloorHit, RightHit, LeftHit;
    private int layerMask = 1 << 8;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        grounded = true;
        layerMask = ~layerMask;
    }
    
    void Update()
    {
        movement();
        jump();
        CheckGround();
        CheckSides();     
    }

    #region movimiento
    private void movement()
    {
      //  transform.Translate(new Vector3(0,0,Input.GetAxisRaw("Horizontal") * mov_speed * Time.deltaTime));

        if (CanMoveLeft && Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(0, 0, Input.GetAxisRaw("Horizontal") * mov_speed * Time.deltaTime));
        }

        if (CanMoveRight && Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(0, 0, Input.GetAxisRaw("Horizontal") * mov_speed * Time.deltaTime));
        }
    }

    private void jump()
    {
        ///////salto normal
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(Vector3.up * jump_force);           
        }
        ///////doble salto
        if (Input.GetButtonDown("Jump") && !grounded && D_Jump)
        {
            rb.AddForce(Vector3.up * jump_force);
            D_Jump = false;
        }        
    }
    #endregion
    #region Checkeos
    private void CheckGround()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out FloorHit, raycast_FloorRange, layerMask)) //detecta suelo
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * FloorHit.distance, Color.red);
           // Debug.Log("Did Hit");

            grounded = true;           //reestablecemos salto y doble salto
            D_Jump = true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * raycast_FloorRange, Color.yellow);  //no detecta suelo
            grounded= false;
         //   Debug.Log("Did not Hit");
        }
    }

    private void CheckSides()
    {
        // LADO DERECHO (forward)
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RightHit, raycast_SideRange, layerMask)) //detecta pared
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * RightHit.distance, Color.red);
          
            CanMoveRight = false;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * raycast_SideRange, Color.yellow);  //no detecta pared          
          
            CanMoveRight = true;
        }

        // LADO IZQUIERDO (!forward)
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out LeftHit, raycast_SideRange, layerMask)) //detecta pared
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * LeftHit.distance, Color.red);
          
            CanMoveLeft = false;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * raycast_SideRange, Color.yellow);  //no detecta pared          
                                                                                                                              //   Debug.Log("Did not Hit");
            CanMoveLeft = true;
        }
    }
    #endregion
}
