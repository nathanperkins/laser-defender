using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] int score = 0;

    void Awake()
    {
        SetUpSingleton();              
    }

    void SetUpSingleton() {
        int count = FindObjectsOfType(GetType()).Length;
        if (count > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
		} else {
            DontDestroyOnLoad(gameObject);
		}
	}

    public int GetScore() { return score; }
    public void AddToScore(int points) { score += points; }

    public void Reset()
    {
        Destroy(gameObject);
    }
}
