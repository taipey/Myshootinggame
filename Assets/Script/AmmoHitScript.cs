using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public int damage = 25;
    public float range = 100f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            // ƒŒƒC‚ª“G‚É“–‚½‚Á‚½ê‡
            EnemyController enemy = hit.transform.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}