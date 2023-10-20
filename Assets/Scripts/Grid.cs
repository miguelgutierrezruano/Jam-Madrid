using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int gridWidth = 5;
    public int gridHeight = 5; 
    public float spacing = 1.0f;

    private void Awake()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, Vector3.one);

        for (int x = -gridWidth; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Vector3 target = transform.position + new Vector3(0, y * spacing, x * spacing);

                Gizmos.DrawWireCube(target, Vector3.one);
            }
        }
    }
}
