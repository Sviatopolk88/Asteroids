using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerData PlayerData;
    public PlayerYandexData YandexData;

    [SerializeField] private TextMeshProUGUI _testTxt;
    [SerializeField] private TextMeshProUGUI _lngTxt;

    private int tst = 0;

    public static int BestResult { get; private set; }

    [DllImport("__Internal")]
    private static extern void SaveExtern(string data);

    [DllImport("__Internal")]
    private static extern void LoadExtern();

    [DllImport("__Internal")]
    private static extern void SetToLeaderboard(int value);

    [DllImport("__Internal")]
    private static extern void ShowAdv();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayerData = new PlayerData();
        YandexData = new PlayerYandexData();
        LoadExtern();
        SoundManager.Instance.BackMusicTurnOn();
        EventManager.OnAddPoints.AddListener(AddPoints);
        EventManager.OnGameOver.AddListener(CloseScene);
    }
    public void Save()
    {
        string jsonString = JsonUtility.ToJson(YandexData);
        SaveExtern(jsonString);
    }

    public void SetPlayerData(string value)
    {
        YandexData = JsonUtility.FromJson<PlayerYandexData>(value);
        if (_testTxt)
        {
            _testTxt.text = YandexData.BestResult.ToString();
        }
        
        if (YandexData.BestResult > 0 && YandexData.BestResult > BestResult)
        {
            BestResult = YandexData.BestResult;
        }
    }

    private void AddPoints(int points)
    {
        PlayerData.AddPoints(points);
        if (BestResult < PlayerData.Score)
        {
            BestResult = PlayerData.Score;
        }
    }

    public void CloseScene()
    {
        if (YandexData.BestResult < BestResult)
        {
            YandexData.BestResult = BestResult;
            Save();
            SetToLeaderboard(BestResult);
        }
        
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 0;
        PlayerData.RemovePoints();
        SoundManager.Instance.BackMusicTurnOff();
        ShowAdv();
    }
}

public class PlayerYandexData
{
    public int BestResult;
}
