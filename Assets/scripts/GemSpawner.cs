using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] gem;
    //public List<DragTransform> gems;

    public SnapController snapController;

    public GameObject gemsParent;

    public Vector2 spawnAreaMin; // Minimum bounds of the spawn area
    public Vector2 spawnAreaMax; // Maximum bounds of the spawn area

    public float spawnRadius = 0.1f; // Radius to check for overlaps

    private void Update()
    {
        SpawningGems();
    }

    public void SpawningGems()
    {
        if (gemsParent.transform.childCount == 0)
        {
            for (int i = 0; i < gem.Length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    SpawnGemMechanic(gem[i]);
                }
            }
        }
        else
        {
            return;
        }
        
    }

    void SpawnGemMechanic(GameObject obj)
    {
        Vector2 spawnPosition;
        bool validPosition = false;
        int attempts = 0;

        do
        {
            spawnPosition = new Vector2(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            );

            validPosition = !Physics2D.OverlapCircle(spawnPosition, spawnRadius);
            attempts++;

            if (attempts > 100) // Prevent infinite loops
            {
                Debug.LogWarning("Could not find a valid spawn position.");
                return;
            }
        }
        while (!validPosition);

        var spawnedGems = Instantiate(obj, spawnPosition, Quaternion.identity);
        var gemList = spawnedGems.GetComponent<DragTransform>();
        spawnedGems.name = $"Tile {spawnPosition.x} {spawnPosition.y}";
        spawnedGems.gameObject.transform.SetParent(gemsParent.transform);
    }
}