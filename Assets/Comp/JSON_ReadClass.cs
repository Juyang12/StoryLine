using System;
using System.Collections.Generic;

[Serializable]
public class DialogueData
{
    public int id;
    public string type; // dialogue/description/plot
    public string text;
    public int imageIndex;
}

[Serializable]
public class DialogueDatabase
{
    public List<DialogueData> dialogues;
}