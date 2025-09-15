using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//处理与其他实例交互的逻辑
public partial class StoryLineManager : MonoBehaviour
{
    private void AnswerRequest()//用于回答请求
    {
        foreach (var request in RequestList)
        {
            foreach (var npc in npcs)
            {
                if (npc.Name == request.Name)
                {
                    npc.UpdateID(request.ID);
                }
            }
        }
    }

    public void HandleMessage(int ID, params string[] pa)
    {
        if (StoryLine.Count == 0) return;
        if (StoryLine[0].CheckID(ID, pa[0]))
        {
            StoryLine[0].OnBeenPoped();
            StoryLine.RemoveAt(0);
            if (StoryLine.Count == 0) return;//索引检测
            RequestList = StoryLine[0].OnFront();
            AnswerRequest();
        }
    }

    public StoryLineManager GetInstance()
    {
        return this;
    }

}