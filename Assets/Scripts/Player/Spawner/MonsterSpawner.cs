using UnityEngine;
using UnityEngine.InputSystem;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
     /*   if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            SpawnMonsterWithCircle(10, 15, PoolingType.Monster_SkeletonKnight);
        }
        else if (Keyboard.current.altKey.wasPressedThisFrame)
        {
            SpawnMonsterRandomPoint(10, 1, PoolingType.Monster_Zombie);
        }*/
    }

    public bool IsOutsideCamera(Vector2 worldPos)
    {
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(worldPos);

        return viewportPos.x < 0f || viewportPos.x > 1f ||
               viewportPos.y < 0f || viewportPos.y > 1f;
    }
    
    // [각도기반] 플레이어 주변 angle만큼 Type의 몬스터 리스폰  
    public void SpawnMonsterWithCircle(int Radius, float angleStep, PoolingType PoolingType)
    {
        Vector2 playerPos = playerTransform.position;

        for (float angle = 0f; angle < 360f; angle += angleStep)
        {
            float rad = angle * Mathf.Deg2Rad;

            Vector2 offset = new Vector2( Mathf.Cos(rad), Mathf.Sin(rad)) * Radius;
            Vector2 spawnPos = playerPos + offset;

            // 카메라 안이면 스킵
            if (!IsOutsideCamera(spawnPos))
                continue;

            GameObject monster = GameManager.instance.poolManager.GetPoolObject(PoolingType);
            monster.transform.position = spawnPos;
        }
    }

    // [ 길이 기반 ] Radius 만큼 떨어진 위치에 Count만큼 몬스터 리스폰 
    public void SpawnMonsterRandomPoint(int Radius, int MonsterCount, PoolingType PoolingType)
    {
        Vector2 playerPos = playerTransform.position;
        int maxTryCount = 20;

        for (int i = 0; i < MonsterCount; i++)
        {
            Vector2 spawnPos = Vector2.zero;
            bool found = false;

            for (int tryCount = 0; tryCount < maxTryCount; tryCount++)
            {
                float angle = Random.Range(0f, Mathf.PI * 2f);

                Vector2 offset = new Vector2( Mathf.Cos(angle), Mathf.Sin(angle) ) * Radius;
                spawnPos = playerPos + offset;

                if (IsOutsideCamera(spawnPos))
                {
                    found = true;
                    break;
                }
            }

            if (!found)
                continue; // 위치 못 찾으면 이번 마리는 스킵

            GameObject monster = GameManager.instance.poolManager.GetPoolObject(PoolingType);
            monster.transform.position = spawnPos;
        }
    }
}
