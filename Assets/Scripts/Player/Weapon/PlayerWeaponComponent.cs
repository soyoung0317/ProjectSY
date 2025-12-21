using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어의 무기들을 관리하는 매니저 컴포넌트
/// 플레이어 GameObject에 추가하여 사용
/// </summary>
public class PlayerWeaponComponent : MonoBehaviour
{
    [Header("Weapon Settings")]
    [SerializeField] private int maxWeaponCount = 6;  // 최대 보유 무기 개수
    
    [Header("Debug")]
    [SerializeField] private bool showWeaponList = true;  // 디버그용 무기 리스트 표시
    
    private List<Weapon> weapons = new List<Weapon>();  // 현재 보유 중인 무기 리스트
    
    /// <summary>
    /// 현재 보유 중인 무기 리스트 (읽기 전용)
    /// </summary>
    public IReadOnlyList<Weapon> Weapons => weapons;
    
    /// <summary>
    /// 현재 보유 중인 무기 개수
    /// </summary>
    public int WeaponCount => weapons.Count;
    
    /// <summary>
    /// 최대 보유 가능한 무기 개수
    /// </summary>
    public int MaxWeaponCount => maxWeaponCount;
    
    private void Awake()
    {
        // 초기화
        weapons = new List<Weapon>();
    }
    
    /// <summary>
    /// 무기를 추가 (습득)
    /// </summary>
    /// <param name="weaponPrefab">추가할 무기 프리팹 (Weapon 컴포넌트가 있는 GameObject)</param>
    /// <returns>추가 성공 여부</returns>
    public bool AddWeapon(GameObject weaponPrefab)
    {
        // 최대 개수 체크
        if (weapons.Count >= maxWeaponCount)
        {
            Debug.LogWarning($"무기 최대 개수({maxWeaponCount})에 도달했습니다.");
            return false;
        }
        
        // 프리팹에서 Weapon 컴포넌트 확인
        Weapon weaponComponent = weaponPrefab.GetComponent<Weapon>();
        if (weaponComponent == null)
        {
            Debug.LogError($"무기 프리팹에 Weapon 컴포넌트가 없습니다: {weaponPrefab.name}");
            return false;
        }
        
        // 이미 같은 타입의 무기가 있는지 확인 (선택적 - 필요시 주석 해제)
        // if (HasWeaponType(weaponComponent.GetType()))
        // {
        //     Debug.LogWarning($"이미 같은 타입의 무기를 보유하고 있습니다.");
        //     return false;
        // }
        
        // 무기 GameObject 생성 (독립적인 GameObject로)
        GameObject weaponInstance = Instantiate(weaponPrefab);
        weaponInstance.name = weaponPrefab.name + $" (Instance_{weapons.Count})";
        
        // 생성된 무기 컴포넌트 가져오기
        Weapon weapon = weaponInstance.GetComponent<Weapon>();
        
        // Owner 설정 (이 매니저가 붙어있는 플레이어)
        weapon.owner = transform;
        
        // 리스트에 추가
        weapons.Add(weapon);
        
        Debug.Log($"무기 습득: {weaponPrefab.name} (현재 무기 개수: {weapons.Count}/{maxWeaponCount})");
        
        return true;
    }
    
    /// <summary>
    /// 무기 제거 (드롭 또는 파괴)
    /// </summary>
    /// <param name="weapon">제거할 무기</param>
    public void RemoveWeapon(Weapon weapon)
    {
        if (weapons.Remove(weapon))
        {
            // GameObject 파괴
            if (weapon != null && weapon.gameObject != null)
            {
                Destroy(weapon.gameObject);
            }
            Debug.Log($"무기 제거: {weapon.name} (현재 무기 개수: {weapons.Count}/{maxWeaponCount})");
        }
    }
    
    /// <summary>
    /// 특정 타입의 무기가 있는지 확인
    /// </summary>
    /// <param name="weaponType">확인할 무기 타입</param>
    /// <returns>보유 여부</returns>
    public bool HasWeaponType(System.Type weaponType)
    {
        foreach (var weapon in weapons)
        {
            if (weapon.GetType() == weaponType || weapon.GetType().IsSubclassOf(weaponType))
            {
                return true;
            }
        }
        return false;
    }
    
    /// <summary>
    /// 모든 무기 제거
    /// </summary>
    public void ClearAllWeapons()
    {
        for (int i = weapons.Count - 1; i >= 0; i--)
        {
            RemoveWeapon(weapons[i]);
        }
    }
    
    // 디버그용
    private void OnGUI()
    {
        if (showWeaponList && weapons.Count > 0)
        {
            string weaponList = "무기 리스트:\n";
            for (int i = 0; i < weapons.Count; i++)
            {
                if (weapons[i] != null)
                    weaponList += $"{i + 1}. {weapons[i].name}\n";
            }
            GUI.Label(new Rect(10, 10, 300, 500), weaponList);
        }
    }
}

