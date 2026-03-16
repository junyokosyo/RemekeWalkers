using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] GameObject tilePrefab;
    [SerializeField] int poolSize = 10;
    [SerializeField] float tileSize = 1f;
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
        foreach (var tile in pool)
        {
            tile.transform.Translate(Vector3.back * speed * Time.fixedDeltaTime);
        }

        // 手前に出たタイルを奥に再配置
        var oldest = pool.Peek();
        if (oldest.transform.position.z < -tileSize)
        {
            pool.Dequeue();
            frontZ += tileSize;
            oldest.transform.position = new Vector3(0, 0, frontZ);
            pool.Enqueue(oldest);
        }
    }
}
