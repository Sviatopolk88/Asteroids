using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    
    [SerializeField] private TextMeshProUGUI _result;
    [SerializeField] private Button _newGameBtn;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject _joystick;
    [SerializeField] private GameObject _accelerationButton;

    private void Start()
    {
        _newGameBtn.onClick.AddListener(NewGame);
    }

    public void Result(int score)
    {
        _result.text = score.ToString();
    }

    private void NewGame()
    {
        _mainMenu.SetActive(false);
        _gameManager.StartGame();

        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            _joystick.SetActive(true);
            _accelerationButton.SetActive(true);
        }
    }

}
