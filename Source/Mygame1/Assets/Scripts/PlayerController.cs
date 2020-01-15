using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
	
	public float speed;
	public float jumpSpeed;
	public Animator animator;
	private Rigidbody2D rb;
	private float moveVelocity;
	private Vector2 jumpVelocity;
	private bool isJump;
	private BoxCollider2D boxCollider;
	[SerializeField] private LayerMask layerMask;
	private SpriteRenderer spriteRender;
	
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		boxCollider = transform.GetComponent<BoxCollider2D>();
	    spriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
		
		//horizontal movement
		
      float moveInput = Input.GetAxisRaw("Horizontal");
			moveVelocity = moveInput* speed;
		
				// animation
			
		if(Input.GetAxisRaw("Horizontal") < 0){
			spriteRender.flipX = true;
		}
		else if (Input.GetAxisRaw("Horizontal") > 0){ 
		spriteRender.flipX = false; }
	   animator.SetFloat("Speed", Mathf.Abs(moveVelocity) );
	
	
		//jumping
		isJump = Input.GetKeyDown("space");
			 if (IsGrounded() && isJump) {
		 rb.AddForce(new Vector2(moveVelocity*0.25f,1) * new Vector2(1,jumpSpeed),ForceMode2D.Impulse);
		 Debug.Log("Jump");
		 
	 } 
	
	  //jumping and falling animation
	  if(IsGrounded()== false && rb.velocity.y > 0 ){
		  animator.SetBool("IsJumping",true); 
	  }
	  else if(IsGrounded() == false && rb.velocity.y < 0) {
		  animator.SetBool("IsFalling",true);
		  animator.SetBool("IsJumping",false);
	  }
	    else{
		  animator.SetBool("IsJumping",false);
		  animator.SetBool("IsFalling",false);
	  }
	  
	  
	  
	  
			
 }
 
 void FixedUpdate(){    //use this for physics based updates
	
	transform.Translate(new Vector3(moveVelocity,0f,0f) * Time.fixedDeltaTime);
	
	 
	 
 }
 
 private bool IsGrounded(){
	 
	 RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, layerMask);
	 return raycastHit2d.collider != null;
	 
	 
 }
 
 
}
