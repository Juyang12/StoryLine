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


}