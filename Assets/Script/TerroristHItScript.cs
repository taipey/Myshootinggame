using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // �G��|�������������ɒǉ�
        Destroy(gameObject);
    }
}