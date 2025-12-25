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


    public void AddExp(int amount)
    {
        // 경험치 배율로 얻은 경험치 
        int newExp = Mathf.RoundToInt(amount * expGainRate);
        currentExp += newExp;

        if (currentExp >= maxExp)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        level++;

        // ========  레벨업하면 Max증가되는 스텟들 리스트 ======== 
        maxExp = GetNextMaxExp(level);
        maxHp = GetNextMaxHp(level);

        // ========  레벨업하면 초기화 되는 스텟들 리스트 ======== 
        currentExp = 0;
        currentHp = maxHp;

        // ======== 증가스텟 ========
        pickupRange += 1f;
        attackPower += 1f;

        // (임시) 일단 레벨업하면 속도 증가 
        moveSpeed += 0.5f;
        dashSpeed += 0.5f;
    }

    public float GetNextMaxExp(int level)
    {
        // 레벨업당 필요 경험치 포인트는.. 일단 대충해 
        return 100 + (level - 1) * 150;
    }

    public float GetNextMaxHp(int level)
    {
        return 100 + (level - 1) * 50;
    }

    public void GainExpRateIncreaseItem(int level)
    {
        // (아래쭉 동일 수정) 현재 : 플레이어 레벨 기준 -> 아이템 레벨로 변경예정
        expGainRate += 0.5f;
    }

    public void GainMoveSpeedIncreaseItem(int level)
    {
        moveSpeed += 0.5f;
    }
}
