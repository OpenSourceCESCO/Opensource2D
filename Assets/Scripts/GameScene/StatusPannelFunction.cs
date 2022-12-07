using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusPannelFunction : MonoBehaviour
{
    // Start is called before the first frame update
    Dictionary<string, GameObject> status = new Dictionary<string, GameObject>();
    Transform playerStat;

    void Start()
    {
        // Singletone.Instance.InitUserData(); // 테스트용

        playerStat = GameObject.Find("PlayerStat").transform.Find("Background");
        SaveData data = Singletone.Instance.saveData;
        playerStat.Find("NameLayer").Find("UserName").gameObject.GetComponent<Text>().text = string.Format("{0}({1})", data.name, data.gender);

        status.Add("grade", playerStat.Find("GradeLayer").Find("UserGrade").gameObject);
        status.Add("weeks", playerStat.Find("GradeLayer").Find("Weeks").gameObject);

        status.Add("money", playerStat.Find("MoneyLayer").Find("UserMoney").gameObject);
        status.Add("sCommu", playerStat.Find("CommunicationLayer").Find("StudentCommunication").gameObject);
        status.Add("pCommu", playerStat.Find("CommunicationLayer").Find("ProfessorCommunication").gameObject);
        status.Add("int", playerStat.Find("IntelLayer").Find("UserIntel").gameObject);
        status.Add("credit", playerStat.Find("CreditLayer").Find("UserCredit").gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerStat.gameObject.activeSelf)
            return;

        foreach (KeyValuePair<string, GameObject> item in status)
        {
            string text = Singletone.Instance.playerStats[item.Key].ToString();
            print(string.Format("{0} {1}", item.Key, Singletone.Instance.playerStats[item.Key]));
            switch (item.Key)
            {
                case "grade":
                    text += "학년";
                    break;
                case "weeks":
                    text = string.Format("{0,3}주({1,2})", text, int.Parse(text) % 6 == 0 ? "방학" : "학기");
                    break;
                case "credit":
                    text = string.Format("{0} / {1}", text, "4.5");
                    break;
                default:
                    break;
            }
            item.Value.GetComponent<Text>().text = text;
        }
    }

}
