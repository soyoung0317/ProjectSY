using UnityEngine;

// 플레이어의 현재 스텟
public class MonsterStat
{
    // ======== User Information ========
    public string Name;         // 몬스터 이름 
    public int level = 1;       // 레벨

    // ======== Movement ========
    public float currentHp = 100f; // 현재 HP
    public float maxHp = 100f; // 현재 레벨의 최대 HP값

    // ======== Movement ========
    public float moveSpeed = 1f;  // 이동속도
    public float dashSpeed = 1f;  // 대쉬 속도

    // ======== Attack ========
    public float attackPower = 1f; // 공격력
    public float attackSpeed = 1f; // 공격속도
    public float attackRange = 5f; // 공격 사거리 
    public float targetRange = 7f; // 자동공격 사거리 

    // ======== ETC ========
    public string description = ""; // 기타 저장사항 

}
