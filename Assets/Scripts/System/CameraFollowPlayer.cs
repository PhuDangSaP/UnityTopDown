using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private Vector3 cameraTarget;
    private Transform target;
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
    }
    private void Update()
    {
        cameraTarget=new Vector3(target.position.x,transform.position.y,target.position.z);
        transform.position = Vector3.Lerp(transform.position,cameraTarget,Time.deltaTime*8);
    }


}
