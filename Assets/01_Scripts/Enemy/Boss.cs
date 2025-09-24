using NUnit.Framework;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using System.Collections.Generic;
using static UnityEditor.PlayerSettings;
using System.Collections;

public class Boss : MonoBehaviour
{
    Rigidbody ri;
    [SerializeField] Animator animer;

    [SerializeField] GameObject player;
    [SerializeField] float bossSpeed;
    public int bossHp;

    bool canMove = false;
    bool alwaysFacePlayer = false;
    public bool canHit = false;

    [SerializeField] GameObject bigBall;

    [SerializeField] List<Transform> dirs;

    [SerializeField] Transform pos;

    private void Start()
    {
        ri= GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        StartCoroutine(Battle());
    }

    void Update()
    {
        //panByeol_HP();
        Moving();
        FaceToPlayer();
    }

    void Moving()
    {
        if (canMove == true)
        {
            Vector3 vel = transform.forward / 1.2f * bossSpeed;
            vel.y = ri.linearVelocity.y;
            ri.linearVelocity = vel;
        }
    }

    void FaceToPlayer()
    {
        if (alwaysFacePlayer == true) {
            Vector3 dir = player.transform.position - transform.position; dir.y = 0f;

            Quaternion rot = Quaternion.LookRotation(dir.normalized);

            // 방향 돌리기 
            transform.rotation = rot;
        }    
    }

    void FaceToRandom()
    {
        int ran = Random.Range(0, 8);
        Vector3 dir = dirs[ran].transform.position - transform.position; dir.y = 0f;

        Quaternion rot = Quaternion.LookRotation(dir.normalized);

        // 방향 돌리기 
        transform.rotation = rot;
    }

    //전투
    IEnumerator Battle()
    {
        while (true)
        {
            ri.linearVelocity = ri.linearVelocity;
            animeOFF();
            canMove = true;
            aWalk();
            yield return new WaitForSeconds(1.5f);
            alwaysFacePlayer = true;
            alwaysFacePlayer = false;
            yield return new WaitForSeconds(1.5f);
            alwaysFacePlayer = true;
            alwaysFacePlayer = false;
            yield return new WaitForSeconds(1.5f);

            canMove = false;
            aAttack1();
            Instantiate(bigBall, pos.transform.position, pos.transform.rotation);
            yield return new WaitForSeconds(0.7f);
            Instantiate(bigBall, pos.transform.position, pos.transform.rotation);
            yield return new WaitForSeconds(0.7f);
            Instantiate(bigBall, pos.transform.position, pos.transform.rotation);

            canMove = true;
            aWalk();
            yield return new WaitForSeconds(1.5f);
            alwaysFacePlayer = true;
            alwaysFacePlayer = false;
            yield return new WaitForSeconds(1.5f);
            alwaysFacePlayer = true;
            alwaysFacePlayer = false;
            yield return new WaitForSeconds(1.5f);

            
            Up();
            yield return new WaitForSeconds(3);
            aAttack2();
            Down();
            yield return new WaitForSeconds(1);

            canMove = true;
            aWalk();
            yield return new WaitForSeconds(1.5f);
            FaceToRandom();
            yield return new WaitForSeconds(1.5f);
            FaceToRandom();
            yield return new WaitForSeconds(1.5f);
            FaceToRandom();
            yield return new WaitForSeconds(1.5f);
            FaceToRandom();
            yield return new WaitForSeconds(1.5f);

        }
    }

    void Up()
    {
        ri.AddForce(Vector3.up * 200);
    }
    void Down()
    {
        ri.AddForce(Vector3.down * 200);
    }

    //애니메이션
    void animeOFF()
    {
        animer.SetBool("Walk", false);
        animer.SetBool("Attack1", false);
        animer.SetBool("Attack2", false);
        animer.SetBool("Die", false);
    }

    void aWalk()
    {
        FaceToPlayer();
        animeOFF();
        animer.SetBool("Walk", true);
    }

    void aAttack1()
    {
        FaceToPlayer();
        animeOFF();
        animer.SetBool("Attack1", true);
    }

    void aAttack2()
    {
        FaceToPlayer();
        animeOFF();
        animer.SetBool("Attack2", true);
    }

    void aDie()
    {
        animeOFF();
        animer.SetBool("Die", true);
    }

}
