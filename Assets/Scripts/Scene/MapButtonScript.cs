using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MapButtonScript : MonoBehaviour
{
    public void ClickBtn()
    {
        GameObject clickBtn = EventSystem.current.currentSelectedGameObject;
        GameObject moveTo = GameObject.FindWithTag("MoveBtn");

        if (moveTo.name != "Yes")
        {
            moveTo.name = "Yes";
        }
        else
        {
            moveTo.name = clickBtn.name;
        }
    }
}
