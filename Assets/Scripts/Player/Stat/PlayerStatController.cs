using UnityEngine;

public class PlayerStatController : MonoBehaviour, IDamageable
{
    private PlayerStat stat = new PlayerStat();

    void Start()
    {
        stat.currentHp = stat.maxHp;    
    }

    #region Damageable
    public void TakeDamage(float damage)
    {
        stat.currentHp -= damage;

        // player state 관련한 FSM 필요 
        if (stat.currentHp < 0)
        {
        }
    }
    #endregion

    public void AddExp(int amount)
    {
        // 경험치 배율로 얻은 경험치 
        int newExp = Mathf.RoundToInt(amount * stat.expGainRate);
        stat.currentExp += newExp;

        if (stat.currentExp >= stat.maxExp)
        {
            LevelUp();
        }
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

    public void LevelUp()
    {
        stat.level++;

        // ========  레벨업하면 Max증가되는 스텟들 리스트 ======== 
        stat.maxExp = GetNextMaxExp(stat.level);
        stat.maxHp = GetNextMaxHp(stat.level);

        // ========  레벨업하면 초기화 되는 스텟들 리스트 ======== 
        stat.currentExp = 0;
        stat.currentHp = stat.maxHp;

        // ======== 증가스텟 ========
        stat.pickupRange += 1f;
        stat.attackPower += 1f;

        // (임시) 일단 레벨업하면 속도 증가 
        stat.moveSpeed += 0.5f;
        stat.dashSpeed += 0.5f;
    }

    public void GainExpRateIncreaseItem(int level)
    {
        // (아래쭉 동일 수정) 현재 : 플레이어 레벨 기준 -> 아이템 레벨로 변경예정
        stat.expGainRate += 0.5f;
    }

    public void GainMoveSpeedIncreaseItem(int level)
    {
        stat.moveSpeed += 0.5f;
    }

    public float GetPlayerAttackDamage()
    {
        return stat.attackPower;
    }
    // 아래 리스트 참고해서 아이템 및 데이터셋 만들기 
/*    public float expGainRate = 1f; // 경험치 획득 비율
    public float moveSpeed = 1f;  // 이동속도
    public float dashSpeed = 1f;  // 대쉬 속도
    public float attackSpeed = 1f; // 공격속도
    public float pickupRange = 1f; // 아이템자동줍기 사거리 */


}
