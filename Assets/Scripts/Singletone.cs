using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Singletone
{

    private static Singletone instance;
    public SaveData saveData = new SaveData();
    // public float initTime;
    // public string playerName;
    // public string gender;

    string gamedataFileName = "GameData.json";
    public static Singletone Instance {
        get {
            if (instance == null) instance = new Singletone();
            return instance;
        }
    }
    
    public Singletone() {

    }

    // 불러오기
    public void LoadGameData()
    {
        string filePath = Application.persistentDataPath + "/" + gamedataFileName;

        // 저장된 게임이 있다면
        if (File.Exists(filePath))
        {
            // 저장된 파일 읽어오고 Json을 클래스 형식으로 전환해서 할당
            string FromJsonData = File.ReadAllText(filePath);
            saveData = JsonUtility.FromJson<SaveData>(FromJsonData);
        }
    }


    // 저장하기
    public void SaveGameData()
    {
        // 클래스를 Json 형식으로 전환 (true : 가독성 좋게 작성)
        string ToJsonData = JsonUtility.ToJson(saveData, true);
        string filePath = Application.persistentDataPath + "/" + gamedataFileName;

        // 이미 저장된 파일이 있다면 덮어쓰고, 없다면 새로 만들어서 저장
        File.WriteAllText(filePath, ToJsonData);

        // 올바르게 저장됐는지 확인 (자유롭게 변형)
    }
}