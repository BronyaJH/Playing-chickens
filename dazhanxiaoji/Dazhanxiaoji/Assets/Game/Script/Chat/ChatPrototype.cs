using UnityEngine;

[CreateAssetMenu]
public class ChatPrototype : ScriptableObject
{
    public string content;
    public string soundName;

    public string characterId;
    public ChatSpecialAction chatSpecialAction;

    public ChatPrototype next;
    public enum ChatSpecialAction
    {
        None,

    }
}