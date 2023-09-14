using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 衝突したオブジェクトを破壊する
        Destroy(collision.gameObject);
    }
}
