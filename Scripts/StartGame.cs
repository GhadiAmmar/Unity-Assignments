using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class StartGame : MonoBehaviour
{
    // Call this method from your UI Button's OnClick event
    private void OnEnable()
    {
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(OnButtonClick);
    }
    private void OnDisable()
    {
        GetComponent<UnityEngine.UI.Button>().onClick.RemoveListener(OnButtonClick);
    }
    void OnButtonClick()
    {
        // Load the "SampleScene"
        SceneManager.LoadScene("SampleScene");
    }
}
