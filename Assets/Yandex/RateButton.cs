using UnityEngine;

public class RateButton : MonoBehaviour
{
    [SerializeField] private GameObject _rateBtn;

    public void HideRadeBtn()
    {
        _rateBtn.SetActive(false);
    }
}
