using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cubo;
    public static PieceSpawner instance;
    [HideInInspector]public bool generatepiece;
    [SerializeField] private float pieceSpeed;
    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        SpawnPiece();
    }
    private void Update()
    {
        if (generatepiece)
        {
            SpawnPiece();
        }
    }

    public void SpawnPiece()
    {
        GameObject pieza = Instantiate(cubo, transform.position,transform.rotation);
        generatepiece = false;
        piece piezascript = pieza.GetComponent<piece>();
        piezascript.fallSpeed = pieceSpeed;
       // Debug.Log("spawneo pieza");
    }
}
