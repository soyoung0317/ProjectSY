using UnityEngine;

public class ProjectileWeapon : Weapon
{
    [Header("Projectile Settings")]
    public GameObject projectilePrefab;  // 발사할 투사체 프리팹 (인스펙터에서 할당)
    public Transform firePoint;          // 발사 위치
    
    [Header("Projectile Stats")]
    public float projectileSpeed = 5f;   // 투사체 속도
    public int projectileCount = 1;      // 한 번에 발사하는 투사체 개수
    public float spreadAngle = 0f;       // 투사체 분산 각도 (도)

    public override void Attack()
    {
        /*if (!CanAttack()) return;

        GameObject proj = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // 생성된 투사체에 무기 데이터 전달
        BaseProjectile projectileScript = proj.GetComponent<BaseProjectile>();
        if (projectileScript != null)
        {
            projectileScript.Init(damage, range);
        }

        lastAttackTime = Time.time;*/
    }
}