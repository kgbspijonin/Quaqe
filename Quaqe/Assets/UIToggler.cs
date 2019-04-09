using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIToggler : MonoBehaviour
{
    public GameObject handle;

    public void OnClick()
    {
        handle.SetActive(!handle.gameObject.activeInHierarchy);
    }
}
