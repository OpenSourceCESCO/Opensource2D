using UnityEngine;
using Yarn.Unity;

public class GetValueInScripts : MonoBehaviour {
    Transform memory;

    public bool isSkipWeek, isTalkEnd;

    void Start() {
        isSkipWeek = false;
        isTalkEnd = false;
        memory = GameObject.Find("DSParent").transform.Find("Dialogue System");
    }

    public void GetSkipWeekFlag()
    {
        memory.GetComponent<InMemoryVariableStorage>().TryGetValue<bool>("$skipWeek", out isSkipWeek);
    }

    public void GetIsTalkEnd() {
        memory.GetComponent<InMemoryVariableStorage>().TryGetValue<bool>("$isTalkEnd", out isTalkEnd);
    }
}