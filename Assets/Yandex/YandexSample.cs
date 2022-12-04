using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class YandexSample : MonoBehaviour
{
    /*
    [DllImport("__Internal")]
    private static extern void SaveExtern(string data);

    [DllImport("__Internal")]
    private static extern void LoadExtern();

    [DllImport("__Internal")]
    private static extern void SetToLeaderboard(int value);

    [DllImport("__Internal")]
    private static extern void ShowAdv();

    private PlayerInfoData _playerData;

    [SerializeField] private TextMeshProUGUI _playerDataTxt;

    public void Save()
    {
        string jsonString = JsonUtility.ToJson(_playerData);
        SaveExtern(jsonString);
    }

    public void SetPlayerData(string value)
    {
        _playerData = JsonUtility.FromJson<PlayerInfoData>(value);
        _playerDataTxt.text = _playerData.Score.ToString();
    }

    public void EndLevel()
    {
        var score = _playerData.Score;
        
        Save();

        SetToLeaderboard(score);
    }
    */
}
/*
[System.Serializable]
public class PlayerInfoData
{
    public int Score;
}
*/
