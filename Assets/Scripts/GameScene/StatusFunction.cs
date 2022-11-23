using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusMenu : MonoBehaviour
{
    // Start is called before the first frame update
    Dictionary<string, GameObject> status = new Dictionary<string, GameObject>();
    Transform playerStat;

    void Start()
    {
        playerStat = GameObject.Find("PlayerStat").transform.Find("Background");
        SaveData data = Singletone.Instance.saveData;
        playerStat.Find("NameLayer").Find("UserName").gameObject.GetComponent<Text>().text = string.Format("{0}({1})", data.name, data.gender);
        playerStat.Find("GradeLayer").Find("UserGradeMAX").gameObject.GetComponent<Text>().text = data.grade;

        status.Add("health", playerStat.Find("HealthLayer").Find("UserHealth").gameObject);
        status.Add("money", playerStat.Find("MoneyLayer").Find("UserMoney").gameObject);
        status.Add("friendship", playerStat.Find("FriendshipLayer").Find("UserFriendship").gameObject);
        status.Add("intel", playerStat.Find("IntelLayer").Find("UserIntel").gameObject);
        status.Add("emotion", playerStat.Find("EmotionLayer").Find("UserEmotion").gameObject);
        status.Add("mental", playerStat.Find("MentalLayer").Find("UserMental").gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStat.gameObject.activeSelf)
        {
            foreach (KeyValuePair<string, GameObject> item in status)
            {
                item.Value.GetComponent<Text>().text = Singletone.Instance.playerStats[item.Key].ToString();
            }
        }
    }
}
