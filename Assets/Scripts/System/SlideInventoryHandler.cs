using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlideInventoryHandler : MonoBehaviour
{
    private GameObject storageAra;


    private void Awake()
    {
        storageAra = GameObject.Find("StorageArea");
    }
    // Update is called once per frame
    void Update()
    {

    }


}