using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataofInteraction
{
    public string itrName;
    public int[] objId; //�ش� ��ȣ�ۿ�� ������ ������Ʈ
    public DataofInteraction(string name, int[] obj)
    {
        itrName = name;
        objId = obj;
    }
}
