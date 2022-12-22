using InstantGamesBridge;
using UnityEngine;

public class Language : MonoBehaviour
{
    public string CurrentLanguage;

    public static Language Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            CurrentLanguage = Bridge.platform.language;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
