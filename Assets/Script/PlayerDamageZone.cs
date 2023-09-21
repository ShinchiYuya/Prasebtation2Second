using UnityEngine;

public class PlayerDamageZone : MonoBehaviour
{
    [SerializeField] int _playerTakeDamage; // �v���C���[�ɗ^����_���[�W�̗�

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // �v���C���[�L�����N�^�[�Ƀ_���[�W��^����
            PlayerDefScript playerDamageScript = other.GetComponent<PlayerDefScript>();

            if (playerDamageScript != null)
            {
                playerDamageScript.TakeDamage(_playerTakeDamage);
            }
        }
    }
}
