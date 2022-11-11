using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapBackgroundChanger : MonoBehaviour
{
    Image backgroundImage;
    public Sprite changeImage;

    public void ChangeBackground()
    {
        GameObject preview = GameObject.Find("Preview");

        preview.GetComponent<Image>().color = Color.white;
        preview.GetComponent<Image>().sprite = changeImage;
    }
}
