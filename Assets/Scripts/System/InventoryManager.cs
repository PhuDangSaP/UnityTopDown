using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public List<Item> items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        OpenInventory();
    }

    public void Add(Item item)
    {
        items.Add(item);
    }
    public void Remove(Item item)
    {
        items.Remove(item);
    }
    public void ListItem()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("Name").GetComponent<Text>();
            var itemCategory = obj.transform.Find("Category").GetComponent<Text>();
            var itemIcon = obj.transform.Find("Icon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemCategory.text = item.type.ToString();
            itemIcon.sprite = item.icon;
        }
    }
    void OpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            foreach (Transform child in InventoryManager.instance.transform)
            {
                child.gameObject.SetActive(true);
            }
        }
    }
}
