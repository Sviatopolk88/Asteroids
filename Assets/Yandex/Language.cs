using System.Runtime.InteropServices;
using UnityEngine;

public class Language : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern string GetLang();

    public string CurrentLanguage; //ru en tr

    public static Language Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            CurrentLanguage = GetLang();
            //CurrentLanguage = "ru";
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
