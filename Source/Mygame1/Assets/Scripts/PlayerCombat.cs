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
	public int knockback = 1;
	public float attackRate = 2f;
	float nextAttackTime = 0f;
	
    // Start is called before the first frame update
    void Start()
    {
        
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
		
		
		
		
	
		
		
		
	
	
	
}
