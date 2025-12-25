using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [Header("Owner Reference")]
    public Transform owner;

    [Header("Common Stats")] 
    public float damage;
    public float range;
    public float cooldown;
    protected float lastAttackTime; 
    
    public abstract void Attack();
    
    protected virtual void Start()
    {
        // Owner 설정
        if (owner == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
                owner = player.transform;
        }
    }

    // 공격 가능 여부 (쿨타임 체크용)
    protected bool CanAttack()
    {
        return Time.time >= lastAttackTime + cooldown;
    }

    protected void SetOwner(GameObject gameObject)
    {
        if (gameObject != null)
        {
            owner = gameObject.transform;
        }
    }

    protected Transform GetOwner()
    {
        return owner;
    }

}
