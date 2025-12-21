using UnityEngine;

public abstract class AoeWeapon : Weapon
{
    [Header("AoE Settings")]
    public float aoeRadius = 3f;          // AoE 범위 (반지름)
    public float duration = 5f;           // 설치 후 지속 시간
    public bool isPersistent = false;     // 영구 설치 여부 (true면 duration 무시)
    
    [Header("Spawn Settings")]
    public GameObject aoePrefab;          // 설치할 AoE 프리팹
    public bool spawnAtMousePosition = false; // 마우스 위치에 설치할지 여부
    public bool spawnAtPlayerPosition = true; // 플레이어 위치에 설치할지 여부

    protected override void Start()
    {
        base.Start();
    }
}
