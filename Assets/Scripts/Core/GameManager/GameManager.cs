using UnityEngine;

// singleton아님. 수정필요 
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public PoolManager poolManager;

    private void Awake()
    {
        instance = this;
    }
}
