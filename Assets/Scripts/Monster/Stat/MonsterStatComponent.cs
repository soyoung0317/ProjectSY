using UnityEngine;

// 테스트용 공통 STATCOMP 

public class MonsterStatComponent : MonoBehaviour, IDamageable
{
    // 모슨 몬스터에 달아서 사용할 테스트용 컴포넌트 > 이후 분할 예정 
    private MonsterStat stat = new MonsterStat();

    private void Awake()
    {
        // (임시값)
        stat.level = 1;
        stat.currentHp = 10;
        stat.maxHp = 10;
    }

    public void TakeDamage(float damage)
    {
        if (stat.currentHp < 0)
            return;

        if (stat.level < 1)
            return;

        stat.currentHp -= damage;


        // 몬스터 FSM 추가 및 각 상태 연결필요 일단 RETURN -
        if (stat.currentHp < 0)
            return;

    }
}
