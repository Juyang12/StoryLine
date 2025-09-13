using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NPC1 : MonoBehaviour
{
    public event System.Action<int> handleMessage;
    [SerializeField] public StoryLineManager storyLineManager;

    int ID = 1;
    // Start is called before the first frame update
    void Start()
    {
        handleMessage += storyLineManager.HandleMessage;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            speaksomething();
        }
    }

    void speaksomething()
    {
        Debug.Log("Hello, I am NPC1");
        handleMessage?.Invoke(ID);
    }
}
