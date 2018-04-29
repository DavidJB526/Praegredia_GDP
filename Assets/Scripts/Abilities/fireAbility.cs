using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireAbility : MonoBehaviour {

    [SerializeField]
    Transform fireTransform;
    [SerializeField]
    float force;
    [SerializeField]
    float lifeTime = 2f;
    [SerializeField]
    Rigidbody fireball;

    private Animator anim;

    [SerializeField]
    int coolDownTime = 2;

    bool cooldown = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update ()
    {
		if(Input.GetButtonDown("Fire2") && cooldown)
        {
            anim.SetBool("ability", true);
            //Shoot();
            cooldown = false;
            StartCoroutine(AbilityAnimation());
            StartCoroutine(Cooldown());
        }
	}

    private void Shoot()
    {
        Rigidbody fireInstance = Instantiate(fireball, fireTransform.position, fireTransform.rotation) as Rigidbody;
        fireInstance.velocity = force * fireTransform.right;
        Destroy(fireInstance, lifeTime);
        
    }

    IEnumerator AbilityAnimation()
    {
        yield return new WaitForSeconds(1.1f);
        anim.SetBool("ability", false);

    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(coolDownTime);
        cooldown = true;
        
    }
}
