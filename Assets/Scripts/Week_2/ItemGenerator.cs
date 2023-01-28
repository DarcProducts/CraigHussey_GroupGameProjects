using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Sword,
    Dagger,
    Bow,
    Shield,
    Bracelet,
    Necklace,
    Potion
}

public class ItemGenerator : MonoBehaviour
{
    [SerializeField] Transform launchTransform;
    [SerializeField] float velocityMultiplier;
    [SerializeField] GameObject sword, dagger, bow, shield, bracelet, necklace, potion;
    readonly List<GameObject> _createdItems = new();

    public void GenerateNewItem()
    {
        GameObject[] items = { sword, dagger, bow, shield, bracelet, necklace, potion };
        int ranItem = Random.Range(0, items.Length);
        Vector3 ranEuler = new Vector3(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180));
        GameObject item = Instantiate(items[ranItem], launchTransform.position, Quaternion.Euler(ranEuler), transform);
        if (item.TryGetComponent(out Rigidbody rigid))
            rigid.velocity = ((Vector3.up * 10) + Random.onUnitSphere).normalized * velocityMultiplier;
        _createdItems.Add(item);
    }

    public void RemoveItems() => StartCoroutine(RemoveAllItems());

    IEnumerator RemoveAllItems()
    {
        if (_createdItems.Count == 0) yield return null;
        for (int i = 0; i < _createdItems.Count; i++)
            DestroyImmediate(_createdItems[i]);
        _createdItems.Clear();
    }
}
