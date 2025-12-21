using UnityEngine;

// 플레이어의 현재 스텟
public class PlayerStat 
{
    // ======== User Information ========
    public string   Name; // 플레이어 닉네임    
    public CharacterType     charType; // 플레이하는 캐릭터 종류
    public int      level = 1; // 플레이어 레벨

    // ======== Movement ========
    public float    currentHp = 100f; // 현재 HP
    public float    maxHp = 100f; // 현재 레벨의 최대 HP값
    public float    currentExp = 0f; // 현재 경험치 
    public float    maxExp = 0f; // 레벨업 하기위한 필요 경험치 
    public float    expGainRate = 1f; // 경험치 획득 비율

    // ======== Movement ========
    public float    moveSpeed = 1f;  // 이동속도
    public float    dashSpeed = 1f;  // 대쉬 속도

    // ======== Attack ========
    public float    attackPower = 1f; // 공격력
    public float    attackSpeed = 1f; // 공격속도
    public float    attackRange = 5f; // 공격 사거리 
    public float    targetRange = 7f; // 자동공격 사거리 
    public int      projectileCount = 1; // 발사체 갯수 

    // ======== Pickup ========
    public float    pickupRange = 1f; // 아이템자동줍기 사거리 

    // ======== ETC ========
    public string   description = ""; // 기타 저장사항 

}
