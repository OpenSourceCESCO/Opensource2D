using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    int healthDec = 0;
    public int decHealthFactor = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Singletone.Instance.playerStats["health"] < 0) return;
        else if (Singletone.Instance.playerStats["health"] > 100) return;

        if ((int)((Singletone.Instance.saveData.initTime - Timer.rTime)/5) == (healthDec+1)) {
            Singletone.Instance.playerStats["health"] -= decHealthFactor;
            healthDec++;
        }
    }   
}
