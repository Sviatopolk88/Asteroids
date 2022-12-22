using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    
    [SerializeField] private TextMeshProUGUI _result;
    [SerializeField] private Button _newGameBtn;
    [SerializeField] private GameManager _gameManager;

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
    }

}
