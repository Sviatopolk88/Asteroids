using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_EndGameWindow : MonoBehaviour
{
    [SerializeField] private GameObject _endGameWindow;
    [SerializeField] private TextMeshProUGUI _bestResult;
    [SerializeField] private TextMeshProUGUI _currentResult;
    [SerializeField] private  Button _newGameBtn;

    private void Start()
    {
        _newGameBtn.onClick.AddListener(NewGame);
    }

    public void Results(int bestResult, int currentResult)
    {
        _bestResult.text = bestResult.ToString();
        _currentResult.text = currentResult.ToString();
    }

    private void NewGame()
    {
        SceneManager.LoadScene(0);
    }
}
