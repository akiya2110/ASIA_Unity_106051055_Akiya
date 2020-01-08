using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elf : MonoBehaviour
{
    private void Update()

    {
        Turn();
        Run();
        Take();
    }
    public Rigidbody rigcatch;


    private void OnTriggerStay(Collider other)
    {
        if (other.name == "elf pet" && (ani.GetCurrentAnimatorStateInfo(0).IsName("attack")))
        {
            Physics.IgnoreCollision(other, GetComponent<Collider>());
            other.GetComponent<HingeJoint>().connectedBody = rigcatch;
        }
        if (other.name == "沙子" && (ani.GetCurrentAnimatorStateInfo(0).IsName("attack")))
        {
            GameObject.Find("elf pet").GetComponent<HingeJoint>().connectedBody = null;
        }
    }


    #region 區域
    [Header("G8speed")]
    [Range(1, 500)]
    public int speed = 10;                   // 整數
    [Tooltip("Elf's rotation speed")]
    [Range(1f, 750f)]
    public float turn = 20.5f;               // 浮點數
    public string Name = "Elf";        // 字串
    #endregion
    public Transform tran;
    public Rigidbody rig;
    public Animator ani;



    private void Run()
    {
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("attack")) return;
        float v = Input.GetAxis("Vertical");
        rig.AddForce(tran.forward * speed * v * Time.deltaTime);
        ani.SetBool("run", v != 0);
    }
    private void Turn()
    {
        float f = Input.GetAxis("Horizontal");
        tran.Rotate(0, turn * f * Time.deltaTime, 0);
    }


    private void Take()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            ani.SetTrigger("attack");
    }
    private void Task()
    { }
}