using UnityEngine;
using TMPro;

public class TextDisplay : MonoBehaviour
{
    public RaycastInspector raycastInspector; // Drag the object with RaycastInspector into this field
    public TextMeshProUGUI scoreText; // Use TMP component under Canvas

    void Update()
    {
        if (raycastInspector != null && scoreText != null)
        {
            scoreText.text = "Score: " + raycastInspector.score;
        }
    }
}


