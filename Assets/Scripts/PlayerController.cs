using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static PlayerController instance;

    [SerializeField] private Stats playerStats;
    [SerializeField] private PlayerDisplay playerHud;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnEnable()
    {
        playerHud.SetupReferences(playerStats);
    }

    private void OnDisable()
    {
        playerHud.TeardownReferences(playerStats);
    }
}
