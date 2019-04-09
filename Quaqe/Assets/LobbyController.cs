using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public string name;
    public string ip;

    public void Regenerate()
    {
        transform.Find("Name").GetComponent<Text>().text = name;
        transform.Find("IP").GetComponent<Text>().text = ip;
    }
}
