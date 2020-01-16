using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;



public class EnemyMechanics : MonoBehaviour
{
    // Start is called before the first frame update
    
	public int maxHealth  = 10;
	int currentHealth;
	public Animator animator;
    public bool Knockback = false;
	private Rigidbody2D rb;
	
	void Start()
    {
        currentHealth = maxHealth;
		if(Knockback == true){
			rb = GetComponent<Rigidbody2D>();
			
		}
	
    }
	
	

public  void TakeDamage(int damage, Vector3 attackPos)
{
	currentHealth -= damage;
	
	//damage animation
	animator.SetTrigger("Hurt");
	
	//knockback
	if (Knockback == true){
		
		//GetComponent<AIPath>().enabled = false;
	Vector3 knockbackDir = transform.position - attackPos;
	transform.Translate(knockbackDir * 2);
  
	//rb.MovePosition(knockbackDir*1000);

	Debug.Log("knockback");
	//GetComponent<AIPath>().enabled = true;
	
	}
	
	
	
	if(currentHealth <=0){
		Die();
		
	}
	
}

	void Die(){
		//death animation
		animator.SetBool("IsDead",true);
		Debug.Log("dead");
		
		//disable
		GetComponent<Collider2D>().enabled = false;
		this.enabled = false;
		Destroy(gameObject);
	 
	
		
	}

    
}
