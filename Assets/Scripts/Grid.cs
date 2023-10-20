using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Grid : MonoBehaviour
{
    public enum States
    {
        PieceSpawned,
        PieceControlled,
        PiecePlaced
    }

    public States states;

    // TODO: Think how to calculate a piece is placed
    float startingHeight;
    float minHeight;

    public float speed = 1;

    public int gridWidth = 5;
    public float spacing = 1.0f;

    [HideInInspector] public Vector3[] gridPositions;

    public UnityEvent OnPiecePlaced;
    public UnityEvent OnPieceSpawned;

    private void Awake()
    {
        gridPositions = new Vector3[gridWidth * 2];
        UpdatePositions();

        states = States.PieceControlled;

        // Hacer grid en Y para calcular cuando dejar las piezas
        startingHeight = transform.position.y;
        minHeight = 2;
    }

    private void Update()
    {
        UpdatePositions();
        HandleStates();
    }

    private void HandleStates()
    {
        switch (states)
        {
            case States.PieceSpawned:
                transform.position = new Vector3(transform.position.x, startingHeight, transform.position.z);

                // Spawn new piece
                OnPieceSpawned.Invoke();

                states = States.PieceControlled;

                break;
            case States.PieceControlled:
                // Go down until piece is placed
                if(transform.position.y > minHeight)
                    transform.Translate(0, -speed * Time.deltaTime, 0);
                else
                    states = States.PiecePlaced;

                break;
            case States.PiecePlaced:
                // Drop control
                OnPiecePlaced.Invoke();
                // Set piece spawned
                states = States.PieceSpawned;

                break;
        }
    }

    private void UpdatePositions()
    {
        // Update grid positions
        for (int x = -gridWidth; x < gridWidth; x++)
            gridPositions[x + gridWidth] = transform.position + new Vector3(0, 0, x * spacing);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, Vector3.one);

        for (int x = -gridWidth; x < gridWidth; x++)
        {
            Vector3 target = transform.position + new Vector3(0, 0, x * spacing);
            Gizmos.DrawWireCube(target, Vector3.one);
        }
    }
}
