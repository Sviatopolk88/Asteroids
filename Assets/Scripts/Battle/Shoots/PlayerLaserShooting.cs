using UnityEngine;

public class PlayerLaserShooting : MonoBehaviour
{
    
    [SerializeField] private UI_Manager _ui;

    private PlayerShooting _shoot;

    private void Start()
    {
        EventManager.OnChangeAmountLaserCharges.AddListener(AvailableLaserCharges);
        _shoot = GetComponent<PlayerShooting>();
    }

    private void Update()
    {
        if (_shoot.Recharge) RechargeTimer();
    }

    private void RechargeTimer()
    {
        _ui.RechargeTimer(_shoot.Timer);
    }

    private void AvailableLaserCharges(int charges)
    {
        _ui.AvailableCharges(charges);
    }
}
