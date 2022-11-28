using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventableObjects
{
    public Dictionary<int, string> eventableObject { get; private set; }
    public Dictionary<int, string> weekSkipObject { get; private set; }
    public List<int> weekSkipObjectId { get; private set; }
    // Start is called before the first frame update
    public EventableObjects()
    {
        weekSkipObject = new Dictionary<int, string>();
        weekSkipObjectId = new List<int>();
        AddWeekSkipObject();

        eventableObject = new Dictionary<int, string>();
        AddEventableObject();
    }

    void AddWeekSkipObject()
    {
        weekSkipObject.Add(-1, "bed");
        weekSkipObject.Add(3000, "professor");

        foreach (int key in weekSkipObject.Keys)
        {
            weekSkipObjectId.Add(key);
        }
    }

    void AddEventableObject()
    {
        eventableObject.Add(-1, "bed");
        eventableObject.Add(1000, "girl");
        eventableObject.Add(2000, "gem");
        eventableObject.Add(3000, "professor");
    }

    public bool IsInSkipObject(int objectID) {
        return weekSkipObjectId.Contains(objectID);
    }
}
