using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public int itrId;
    public int itrActionIndex;
    Dictionary<int, DataofInteraction> itrList;

    void Awake()
    {
        itrList = new Dictionary<int, DataofInteraction>();
        GenerateData();
    }

    void GenerateData()
    {
        itrList.Add(10, new DataofInteraction("�� �ɱ�", new int[] { 2000, 1000, 2000 }));
        //itrList.Add(20, new DataofInteraction("�� �ɱ�2", new int[] { 2000 }));
    }

    public int GetItrIndex(int id)
    {
        return itrId + itrActionIndex;
    }

    public void CheckItr(int id)
    {
        if (id == itrList[itrId].objId[itrActionIndex]) //��ȣ�ۿ� ���� ���߱�
            itrActionIndex++;

        if (itrActionIndex == itrList[itrId].objId.Length)
            AnotherItr();
    }

    void AnotherItr()
    {
        //itrId -= (itrId % 1000);
        itrActionIndex = 0;
    }
}