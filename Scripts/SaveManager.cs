using UnityEngine;

public static class SaveManager
{
    public static void SavePlayerPosition(Vector3 position)
    {
        PlayerPrefs.SetFloat("PlayerX", position.x);
        PlayerPrefs.SetFloat("PlayerY", position.y);
        PlayerPrefs.SetFloat("PlayerZ", position.z);
        PlayerPrefs.Save();
    }

    public static Vector3 LoadPlayerPosition()
    {
        float x = PlayerPrefs.GetFloat("PlayerX", 0f);
        float y = PlayerPrefs.GetFloat("PlayerY", 1f); // 1 to avoid spawn inside ground
        float z = PlayerPrefs.GetFloat("PlayerZ", 0f);
        return new Vector3(x, y, z);
    }

    public static bool HasSavedPosition()
    {
        return PlayerPrefs.HasKey("PlayerX");
    }
}
