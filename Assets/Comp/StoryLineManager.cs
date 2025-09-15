using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class StoryLineManager : MonoBehaviour
{

    public List<Story.Event> StoryLine;
    [SerializeField] private NPC1[] npcs;//npc表
    /*
     * 声明委托,拷贝到订阅类中使用
     public delegate void HandleMessage(int ID,params int[] pa);
    */


    /*
     * StoryLineManager是一个父类，任何使用应该使用子类
     * 子类应该包含所有与该故事线相关的npc
     * 假设玩家基类为Player，则：
     * [SerializeField] private Player[] npcs;
     * 
     * 对于Player，至少需要包含一个ID和一个Name
     * **************************\\\\\
     * 
     * public int ID;
     * Public string Name;
     * 
     * 
     * **************************\\\\\
     */
    private Story.EventDataSet[] RequestList;// 用于存储当前需要触发的事件ID
                                             //private void AnswerRequest(); 用于回答请求

    //public void HandleMessage(int ID, params int[] pa)   参数为ID和一个可变参数列表（非必须使用）；是订阅类的委托函数

    //public StoryLineManager GetInstance()获得故事线manager

    private void Start()
    {
        AutoMakeDelegate();
    }

}


