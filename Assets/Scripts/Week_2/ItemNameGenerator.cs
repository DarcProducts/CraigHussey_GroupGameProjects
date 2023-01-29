using Unity.VisualScripting;
using UnityEngine;

public class ItemNameGenerator : MonoBehaviour
{
    public static ItemNameGenerator Instance { get; private set; }
    [SerializeField] TextAsset nouns, adjectives, adverbs;

    private void Awake()
    {
        Instance = this;
    }

    public string CreateItemName(ItemType type)
    {
        string newItemName = $"{GetAdjective().FirstCharacterToUpper()}\n{type} of The\n{GetNoun()}";
        return newItemName;
    }

    string GetNoun()
    {
        string[] noun = nouns.text.Trim().Split("\n");
        int ranNoun = Random.Range(0, noun.Length);
        return noun[ranNoun];
    }

    string GetAdjective()
    {
        string[] adjective = adjectives.text.Trim().Split("\n");
        int ranAdjective = Random.Range(0, adjective.Length);
        return adjective[ranAdjective];
    }
}
