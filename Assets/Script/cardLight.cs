using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cardLight : MonoBehaviour
{
    public GameObject lightImg;

    public void Light(bool on)
    {
        lightImg.SetActive(on);
    }
}
