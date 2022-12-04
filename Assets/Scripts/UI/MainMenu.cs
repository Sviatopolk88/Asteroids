using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    [Header("Main menu")]
    [Space]
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private TextMeshProUGUI _result;
    //[SerializeField] private TextMeshProUGUI _raitTxt;
    [SerializeField] private Button _newGameBtn;
    //[SerializeField] private Button _rateBtn;

    /*

    [DllImport("__Internal")]
    private static extern void RateGame();
    */

    private void Start()
    {
        

        _newGameBtn.onClick.AddListener(NewGame);
        //_rateBtn.onClick.AddListener(RateGameButton);
        Time.timeScale = 0;
        if (GameManager.BestResult > 0)
        {
            Result(GameManager.BestResult);
        }
    }


    public void Result(int score)
    {
        _result.text = score.ToString();
    }

    private void NewGame()
    {
        _mainMenu.SetActive(false);
        Time.timeScale = 1;
    }

    
    public void RateGameButton()
    {
        //RateGame();
    }
    
}
