using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instnace;

    public float moveSpeed;         //이동속도
    public float rotationSpeed;     //회전속도

    public Animator anim;                 //애니메이션 설정

    private void Awake()
    {
        instnace = this;            //시작하자마자 인스턴스
    }
    void Start()
    {
        //moveSpeed = PlayerController.instance.moveSpeed[0].value              //TODO : 나중에 코딩
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
