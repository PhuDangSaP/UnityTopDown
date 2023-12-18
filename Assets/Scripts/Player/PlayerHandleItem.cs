
using UnityEngine;
using UnityEngine.UI;



public class PlayerHandleItem : MonoBehaviour
{
    public float pickUpDistance = 10f;
    [SerializeField] private GameObject prefabToInstantiate;
    private GameObject interactItem;
    private GameObject obj;
    private Button lootButton;
    private Button wearButton;

    private void Awake()
    {
        interactItem = FindAnyObjectByType<Canvas>().transform.Find("InteractItem").gameObject;
        lootButton = interactItem.transform.Find("Loot").gameObject.GetComponent<Button>();
        lootButton.onClick.AddListener(() => PickUpItem());
        wearButton = interactItem.transform.Find("Wear").gameObject.GetComponent<Button>();
        wearButton.onClick.AddListener(() => WearItem());
    }
    void Update()
    {
        FocusOnItem();
    }

    void FocusOnItem()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                if (raycastHit.transform.tag == "Item")
                {
                    obj = raycastHit.transform.gameObject;
                    interactItem.transform.position = Input.mousePosition;
                    interactItem.SetActive(true);
                }
                else
                {
                    interactItem.SetActive(false);
                }
            }
        }
    }
    void PickUpItem()
    {
        if ((obj.transform.position - transform.position).magnitude <= pickUpDistance)
        {
            InventoryManager.instance.Add(obj.GetComponent<ItemController>().item);
            Destroy(obj);
            InventoryManager.instance.ListItem();
            interactItem.SetActive(false);
        }
    }
    void WearItem()
    {

        if ((obj.transform.position - transform.position).magnitude <= pickUpDistance)
        {
            if (obj.GetComponent<ItemController>().item.type == ItemType.Weapon)
            {
                if (obj.GetComponent<WeaponHandler>().weaponType == WeaponType.ONEHANDMELEE || true)
                {
                    Transform weapon = GameObject.FindGameObjectWithTag("Player").transform.Find("Armature/Root_M/Spine1_M/Spine2_M/Chest_M/Scapula_R/Shoulder_R/Elbow_R/Wrist_R/Weapon").transform;
                    if (weapon.childCount == 0)
                    {
                        obj.transform.SetParent(weapon);
                        obj.transform.localPosition = Vector3.zero;

                        InventoryManager.instance.Add(obj.GetComponent<ItemController>().item);
                    }
                }
            }

            InventoryManager.instance.ListItem();
            interactItem.SetActive(false);
        }



    }
}
