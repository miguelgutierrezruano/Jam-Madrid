using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBlockSpawn : MonoBehaviour
{
    [SerializeField] private GameObject RedCube;
    [SerializeField] private int Y_Offset;
    [SerializeField] Transform[] SpawnPoints;
    // Start is called before the first frame update
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            SpawnRedCube();
            AddYPos();
        }
    }

    private void AddYPos()
    {
        transform.Translate(Vector3.up * Y_Offset);     
    }

    private void SpawnRedCube()
    {       
        int dice = Random.Range(0,SpawnPoints.Length);
        if (dice == 5) 
        { 
            dice = Random.Range(0, SpawnPoints.Length); 
        }
        else
        {
            print(dice);
            Vector3 newSpawnPoint = SpawnPoints[dice].position;
            GameObject CuboRojo = Instantiate(RedCube, newSpawnPoint, Quaternion.identity);
        }
        
    }
}
