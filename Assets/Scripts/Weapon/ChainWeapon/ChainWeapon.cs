using UnityEngine;
using System.Collections.Generic;

public abstract class ChainWeapon : Weapon
{
    [Header("Chain Settings")]
    public float chainRange = 3f;         // 체인 범위 (한 타겟에서 다음 타겟까지의 거리)
    public int maxChainCount = 3;         // 최대 체인 횟수 (최대 타겟 수)
    public float chainDamageReduction = 0.2f; // 체인마다 데미지 감소율 (0.2 = 20% 감소)
    public bool canChainToSameTarget = false; // 같은 타겟에게 다시 체인 가능 여부
    
    [Header("Chain Visual")]
    public bool showChainEffect = true;   // 체인 이펙트 표시 여부
    public GameObject chainEffectPrefab;  // 체인 이펙트 프리팹
    
    protected List<GameObject> chainedTargets = new List<GameObject>(); // 체인된 타겟 리스트

    protected override void Start()
    {
        base.Start();
    }
}
