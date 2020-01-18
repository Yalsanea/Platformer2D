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
	public float knockbackForce;
	public Transform attackPoint;
	public float attackRange = 0.5f;
	public LayerMask enemyLayers;
	public int attackDamage = 2;
	public float attackRate = 1f;
	private Collider2D[] hitEnemies;
	float nextAttackTime = 0f;
	
	void Start()
    {
        currentHealth = maxHealth;
		if(Knockback == true){
			rb = GetComponent<Rigidbody2D>();
			
		}
	
    }
	
	
	void Update(){

	
		//detect enemies in range of attack
		Collider2D hitEnemy = Physics2D.OverlapCircle(attackPoint.position, attackRange, enemyLayers);
		if(hitEnemy != null){
			 if(Time.time >= nextAttackTime){
			Attack();
			nextAttackTime = Time.time +1f/attackRate;
			 }
		}

		
	}
	
	
	
	

public  void TakeDamage(int damage, Vector3 attackPos)
{
	currentHealth -= damage;
	
	//damage animation
	animator.SetTrigger("Hurt");
	
	//knockback
	if (Knockback == true){
		
    GetComponent<AIPath>().canMove = false;
	Vector3 knockbackDir =  transform.position - attackPos  ;
	rb.isKinematic = false; 
	rb.AddForceAtPosition(knockbackDir.normalized * knockbackForce  ,attackPos,ForceMode2D.Impulse);
	StartCoroutine(Wait());
	
	}
	
	
	
	if(currentHealth <=0){
		Die();
		
	}
	
}
	
  IEnumerator Wait(){
	  yield return new WaitForSecondsRealtime(0.25f);
	  GetComponent<AIPath>().canMove = true;
	  rb.isKinematic = true;
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
	
	
	void Attack()
	{
		// play attack animation
		//animator.SetTrigger("Attack");

		//damage
		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
		foreach(Collider2D enemy in hitEnemies){
			Debug.Log("hit" + enemy.name);
			enemy.GetComponent<PlayerCombat>().TakeDamage(attackDamage,attackPoint.position);
			
		}
	}
		
		void OnDrawGizmosSelected ()
		{      //draw wireframe of attack hit circle
			if(attackPoint == null){
			return;
			}
		
			Gizmos.color = Color.white;
			Gizmos.DrawWireSphere(attackPoint.position,attackRange);
			
		}
	

    
}
