using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    public SnapController snapController;

    [SerializeField] private GameObject tile;
    [SerializeField] private SpriteRenderer tileSR;

    [SerializeField] private Sprite spriteBlack;
    [SerializeField] private Sprite spriteWhite;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < 6; x++)
        {
            for (int y = 0; y < 6; y++)
            {

                bool isOffset = ((x + y) % 2 == 0);
                if(isOffset == true)
                {
                    tileSR.sprite = spriteBlack;
                }
                else if(isOffset == false)
                {
                    tileSR.sprite = spriteWhite;
                }

                var spawnedTile = Instantiate(tile, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                snapController.snapPoints.Add(spawnedTile.transform);

            }
        }
    }
}
