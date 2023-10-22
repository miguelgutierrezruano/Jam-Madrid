using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideTriggerBehaviour : MonoBehaviour
{
    piece pieza;
    [SerializeField] private bool left;
    private void Awake()
    {
        pieza = GetComponentInParent<piece>();
    }

    private void OnTriggerStay(Collider other)
    {
        string tag = other.tag;
        if (left) 
        {
            switch (tag)
            {
                case "piece":
                    pieza.CanMoveLeft = false;
                    Debug.Log("cant move left, there is a piece");
                    break;
                case "SideWall":
                    pieza.CanMoveLeft = false;
                    Debug.Log("cant move left, there is a wall");
                    break;
            }
        }
        if (!left) // right triggers
        {
            switch (tag)
            {
                case "piece":
                    pieza.CanMoveRight = false;
                    Debug.Log("cant move right, there is a piece");
                    break;
                case "SideWall":
                    pieza.CanMoveRight = false;
                    Debug.Log("cant move right, there is a wall");
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        string tag = other.tag;
        if (left)
        {
            switch (tag)
            {
                case "piece":
                    pieza.CanMoveLeft = true;
                    Debug.Log("you can now move left");
                    break;
                case "SideWall":
                    pieza.CanMoveLeft = true;
                    Debug.Log("you can now move left");
                    break;
            }
        }
        if(!left) // right triggers
        {
            switch (tag)
            {
                case "piece":
                    pieza.CanMoveRight = true;
                    Debug.Log("you can now move right");
                    break;
                case "SideWall":
                    pieza.CanMoveRight = true;
                    Debug.Log("you can now move right");
                    break;
            }
        }
    }
}
