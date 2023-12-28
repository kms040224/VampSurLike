using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instnace;

    public float moveSpeed;         //�̵��ӵ�
    public float rotationSpeed;     //ȸ���ӵ�

    public Animator anim;                 //�ִϸ��̼� ����

    private void Awake()
    {
        instnace = this;            //�������ڸ��� �ν��Ͻ�
    }
    void Start()
    {
        //moveSpeed = PlayerController.instance.moveSpeed[0].value              //TODO : ���߿� �ڵ�
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveInput = new Vector3(0f, 0f, 0f);

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.z = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        if(moveInput != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveInput);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        transform.position += moveInput * moveSpeed * Time.deltaTime;

        if(moveInput != Vector3.zero)
        {
            anim.SetBool("IsMoving", true);
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }
    }
}
