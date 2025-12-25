using UnityEngine;

public class PlayerStatController : MonoBehaviour, IDamageable
{
    private PlayerStat stat = new PlayerStat();
    private CharacterState playerState = new CharacterState();

    void Start()
    {
        stat.currentHp = stat.maxHp;    
    }

    #region Damageable Function
    public void TakeDamage(float damage)
    {
        stat.currentHp -= damage;

        // player state 관련한 FSM 필요 
        if (stat.currentHp < 0)
        {
            Debug.Log("test");
            playerState = CharacterState.DIE;
        }
    }
    #endregion

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
