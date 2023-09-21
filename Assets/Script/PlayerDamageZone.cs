using UnityEngine;

public class PlayerDamageZone : MonoBehaviour
{
    [SerializeField] int _playerTakeDamage; // プレイヤーに与えるダメージの量

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // プレイヤーキャラクターにダメージを与える
            PlayerDefScript playerDamageScript = other.GetComponent<PlayerDefScript>();

            if (playerDamageScript != null)
            {
                playerDamageScript.TakeDamage(_playerTakeDamage);
            }
        }
    }
}
