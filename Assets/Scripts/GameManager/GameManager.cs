using InstantGamesBridge;
using InstantGamesBridge.Modules.Leaderboard;
using InstantGamesBridge.Modules.Advertisement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const string _yandexLeaderboardNameInput = "Leaders";

    public PlayerData PlayerData;

    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private UI_EndGameWindow _endGameWindow;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private PlayerShooting _playerShooting;

    public static int BestResult { get; private set; }

    private void Start()
    {
        PlayerData = new PlayerData();
        _playerMove.enabled = false;
        _playerShooting.enabled = false;
        
        if (Bridge.player.isAuthorized)
        {
            GetScore();
        }

        SoundManager.Instance.BackMusicTurnOff();
        OnShowInterstitial();

        EventManager.OnAddPoints.AddListener(AddPoints);
        EventManager.OnGameOver.AddListener(StopGame);
    }

    private void GetScore()
    {
        Bridge.leaderboard.GetScore(
            (success, score) =>
            {
                if (success)
                {
                    BestResult = score;
                    _mainMenu.Result(BestResult);
                }
                else
                {
                    BestResult = 0;
                    _mainMenu.Result(BestResult);
                }
            },
            new GetScoreYandexOptions(_yandexLeaderboardNameInput));
    }

    private void OnShowInterstitial()
    {
        // Необязательный параметр, игнорировать ли минимальную задержку
        var ignoreDelay = false; // По умолчанию = false
        Bridge.advertisement.ShowInterstitial
            (
            success => {
                if (success)
                {
                    // Success
                }
                else
                {
                    // Error
                }
            },
            new ShowInterstitialYandexOptions(ignoreDelay)
            );
    }

    public void StartGame()
    {
        SoundManager.Instance.BackMusicTurnOn();
        _spawner.StartSpawnAsteroid();
        _playerMove.enabled = true;
        _playerShooting.enabled = true;
    }

    private void StopGame()
    {
        _spawner.StopSpawner();
        SoundManager.Instance.RocketStop();
        _playerMove.enabled = false;
        _playerShooting.enabled = false;

        if (PlayerData.Score > BestResult)
        {
            if (Bridge.player.isAuthorized)
            {
                SetScore();
            }
        }

        _endGameWindow.gameObject.SetActive(true);
        _endGameWindow.Results(BestResult, PlayerData.Score);
    }

    private void AddPoints(int points)
    {
        PlayerData.AddPoints(points);
    }

    private void SetScore()
    {
        Bridge.leaderboard.SetScore(
            success =>
            {
                if (success)
                {
                    // Success
                }
                else
                {
                    // Error
                }
            },
            new SetScoreYandexOptions(PlayerData.Score, _yandexLeaderboardNameInput));
    }
}

