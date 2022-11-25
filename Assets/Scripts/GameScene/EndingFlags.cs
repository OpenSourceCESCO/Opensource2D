using UnityEngine;
using UnityEngine.UI;

public class EndingFlags
{
    int pCommuHighThresh = 60, pCommuLowThresh = 40;
    float creditHighThres = 3.0f, creditLowThres = 2.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowEndings(GameObject gameoverPopup)
    {
        float credit = Singletone.Instance.playerStats["credit"];
        int pCommu = (int)Singletone.Instance.playerStats["pCommu"];
        string result;

        // 분기를 다음과 같이 설정한다.
        //  학점 > HighThres && 교수교류 > HighThres -> 대학원
        //  학점 > HighThres && 교수교류 < HighThres || 학점 < LowThres && 교수교류 > HighThres -> 취직
        //  학점 < LowThres && 교수 교류 < HighThres -> 백수

        if (credit > creditHighThres)
        {
            if (pCommu > pCommuHighThresh) result = EnterGraduateSchool();
            else if (pCommu < pCommuLowThresh) result = GetJobAGoodCompany();
            else result = GetJobAGoodCompany();
        }
        else if (credit < creditLowThres)
        {
            if (pCommu > pCommuHighThresh) result = GetJobASmallsizeCompany();
            else if (pCommu < pCommuLowThresh) result = StayJobless();
            else result = GetJobASmallsizeCompany();
        }
        else
        {
            if (pCommu > pCommuHighThresh) result = GetJobAMiddlesizeCompany();
            else if (pCommu < pCommuLowThresh) result = GetJobASmallsizeCompany();
            else result = GetJobAMiddlesizeCompany();
        }

        gameoverPopup.transform.Find("Result").gameObject.GetComponent<Text>().text = result;
    }

    string GetJobAGoodCompany()
    {
        // got job : 취직하다
        return "대기업";
    }

    string GetJobAMiddlesizeCompany()
    {
        return "중견기업";
    }

    string GetJobASmallsizeCompany()
    {
        return "중소기업";
    }

    string EnterGraduateSchool()
    {
        // graduate school이 대학원 이라는 뜻
        return "대학원 진학";
    }

    string StayJobless()
    {
        return "백-수";
    }
}
