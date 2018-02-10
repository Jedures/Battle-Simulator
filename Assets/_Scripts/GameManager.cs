using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        if (Instance != null)
        {
            DestroyObject(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        _instance = this;
    }

    public void GetInfo()
    {

    }
}
