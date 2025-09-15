using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueDat
{
    public int id;
    public string type;
    public string text;
    public int imageIndex;
}

[System.Serializable]
public class DialogueDatbase
{
    public List<DialogueDat> dialogues;
}

public delegate void HandleMessage(int ID, params string[] pa);

public partial class NPC1 : MonoBehaviour
{
    public HandleMessage handleMessage;
    //[SerializeField] public StoryLineManager storyLineManager;  现在不需要将故事线放进来
    public string JsonFileName = "JsonModel1";

    public int ID = 1;
    public string Name = "Tom";
    // Start is called before the first frame update
    void Start()
    {
       // handleMessage += storyLineManager.HandleMessage;
        ///////
        ///
        LoadData(JsonFileName); // 无.json后缀
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            speaksomething();
        }
    }

    // Bear新加，当进入触发范围时调用speaksomething
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            speaksomething();
        }
    }

    void speaksomething()
    {
        conver(ID);
        handleMessage?.Invoke(ID,Name);
    }

    public void UpdateID(int id)
    {
        ID = id;
    }
}


public partial class NPC1 : MonoBehaviour
{
    public DialogueDatbase database;
    public void LoadData(string str)
    {
        TextAsset jsonFile = Resources.Load<TextAsset>(str);
        if (jsonFile == null)
        {
            Debug.LogError("JSON文件未找到: " + str);
            return;
        }

        database = JsonUtility.FromJson<DialogueDatbase>(jsonFile.text);
        
    }

    public void conver(int id)
    {
        if (database == null || database.dialogues == null)
        {
            Debug.LogError("Dialogue database is not loaded or is empty.");
            return;
        }

        foreach (DialogueDat db in database.dialogues)
        {
            if (db.id == id)
            {
                Debug.Log($"NPC {Name} (ID: {ID}) says: {db.text}");
                break;
            }
        }
    }

}
