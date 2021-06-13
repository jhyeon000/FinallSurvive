using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animal : MonoBehaviour
{

    [SerializeField] protected string animalName; // ������ �̸�
    [SerializeField] protected int hp; // ������ ü��.

    [SerializeField] protected float walkSpeed; // �ȱ� ���ǵ�.
    [SerializeField] protected float runSpeed; // �ٱ� ���ǵ�.
    [SerializeField] protected float chaseSpeed; //�i�� ���ǵ�
    //[SerializeField] protected float turningSpeed;
    //protected float applySpeed;

    protected Vector3 destination; // ������.


    // ���º���
    protected bool isAction; // �ൿ������ �ƴ��� �Ǻ�.
    protected bool isWalking; // �ȴ��� �� �ȴ��� �Ǻ�.
    protected bool isRunning; // �ٴ��� �Ǻ�.
    protected bool isDead; // �׾����� �Ǻ�.

    [SerializeField] protected float walkTime; // �ȱ� �ð�
    [SerializeField] protected float waitTime; // ��� �ð�.
    [SerializeField] protected float runTime; // �ٱ� �ð�.
     protected float currentTime;


    // �ʿ��� ������Ʈ
    [SerializeField] protected Animator anim;
    [SerializeField] protected Rigidbody rigid;
    [SerializeField] protected BoxCollider boxCol;
    protected AudioSource theAudio;
    protected NavMeshAgent nav;

    [SerializeField] protected AudioClip[] sound_Normal;
    [SerializeField] protected AudioClip sound_Hurt;
    [SerializeField] protected AudioClip sound_Dead;

    [SerializeField] protected GameObject go_meat_item_prefab; //��� ������

    protected StatusController thePlayerStatus;

    // Use this for initialization
	protected void Start () 
    {
        nav = GetComponent<NavMeshAgent>();
        theAudio = GetComponent<AudioSource>();
        currentTime = waitTime;
        isAction = true;
        thePlayerStatus = FindObjectOfType<StatusController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!isDead)
        {
            Move();
           
            ElapseTime();
        }
    }

    protected void Move()
    {
        if (isWalking || isRunning)
            //rigid.MovePosition(transform.position + (transform.forward * applySpeed * Time.deltaTime));
            nav.SetDestination(transform.position + destination * 5f);
    }

 

    protected void ElapseTime()
    {
        if (isAction)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
                ReSet();
        }
    }

    protected virtual void ReSet()
    {
        isWalking = false; isRunning = false; isAction = true;
        nav.speed = walkSpeed;
        nav.ResetPath();
        anim.SetBool("Walking", isWalking); anim.SetBool("Running", isRunning);
        destination.Set(Random.Range(-0.2f, 0.2f), 0f, Random.Range(0.5f, 1f));
    }

    

    
    protected void TryWalk()
    {
        isWalking = true;
        anim.SetBool("Walking", isWalking);
        currentTime = walkTime;
        nav.speed = walkSpeed;
        Debug.Log("�ȱ�");
    }

    public virtual void Damage(int _dmg, Vector3 _targetPos)
    {
        if (!isDead)
        {
            hp -= _dmg;

            if (hp <= 0)
            {
                Dead();
                return;
            }

            PlaySE(sound_Hurt);
            anim.SetTrigger("Hurt");
        }
    }

    protected void Dead()
    {
        PlaySE(sound_Dead);
        isWalking = false;
        isRunning = false;
        isDead = true;
        anim.SetTrigger("Dead");

        Instantiate(go_meat_item_prefab, this.transform.position, Quaternion.identity);

    }

    protected void RandomSound()
    {
        int _random = Random.Range(0, 3); // �ϻ� ���� 3��.
        PlaySE(sound_Normal[_random]);
    }

    protected void PlaySE(AudioClip _clip)
    {
        theAudio.clip = _clip;
        theAudio.Play();
    }
}
