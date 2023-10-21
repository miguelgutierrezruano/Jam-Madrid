using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cubo;
    public static PieceSpawner instance;
    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        SpawnPiece();
    }

    public void SpawnPiece()
    {
        GameObject piece = Instantiate(cubo, transform.position,transform.rotation);
       // Debug.Log("spawneo pieza");
    }
}
