using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataofInteraction
{
    public string itrName;
    public int[] objId; //해당 상호작용과 연관된 오브젝트
    public DataofInteraction(string name, int[] obj)
    {
        itrName = name;
        objId = obj;
    }
}
