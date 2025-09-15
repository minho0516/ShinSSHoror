using Unity.VisualScripting;
using UnityEngine;

public class Dragun : MonoBehaviour
{
    Rigidbody ri;
    Animator animer;

    [SerializeField] GameObject target;
    [SerializeField] float dragunSpeed;
    bool findRay;
    bool canAttack = true;

    [SerializeField] private GameObject thingOfAttack;

    private void Start()
    {
        animer = GetComponent<Animator>();
        ri = GetComponent<Rigidbody>();
        target = GameObject.Find("Player");
    }

    void Update()
    {
        RayToPlayer();
        if (findRay == true)
        {
            FaceToPlayer();
            //Attack();
        }
        if (findRay == false)
        {
            FaceToPlayer();
            //moving();
        }
    }

    void FaceToPlayer()
    {
        Vector3 dir = target.transform.position - transform.position; dir.y = 0f;

        Quaternion rot = Quaternion.LookRotation(dir.normalized);

        transform.rotation = rot;
    }
    void RayToPlayer()
    {
        Vector3 dir = target.transform.position - transform.position; dir.y = 0f;
        findRay = Physics.Raycast(ri.position, dir.normalized, 10, LayerMask.GetMask("Player"));
        Debug.DrawRay(ri.position, dir.normalized * 10, Color.red);
    }

    void moving()
    {
        animer.SetBool("attack", false);
        Vector3 vel = transform.forward * dragunSpeed;
        vel.y = ri.linearVelocity.y;
        ri.linearVelocity = vel;
        int ran = Random.Range(0, 4000);
        if (ran == 5)
        {
            //S_OHoOHo();//확률에 따른 소리재생
        }
    }

    void Attack()
    {
        if (canAttack == true)
        {
            animer.SetBool("attack", true);
            Instantiate(thingOfAttack, this.transform.position, this.transform.rotation);
            canAttack = false;
            Invoke("Anime", 0.6f);
        }
    }
    void Anime()
    {
        animer.SetBool("attack", false);
        canAttack = true;
    }
}
