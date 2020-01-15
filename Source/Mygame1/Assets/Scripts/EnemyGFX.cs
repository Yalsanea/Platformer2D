﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour{
private SpriteRenderer spriteRender;
    // Start is called before the first frame update
 public AIPath aiPath;

    // Update is called once per frame
    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.1f){
			transform.localScale = new Vector3(-1f,1f,1f);
		}
		else if (aiPath.desiredVelocity.x <= -0.1f){
			transform.localScale = new Vector3(1f,1f,1f);
		}
			
    }
}
