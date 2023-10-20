using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyController : MonoBehaviour
{
    // Grid
    private Grid horizontalPos;

    // Pool objetos
    
    // Current piece
    [SerializeField] private GameObject piecePrefab;
    private GameObject piece;
    private int pieceHorizontalIndex;

    // Next piece

    private void Start()
    {
        horizontalPos = GetComponentInChildren<Grid>();

        pieceHorizontalIndex = horizontalPos.gridPositions.Length / 2;

        // Instantiate piece in the middle of the grid
        piece = Instantiate(piecePrefab, horizontalPos.gridPositions[pieceHorizontalIndex], Quaternion.identity);
    }

    private void Update()
    {
        if (piece == null) return;

        HandleInput();
        AdjustPieceToGrid();
    }

    public void OnPieceSpawned()
    {
        pieceHorizontalIndex = horizontalPos.gridPositions.Length / 2;
        piece = Instantiate(piecePrefab, horizontalPos.gridPositions[pieceHorizontalIndex], Quaternion.identity);
    }

    public void OnPiecePlaced()
    {
        piece = null;
    }

    private void AdjustPieceToGrid()
    {
        piece.transform.position = new Vector3
                (
                    piece.transform.position.x,
                    horizontalPos.gridPositions[pieceHorizontalIndex].y,
                    piece.transform.position.z
                );
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Check other collisions
            if (pieceHorizontalIndex > 0)
                pieceHorizontalIndex--;

            piece.transform.position = new Vector3
                (
                    piece.transform.position.x,
                    horizontalPos.gridPositions[pieceHorizontalIndex].y,
                    horizontalPos.gridPositions[pieceHorizontalIndex].z
                );
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Check other collisions
            if (pieceHorizontalIndex < horizontalPos.gridPositions.Length - 1)
                pieceHorizontalIndex++;

            piece.transform.position = new Vector3
                (
                    piece.transform.position.x,
                    horizontalPos.gridPositions[pieceHorizontalIndex].y,
                    horizontalPos.gridPositions[pieceHorizontalIndex].z
                );
        }
    }
}
