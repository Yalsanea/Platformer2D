using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
	
	public Animator animator;
	
	public Transform attackPoint;
	public float attackRange = 0.5f;
	public LayerMask enemyLayers;
	public int attackDamage = 2;
	public float attackRate = 2f;
	public int playerHealth = 10;
	public float knockbackForce;
	private Rigidbody2D rb;
	public int currentHealth;
	
	float nextAttackTime = 0f;
	
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = playerHealth;
		rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime){
		if (Input.GetKeyDown("z")){
			
			Attack();
			nextAttackTime = Time.time +1f/attackRate;
		}
		}
		}
    
	
	
	void Attack()
	{
		// play attack animation
		animator.SetTrigger("Attack");
		
		//detect enemies in range of attack
		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
		
		//damage
		foreach(Collider2D enemy in hitEnemies){
			Debug.Log("hit" + enemy.name);
			enemy.GetComponent<EnemyMechanics>().TakeDamage(attackDamage,attackPoint.position);
			
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
		
		
		
		public  void TakeDamage(int damage, Vector3 attackPos)
{
	currentHealth -= damage;
	
	//damage animation
	animator.SetTrigger("Hurt");
	
	//knockback
	
	Vector3 knockbackDir =  transform.position - attackPos  ;
	Debug.Log("attackPos" + attackPos);
    Debug.Log("knockbackDir" + knockbackDir.normalized);
	
	//rb.isKinematic = false; 
	rb.AddForceAtPosition(knockbackDir.normalized * knockbackForce  ,attackPos,ForceMode2D.Impulse);
	Debug.Log("knockback");
	StartCoroutine(Wait());
	
	
	
	
	if(currentHealth <=0){
		Die();
		
	}
	
}
	
  IEnumerator Wait(){
	  yield return new WaitForSecondsRealtime(0.25f);
	 // rb.isKinematic = true;
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
