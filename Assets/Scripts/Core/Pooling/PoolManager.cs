using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [Header("Pooling Prefabs (enum 순서와 반드시 일치)")]
    public GameObject[] prefabs;

    private List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject GetPoolObject(PoolingType type)
    {
        int index = (int)type;
        return GetPoolObjectInternal(index);
    }

    private GameObject GetPoolObjectInternal(int index)
    {
        GameObject select = null;

        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                item.SetActive(true);
                break;
            }
        }

        if (select == null)
        {
            select = Instantiate(prefabs[index], transform);
            select.SetActive(false);
            pools[index].Add(select);
        }

        select.SetActive(true);
        return select;
    }
}
