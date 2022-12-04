using System.Collections;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Yandex : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void RequestPlayerData();

    [SerializeField] private RawImage _avatar;
    [SerializeField] private TextMeshProUGUI _playerName;

    private void Start()
    {
        RequestPlayerData();
    }

    public void SetName(string name)
    {
        _playerName.text = name;
    }

    public void SetAvatar(string url)
    {
        StartCoroutine(DownloadImage(url));
    }

    IEnumerator DownloadImage(string mediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(mediaUrl);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(request.error);
        }
        else
        {
            _avatar.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
    }
}
