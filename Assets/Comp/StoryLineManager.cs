using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryLineManager : MonoBehaviour
{

    [SerializeField]
    public List<Story.Event> StoryLine;
    /*
     * 声明委托,拷贝到订阅类中使用
     public delegate void HandleMessage(int ID,params int[] pa);
    */


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleMessage(int ID, params int[] pa)
    {
        if(StoryLine[0].CheckID(ID))
        {
            StoryLine[0].OnBeenPoped();
            StoryLine.RemoveAt(0);
        }
    }

    public StoryLineManager GetInstance()
    {
        return this;
    }
}
