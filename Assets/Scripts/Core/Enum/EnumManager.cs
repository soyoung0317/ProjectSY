public enum GameState
{
    Title,
    Playing,
    Paused,
    GameOver
}

public enum ElementType
{
    Fire,
    Water,
    Earth,
    Wind
}

public enum EnemyState
{
    Chase,
    Knockback,
    Stun,
    Reposition
}

public enum PoolingType
{
    Monster_Zombie ,
    Monster_SkeletonKnight,
    Test_Weapon

}

// 임시 - 플레이어 가능한 캐릭터 종류 
public enum CharacterType
{
    Type_A,
    Type_B
}

// FSM 전까지 몬스터 / 플레이어 사용할 STATE ENUM 
public enum CharacterState
{
    IDLE,
    HIT,
    DIE
}

