using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    private int Data = 0;

    public void SaveData(string id, int data)
    {
        PlayerPrefs.SetInt(id, data);
        PlayerPrefs.Save();
    }
    public int LoadData(string id)
    {
        if (PlayerPrefs.HasKey(id))
        {
            return PlayerPrefs.GetInt(id);
        }
        Debug.LogError("There is no save data!");
        return 0;
    }
}
