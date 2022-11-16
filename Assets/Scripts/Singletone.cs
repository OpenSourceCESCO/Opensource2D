using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Singletone
{

    private static Singletone instance;
    public SaveData saveData = new SaveData();
    public float timeFactor = 10f;
    public Dictionary<string, int> playerStats = new Dictionary<string, int>();

    string gamedataFileName = "GameData.json";
    public static Singletone Instance {
        get {
            if (instance == null) instance = new Singletone();
            return instance;
        }
    }
    
    // 이 싱글톤 객체의 생성자
    public Singletone() {
        playerStats["int"]          = 50;
        playerStats["health"]       = 50;
        playerStats["mental"]       = 50;
        playerStats["friendship"]   = 50;
        playerStats["emothion"]     = 50;
        playerStats["money"]        = 1000;
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

            // 딕셔너리를 배열로 바꾸어 저장한 것을 딕셔너리로 재생성
            for (int i = 0; i < saveData.statNames.Count; i++) {
                playerStats[saveData.statNames[i]] = saveData.statValues[i];
            }
        }
    }


    // 저장하기
    public void SaveGameData()
    {
        // 딕셔너리를 바로 json화 시킬 수 없음.
        // 따라서 배열로 저장한 후, 이 배열을 저장
        foreach (KeyValuePair<string, int> item in playerStats) {
            saveData.statNames.Add(item.Key);
            saveData.statValues.Add(item.Value);
        }

        // 클래스를 Json 형식으로 전환 (true : 가독성 좋게 작성)
        string ToJsonData = JsonUtility.ToJson(saveData, true);
        string filePath = Application.persistentDataPath + "/" + gamedataFileName;

        // 이미 저장된 파일이 있다면 덮어쓰고, 없다면 새로 만들어서 저장
        File.WriteAllText(filePath, ToJsonData);

        // 올바르게 저장됐는지 확인 (자유롭게 변형)
    }
}