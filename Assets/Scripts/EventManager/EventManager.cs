using UnityEngine.Events;

public class EventManager
{
    public static UnityEvent<int> OnAddPoints = new UnityEvent<int>();
    public static UnityEvent<int> OnChangeAmountLaserCharges = new UnityEvent<int>();
    public static UnityEvent OnGameOver = new UnityEvent();
    public static UnityEvent OnSmallAsteroidDistruction = new UnityEvent();

    public static void SendSmallAsteroidDistruction()
    {
        OnSmallAsteroidDistruction.Invoke();
    }

    public static void SendAddPoints(int points)
    {
        OnAddPoints.Invoke(points);
    }

    public static void SendChangeAmountLaserCharges(int charges)
    {
        OnChangeAmountLaserCharges.Invoke(charges);
    }

    public static void SendGameOver()
    {
        OnGameOver.Invoke();
    }
}
