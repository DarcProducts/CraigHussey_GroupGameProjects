using Unity.VisualScripting;
using UnityEngine;

public sealed class ItemNameGenerator : MonoBehaviour
{
    public static ItemNameGenerator Instance { get; private set; }
    [SerializeField] TextAsset nouns, adjectives, potionEffects;
    [SerializeField] Color nameColor, statColor, stateNameColor;
    [SerializeField] float statTextSize = 2;
    [SerializeField] float smallStatTextSize = 1;

    private void Awake()
    {
        Instance = this;
    }

    public string CreateItemName(ItemType type)
    {
        string adj = GetAdjective().FirstCharacterToUpper();
        string noun = GetNoun().FirstCharacterToUpper();
        string newItemName = string.Empty;
        string stats = string.Empty;
        switch (type)
        {
            case ItemType.Sword:
            case ItemType.Dagger:
            case ItemType.Bow:
                newItemName = $"<color=#{UnityEngine.ColorUtility.ToHtmlStringRGBA(nameColor)}>{adj} {type} of The {noun}</color>";
                stats = $"<color=#{UnityEngine.ColorUtility.ToHtmlStringRGBA(stateNameColor)}><size={statTextSize}>Damage:</color> <color=#{UnityEngine.ColorUtility.ToHtmlStringRGBA(statColor)}>{Random.Range(1, 100)}</color>\n<color=#{UnityEngine.ColorUtility.ToHtmlStringRGBA(stateNameColor)}>Attack Rate:</color>\n<color=#{UnityEngine.ColorUtility.ToHtmlStringRGBA(statColor)}>{Random.Range(0f, 100f)}</color>\n<color=#{UnityEngine.ColorUtility.ToHtmlStringRGBA(stateNameColor)}>Bonus DMG:</color><color=#{UnityEngine.ColorUtility.ToHtmlStringRGBA(statColor)}>{GetNoun()}'s</color></size>";
                break;
            case ItemType.Shield:
                newItemName = $"<color=#{UnityEngine.ColorUtility.ToHtmlStringRGBA(nameColor)}>{adj} {type} of {GetNoun().FirstCharacterToUpper()} reflection</color>";
                stats = $"<color=#{UnityEngine.ColorUtility.ToHtmlStringRGBA(stateNameColor)}><size={statTextSize}>\nArmor: </color><color=#{UnityEngine.ColorUtility.ToHtmlStringRGBA(statColor)}>{Random.Range(1, 26)}</color><color=#{UnityEngine.ColorUtility.ToHtmlStringRGBA(stateNameColor)}>\nWeak Against:</color><color=#{UnityEngine.ColorUtility.ToHtmlStringRGBA(statColor)}> {GetNoun()}'s</color></size>";
                break;
            case ItemType.Bracelet:
            case ItemType.Necklace:
                string anotherAdj = GetAdjective().FirstCharacterToUpper();
                newItemName = $"<color=#{UnityEngine.ColorUtility.ToHtmlStringRGBA(nameColor)}>{adj} {type} of {anotherAdj} {noun}'s</color>";
                stats = $"<color=#{UnityEngine.ColorUtility.ToHtmlStringRGBA(stateNameColor)}><size={smallStatTextSize}>\nStrength: </color><color=#{UnityEngine.ColorUtility.ToHtmlStringRGBA(statColor)}>{Random.Range(1, 10)}</color>\t<color=#{UnityEngine.ColorUtility.ToHtmlStringRGBA(stateNameColor)}>Agility: </color><color=#{UnityEngine.ColorUtility.ToHtmlStringRGBA(statColor)}>{Random.Range(1, 10)}</color>\n<color=#{UnityEngine.ColorUtility.ToHtmlStringRGBA(stateNameColor)}>Dexterity: </color><color=#{UnityEngine.ColorUtility.ToHtmlStringRGBA(statColor)}>{Random.Range(1, 10)}</color>\t<color=#{UnityEngine.ColorUtility.ToHtmlStringRGBA(stateNameColor)}>Wisdom: </color><color=#{UnityEngine.ColorUtility.ToHtmlStringRGBA(statColor)}>{Random.Range(1, 10)}</color>\t<color=#{UnityEngine.ColorUtility.ToHtmlStringRGBA(stateNameColor)}>Intelligence: </color><color=#{UnityEngine.ColorUtility.ToHtmlStringRGBA(statColor)}>{Random.Range(1, 10)}</color>\t<color=#{UnityEngine.ColorUtility.ToHtmlStringRGBA(stateNameColor)}>Charisma: </color><color=#{UnityEngine.ColorUtility.ToHtmlStringRGBA(statColor)}>{Random.Range(1, 10)}</color></size>";
                break;
            case ItemType.Potion:
                newItemName = $"<color=#{UnityEngine.ColorUtility.ToHtmlStringRGBA(nameColor)}>Strange Potion</color>\n";
                stats = $"<color=#{UnityEngine.ColorUtility.ToHtmlStringRGBA(stateNameColor)}>Effects:</color> \n<color=#{UnityEngine.ColorUtility.ToHtmlStringRGBA(statColor)}>{GetPotionEffect()} {adj} {noun}'s</color>";
                break;
        }
        newItemName += $"\n{stats}";
        return newItemName;
    }

    string GetNoun()
    {
        string[] noun = nouns.text.Replace("\r", "").Split("\n");
        int ranNoun = Random.Range(0, noun.Length);
        return noun[ranNoun].Trim();
    }

    string GetAdjective()
    {
        string[] adjective = adjectives.text.Replace("\r", "").Split("\n");
        int ranAdjective = Random.Range(0, adjective.Length);
        return adjective[ranAdjective].Trim();
    }

    string GetPotionEffect()
    {
        string[] effects = potionEffects.text.Replace("\r", "").Split("\n");
        int ranEffect = Random.Range(0, effects.Length);
        return effects[ranEffect].Trim();
    }
}
