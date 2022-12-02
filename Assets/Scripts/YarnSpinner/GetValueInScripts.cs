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
        memory.GetComponent<InMemoryVariableStorage>().TryGetValue<bool>("$skipWeek", out isSkipWeek);
    }

    public void GetIsTalkEnd() {
        memory.GetComponent<InMemoryVariableStorage>().TryGetValue<bool>("$isTalkEnd", out isTalkEnd);
    }
}