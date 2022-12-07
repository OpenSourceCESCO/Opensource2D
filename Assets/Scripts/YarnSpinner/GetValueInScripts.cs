using UnityEngine;
using Yarn.Unity;

public class GetValueInScripts : MonoBehaviour {
    [SerializeField] Transform memory;

    public bool isSkipWeek, isTalkEnd;
    string playerName;

    void Start() {
        playerName = Singletone.Instance.saveData.name;
        isSkipWeek = false;
        isTalkEnd = false;
        memory = GameObject.Find("DSParent").transform.Find("Dialogue System");

        memory.GetComponent<InMemoryVariableStorage>().SetValue("$playerName", playerName);
    }

    public void GetSkipWeekFlag()
    {
        try {
            memory.GetComponent<InMemoryVariableStorage>().TryGetValue<bool>("$skipWeek", out isSkipWeek);
        }
        catch {

        }
    }

    public void GetIsTalkEnd() {
        try {
            memory.GetComponent<InMemoryVariableStorage>().TryGetValue<bool>("$isTalkEnd", out isTalkEnd);
        }
        catch  {

        }
    }
}