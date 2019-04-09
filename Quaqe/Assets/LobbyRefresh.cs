using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LobbyRefresh : MonoBehaviour
{
    public InputField ip;
    public GameObject content;
    public GameObject panel;

    public void Start()
    {
        ip.text = "localhost";
    }

    public void OnClick()
    {
        StartCoroutine(PostRequest());
    }

    IEnumerator PostRequest()
    {
        WWWForm formData = new WWWForm();
        formData.AddField("Do", "RefreshLobbies");
        //UnityWebRequest www = UnityWebRequest.Post("http://" + ip.text + ":3005", formData);
        UnityWebRequest www = UnityWebRequest.Get("http://" + ip.text + ":3005");
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            var responseString = www.downloadHandler.text;
            var lobbies = LobbyInfo.UnchainLobbyInfo(responseString);
            foreach (Transform child in content.transform)
            {
                Destroy(child.gameObject);
            }
            foreach (LobbyInfo li in lobbies)
            {
                GameObject child = Instantiate(panel);
                child.GetComponent<LobbyController>().name = li.name;
                child.GetComponent<LobbyController>().ip = li.ip;
                child.GetComponent<LobbyController>().Regenerate();
                child.transform.parent = content.transform;
                child.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
