using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 플레이어의 무기들을 관리하는 매니저 컴포넌트
/// 플레이어 GameObject에 추가하여 사용
/// </summary>
public class PlayerWeaponComponent : MonoBehaviour
{
    [Header("Weapon Settings")]
    [SerializeField] private int maxWeaponCount = 3;  // 최대 보유 무기 개수
    
    private List<Weapon> weapons = new List<Weapon>();  // 현재 보유 중인 무기 리스트
    
    
    private void Awake()
    {
        // 초기화
        weapons = new List<Weapon>();
    }
    
    public void FixedUpdate()
    {
        // 임시 무기 부여 및 작동 확인 
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            GameObject weapon = GameManager.instance.poolManager.GetPoolObject(PoolingType.Test_Weapon);
            weapon.transform.position = transform.position;
            weapon.GetComponent<Weapon>().owner = transform;
            AddWeapon(weapon);
        }
        
    }
    public bool AddWeapon(GameObject weaponPrefab)
    {
        // 최대 개수 체크
        if (weapons.Count >= maxWeaponCount)
        {
            return false;
        }
        
        // 프리팹에서 Weapon 컴포넌트 확인
        Weapon weaponComponent = weaponPrefab.GetComponent<Weapon>();

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

}

