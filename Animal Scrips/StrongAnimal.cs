using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongAnimal : Animal
{

    public void Chase(Vector3 _targetPos)
    {
        destination = _targetPos;

        currentTime = runTime;
        isWalking = false;
        isRunning = true;
        nav.speed = chaseSpeed;
        anim.SetBool("Running", isRunning);
    }

    public override void Damage(int _dmg, Vector3 _targetPos )
    {
        base.Damage(_dmg, _targetPos);
        if(!isDead)
            Chase(_targetPos);
         else   
            Dead();
	}

    //추가
    /*protected IEnumerator AttackCoroutine()
    {
        RaycastHit _hit;
        if(Physics.Raycast(transform.position  + Vector3.up, transform.forward, out _hit, attackDistance, targetMask))
        {
            Debug.Log("적중");
            thePlayerStatus.DecreaseHP(20);
		}
        else
        {
            Debug.Log("빗나감");  
		}
    }*/

    //OnENTER
    /*public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            thePlayerStatus.DecreaseHP(20);  
		}
        return;
	}*/
}
