//COLISÃO DE ATAQUE DO KEEPER

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeeperAttackCollider : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Character>().PlayerDamage(1); 
        }
    }
}

// CONTROLER DO KEEPER
// COMO FUNCIONA

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeeperController : MonoBehaviour
{
    public Transform a;
    public Transform b;

    public AudioSource audioSource;
    public AudioClip dieSound;

    public Transform skin;
    public Transform keeeperRange;

    public bool goRigth;

    void Start()
    {
        
    }


    void Update()
    {
        if (GetComponent<Character>().life <= 0)
        {
            audioSource.PlayOneShot(dieSound);
            keeeperRange.GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
            this.enabled = false;
        }


        if (skin.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("KeeeperAttack"))
        {
            return;
        }


        if(goRigth == true)
        {
            skin.localScale = new Vector3(1, 1, 1);

            if (Vector2.Distance(transform.position, b.position) < 0.1f)
            {
                goRigth = false;
            }
            transform.position = Vector2.MoveTowards(transform.position, b.position, 2.0f * Time.deltaTime);
        }
       else
        {
            skin.localScale = new Vector3(-1, 1, 1);

            if (Vector2.Distance(transform.position, a.position) < 0.1f)
            {
                goRigth = true;
            }
            transform.position = Vector2.MoveTowards(transform.position, a.position, 2.0f * Time.deltaTime);
        }
    }
}


// ALANCE DE ATAQUE E VISÃO DO KEEPER

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeeperRange : MonoBehaviour
{
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            transform.parent.GetComponent<Animator>().Play("KeeeperAttack", -1);
        }
    }
}

//SOM DO KEEPER

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperEvent : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip attackSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KeeperAttackSound()
    {
        audioSource.PlayOneShot(attackSound);
    }
}

