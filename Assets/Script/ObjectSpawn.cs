using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    public GameObject _objectPrefab; // �I�u�W�F�N�g�̃v���n�u
    public float _spawnInterval = 2f; // �G�̐����Ԋu

    private Collider2D _spawnArea; // �����G���A�̃R���C�_�[

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
            // �G���A���̃����_���Ȉʒu�ɃI�u�W�F�N�g�𐶐�
            Vector2 spawnPosition = GetRandomPositionInArea();
            Instantiate(_objectPrefab, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    Vector2 GetRandomPositionInArea()
    {
        // �G���A�͈͓̔��Ń����_���Ȉʒu�𐶐�
        Vector2 min = _spawnArea.bounds.min;
        Vector2 max = _spawnArea.bounds.max;
        float randomX = Random.Range(min.x, max.x);
        float randomY = Random.Range(min.y, max.y);
        return new Vector2(randomX, randomY);
    }
}