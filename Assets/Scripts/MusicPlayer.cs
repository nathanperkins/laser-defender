using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake()
    {
        SetupSingleton();
    }

    private void SetupSingleton()
    {
        int musicPlayerCount = FindObjectsOfType(GetType()).Length;
        if (musicPlayerCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
