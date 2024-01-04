using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Rigidbody theRb;
    public float moveSpeed;
    private Transform target;

    public float damage;

    public float hitWaitTime = 1f;
    private float hitCounter;

    public float health = 5f;

    public float KnockBackTime = 0.5f;
    public float KnockBackCounter;

    public int coinValue = 1;
    public float coinDropRate = 0.5f;

    public int expToGive;

    private Transform player;



    // Start is called before the first frame update
    void Start()
    {
        player = PlayerController.instnace.transform;
        target = player;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.gameObject.activeSelf == true)
        {
            if(KnockBackCounter > 0)
            {
                KnockBackCounter -= Time.deltaTime;

                if(moveSpeed > 0)
                {
                    moveSpeed = -moveSpeed * 2f;
                }

                if(KnockBackCounter < 0)
                {
                    moveSpeed = Mathf.Abs(moveSpeed * 0.5f);
                }
            }

            if(Vector3.Distance(target.position, transform.position) > 1.0f)
            {
                theRb.velocity = (target.position - transform.position).normalized * moveSpeed;
            }

            if(hitCounter > 0f)
            {
                hitCounter -= Time.deltaTime;
            }
        }

        else
        {
            theRb.velocity = Vector3.zero;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && hitCounter <=0f)
        {
            //PlayerHealthController.instanse.TakeDamage(damage);
            hitCounter = hitWaitTime;
        }
    }
    public void TakeDamage(float damageToTake)
    {
        health -= damage;

        if(health <= 0)
        {
            Destroy(gameObject);
            //TODO ExpierienxeLevelController 구현
        }
        else
        {
            //TODO SFXManager
        }

        //TODO DamageNumberController 구현
    }

    public void TakeDamage(float damageToTake, bool shouldKnockBack)
    {
        TakeDamage(damageToTake);

        if(shouldKnockBack == true)
        {
            KnockBackCounter = KnockBackTime;
        }
    }
}
