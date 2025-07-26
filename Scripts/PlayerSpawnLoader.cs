using UnityEngine;

public class PlayerSpawnLoader : MonoBehaviour
{
    void Start()
    {
        if (SaveManager.HasSavedPosition())
        {
            Vector3 savedPos = SaveManager.LoadPlayerPosition();
            transform.position = savedPos;
            Debug.Log("Loaded saved position: " + savedPos);
        }
    }
}
