using UnityEngine;
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


    [Header("Data")]
    [Space]
    [SerializeField] private PlayerMove _player;

    private void Start()
    {
        EventManager.OnChangeScore.AddListener(UpdateScore);
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
}
