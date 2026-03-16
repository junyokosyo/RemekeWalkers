using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] GameObject tilePrefab;
    [SerializeField] int poolSize = 10;
    [SerializeField] float tileSize = 10f;
    [SerializeField] float speed = 10f;

    Queue<GameObject> pool = new Queue<GameObject>();
    float frontZ;

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            var tile = Instantiate(tilePrefab);
            tile.transform.position = new Vector3(0, 0, i * tileSize);
            pool.Enqueue(tile);
        }
        frontZ = (poolSize - 1) * tileSize;
    }

    void FixedUpdate()
    {
        float move = speed * Time.fixedDeltaTime;

        foreach (var tile in pool)
        {
            tile.transform.Translate(Vector3.back * move);
        }

        var oldest = pool.Peek();
        if (oldest.transform.position.z < -tileSize)
        {
            pool.Dequeue();
            var tiles = pool.ToArray();
            float newZ = tiles[tiles.Length - 1].transform.position.z + tileSize;

            oldest.transform.position = new Vector3(0, 0, newZ);
            pool.Enqueue(oldest);
        }
    }
}