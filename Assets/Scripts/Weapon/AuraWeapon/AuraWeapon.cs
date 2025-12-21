using UnityEngine;

public abstract class AuraWeapon : Weapon
{
    [Header("Aura Settings")]
    public float auraRadius = 2.5f;       // 오라 범위 (반지름)
    public float damageInterval = 0.5f;   // 도트딜 주기 (초)
    protected float lastDamageTime;       // 마지막 데미지 적용 시간
    
    [Header("Follow Settings")]
    public bool followPlayer = true;      // 플레이어를 따라다닐지 여부
    public bool canBePlaced = false;      // 설치 가능 여부 (설치형 오라)

    protected override void Start()
    {
        base.Start();
    }
}
