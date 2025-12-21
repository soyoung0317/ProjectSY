using UnityEngine;

public class SimpleOrbitalComponent : OrbitalWeapon
{
    [Header("Simple Orbital Props")]
    public GameObject orbitalPropsPrefab; // 궤도상에서 도는 Props 프리팹
    public int propsCount = 1;            // Props 개수 (기본 1개)
    
    private GameObject[] orbitalProps;    // 생성된 Props들
    private float[] angles;               // 각 Props의 초기 각도
    
    protected override void Start()
    {
        base.Start();
        
        // Props 프리팹이 할당되어 있으면 생성
        if (orbitalPropsPrefab != null && propsCount > 0)
        {
            InitializeProps();
        }
    }
    
    private void InitializeProps()
    {
        orbitalProps = new GameObject[propsCount];
        angles = new float[propsCount];
        
        float angleStep = 360f / propsCount;
        
        for (int i = 0; i < propsCount; i++)
        {
            orbitalProps[i] = Instantiate(orbitalPropsPrefab, transform);
            angles[i] = currentAngle + (i * angleStep);
            
            if (owner != null)
            {
                float radian = angles[i] * Mathf.Deg2Rad;
                Vector3 initialPosition = owner.position + new Vector3(
                    Mathf.Cos(radian) * radius,
                    Mathf.Sin(radian) * radius,
                    0f
                );
                orbitalProps[i].transform.position = initialPosition;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 충돌대상 - 몬스터 
        if (!collision.CompareTag("Monster"))
            return;

        //collision.GetComponent<MonsterStatComponent>().GetDamage(owner.GetComponent<PlayerStatController>().GetPlayerAttackDamage());

    }


    /*    base.Update();
        
        // Props들이 Owner 주위를 따라 회전하도록 업데이트
        if (orbitalProps != null && owner != null)
        {
            for (int i = 0; i < orbitalProps.Length; i++)
            {
                if (orbitalProps[i] == null) continue;
                
                angles[i] += rotationSpeed * Time.deltaTime;
                
                if (angles[i] >= 360f) angles[i] -= 360f;
                if (angles[i] < 0f) angles[i] += 360f;
                
                float radian = angles[i] * Mathf.Deg2Rad;
                Vector3 newPosition = owner.position + new Vector3(
                    Mathf.Cos(radian) * radius,
                    Mathf.Sin(radian) * radius,
                    0f
                );
                
                orbitalProps[i].transform.position = newPosition;
            }
        }*/
}
