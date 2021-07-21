using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    GameSession gameSession;
    TextMeshProUGUI textMesh;

    void Update()
    {
        if (!gameSession) {
            gameSession = FindObjectOfType<GameSession>();
		}

        if (!textMesh) {
            textMesh = GetComponent<TextMeshProUGUI>();
		}

        if (gameSession) { 
	        textMesh.text = gameSession.GetScore().ToString();
		} else {
            textMesh.text = "No Score";
		}
    }
}
