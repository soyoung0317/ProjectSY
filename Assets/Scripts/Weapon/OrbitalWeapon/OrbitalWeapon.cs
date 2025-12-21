using UnityEngine;

public class OrbitalWeapon : Weapon
{
    [Header("Orbital Settings")]
    public float rotationSpeed = 100f;  // 회전 속도 (도/초)
    public float radius = 2f;           // Owner로부터의 거리 (반지름)
    
    protected float currentAngle = 0f;  // 현재 각도

    protected override void Start()
    {
        base.Start();
    }

    public override void Attack()
    {
        // 궤도형은 지속형이므로 Update에서 처리하고,
        // OnTriggerEnter로 충돌 시 데미지를 주는 방식
    }

    public void Update()
    {
        if (owner == null) return;

        // 각도를 회전 속도에 따라 업데이트
        currentAngle += rotationSpeed * Time.deltaTime;
        
        // 각도를 0~360 범위로 정규화
        if (currentAngle >= 360f) currentAngle -= 360f;
        if (currentAngle < 0f) currentAngle += 360f;
        
        // 위치 업데이트
        UpdatePosition();
    }
    
    private void UpdatePosition()
    {
        if (owner == null) return;
        
        // Owner 주위를 회전하는 위치 계산
        float radian = currentAngle * Mathf.Deg2Rad;
        Vector3 targetPosition = owner.position + new Vector3(
            Mathf.Cos(radian) * radius,
            Mathf.Sin(radian) * radius,
            0f
        );
        
        transform.position = targetPosition;
    }
}