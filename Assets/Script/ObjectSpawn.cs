using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    public GameObject _objectPrefab; // オブジェクトのプレハブ
    public float _spawnInterval = 2f; // 敵の生成間隔

    private Collider2D _spawnArea; // 生成エリアのコライダー

    // Start is called before the first frame update
    void Start()
    {
        _spawnArea = GetComponent<Collider2D>();
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // エリア内のランダムな位置にオブジェクトを生成
            Vector2 spawnPosition = GetRandomPositionInArea();
            Instantiate(_objectPrefab, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    Vector2 GetRandomPositionInArea()
    {
        // エリアの範囲内でランダムな位置を生成
        Vector2 min = _spawnArea.bounds.min;
        Vector2 max = _spawnArea.bounds.max;
        float randomX = Random.Range(min.x, max.x);
        float randomY = Random.Range(min.y, max.y);
        return new Vector2(randomX, randomY);
    }
}