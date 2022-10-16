using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    [Header("Top Panel")]
    [Space]
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _position;
    [SerializeField] private TextMeshProUGUI _rotation;
    [SerializeField] private TextMeshProUGUI _speed;
    [SerializeField] private TextMeshProUGUI _charges;
    [SerializeField] private TextMeshProUGUI _recharge;

    [Header("Main menu")]
    [Space]
    [SerializeField] private GameObject _menu;
    [SerializeField] private TextMeshProUGUI _result;
    [SerializeField] private Button _newGameBtn;
    [SerializeField] private Button _quitBtn;

    [Header("Data")]
    [Space]
    [SerializeField] private PlayerMove _player;

    private void Start()
    {
        _newGameBtn.onClick.AddListener(NewGame);
        _quitBtn.onClick.AddListener(Quit);
    }

    private void Update()
    {
        UpdateDataPlayer();
    }


    #region TOP_PANEL
    public void UpdateDataPlayer()
    {
        _position.text = $"{Mathf.Round(_player.transform.position.x * 100)} x {Mathf.Round(_player.transform.position.y * 100)}".ToString();
        _rotation.text = _player.Direction.ToString("0");
        _speed.text = (_player.Speed * 10).ToString("00.0");
    }

    public void UpdateScore(int score)
    {
        _score.text = score.ToString();
    }

    public void RechargeTimer(float timer)
    {
        _recharge.text = timer.ToString("00.0");
    }

    public void AvailableCharges(int charges)
    {
        _charges.text = charges.ToString();
    }
    #endregion

    #region MAIN_MENU

    public void OpenMenu()
    {
        _menu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Result(int result)
    {
        _result.text = result.ToString();
    }

    private void NewGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Quit()
    {
        Application.Quit();
    }

    #endregion
}
