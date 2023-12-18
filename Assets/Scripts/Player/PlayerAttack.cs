using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class PlayerAttack : MonoBehaviour
{
    private PlayerController playerController;
    private Animator animator;
    private Transform weapon;


    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        weapon = transform.Find("Armature/Root_M/Spine1_M/Spine2_M/Chest_M/Scapula_R/Shoulder_R/Elbow_R/Wrist_R/Weapon").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    void Attack()
    {
        if (playerController.isAiming)
        {
            if (weapon.childCount == 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    animator.SetInteger("WeaponType", (int)WeaponType.None);
                    animator.SetTrigger("Attack");
                }
            }
            else if (weapon.GetComponentInChildren<WeaponHandler>().fireType == FireType.SINGLE)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    animator.SetInteger("WeaponType", (int)weapon.GetComponentInChildren<WeaponHandler>().weaponType);
                    animator.SetTrigger("Attack");
                }
            }
            else if (weapon.GetComponentInChildren<WeaponHandler>().fireType == FireType.MULTIPLE)
            {
                if (Input.GetMouseButton(0))
                {
                    Debug.Log("ok");
                    animator.SetInteger("WeaponType", (int)weapon.GetComponentInChildren<WeaponHandler>().weaponType);
                    animator.SetBool("isFiring", true);
                }
                
                
            }           
        }
        if (Input.GetMouseButtonUp(0)||!playerController.isAiming)
        {
            animator.SetBool("isFiring", false);
        }
    }  

}
