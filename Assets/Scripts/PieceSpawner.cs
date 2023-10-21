using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
   
    public static PieceSpawner instance;
    [HideInInspector]public bool generatepiece;
   
    [SerializeField] private GameObject[] piezas;
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

        int dice = 5;//Random.Range(0, piezas.Length);
        GameObject pieza = Instantiate(piezas[dice], transform.position, transform.rotation);
        generatepiece = false;
    }
}
