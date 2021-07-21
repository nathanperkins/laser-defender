using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{
    Player player;
    TextMeshProUGUI textMesh;

    void Update()
    {
        if (!player) {
            player = FindObjectOfType<Player>();
		}

        if (!textMesh) {
            textMesh = GetComponent<TextMeshProUGUI>();
		}

        if (player) { 
            textMesh.text = player.GetHealth().ToString();
		} else {
            textMesh.text = "Dead";
		}
    }
}
