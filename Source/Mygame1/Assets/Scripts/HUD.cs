using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Sprite[] heartSprites;
	public Image heartUI;
	private GameObject player;
	private int playerHealth;
 
   void Start(){
	   
	   player = GameObject.FindWithTag("Player");
	 
	   
   }
   
   void Update(){
	   
	   if(player !=null){
	     playerHealth = player.GetComponent<PlayerCombat>().currentHealth;
	   heartUI.sprite = heartSprites[playerHealth];
	   
	   } else{
		   
		     heartUI.sprite = heartSprites[0];
	   }
	   
	   
	   
   }
 
 
 
}
