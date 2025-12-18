using UnityEngine;

public class RepositionComp : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("타일 하나의 가로/세로 크기입니다.")]
    public float tileSize = 20f;

    [Tooltip("플레이어를 감지할 대상 (보통 Player Transform)")]
    public Transform playerTransform;

    // 무한 맵 구성을 위한 오프셋 (3x3 그리드 기준, 중심에서 벗어나는 거리)
    // 3x3 타일 배치라면, 타일은 플레이어보다 tileSize만큼 뒤쳐지면 
    // tileSize * 3 만큼 앞으로 점프해야 합니다.
    private float repositionOffset;

    void Start()
    {
        // 3x3 그리드를 가정할 때, 타일이 3개(좌, 중, 우)이므로 
        // 전체 맵 길이는 tileSize * 3 입니다.
        // 따라서 이동해야 할 거리는 tileSize * 3이 적절합니다.
        // 만약 2x2나 다른 구조라면 이 값을 조정해야 합니다.
        repositionOffset = tileSize * 3f;

        // 플레이어를 자동으로 찾지 못했다면 태그로 찾기 시도
        if (playerTransform == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
                playerTransform = player.transform;
            else
                Debug.LogError("Player를 찾을 수 없습니다! Inspector에서 할당하거나 Player 태그를 확인하세요.");
        }
    }

    void Update()
    {
        if (playerTransform == null) return;

        // 플레이어와 타일의 거리 계산
        Vector3 playerPos = playerTransform.position;
        Vector3 myPos = transform.position;

        // X축 거리 차이 계산
        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);

        // [중요] 타일 재배치 로직
        // 플레이어와 타일의 거리가 '타일 크기 * 1.5' (즉, 인접 타일 범위를 넘어섬) 이상 벌어지면 이동
        // 3x3 그리드에서 중앙 타일로부터 1.5칸 이상 멀어지면 화면 밖으로 간주합니다.

        float triggerDistance = tileSize * 1.5f;

        // X축 재배치
        if (diffX > triggerDistance)
        {
            // 플레이어가 타일보다 오른쪽에 있으면(playerPos.x > myPos.x), 타일을 오른쪽 끝으로 보냄
            // 반대라면 왼쪽 끝으로 보냄
            float dirX = playerPos.x > myPos.x ? 1 : -1;

            // 현재 위치에서 맵 전체 길이(repositionOffset)만큼 이동
            Vector3 newPos = new Vector3(myPos.x + (dirX * repositionOffset), myPos.y, myPos.z);
            transform.position = newPos;
        }

        // Y축 재배치 (대각선 이동 포함하여 독립적으로 체크)
        if (diffY > triggerDistance)
        {
            float dirY = playerPos.y > myPos.y ? 1 : -1;
            Vector3 newPos = new Vector3(transform.position.x, myPos.y + (dirY * repositionOffset), myPos.z);
            transform.position = newPos;
        }
    }
}
