using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{
	
	public Transform[] backgrounds;      //array of all back and forgrounds to be paralxed
	private float[] parallaxScales;                     //array to contain all of the parallax scales for movement
	public float smoothing =1f;								//how smooth the parallax is going to be
	
	
	private Transform cam;             //Reference to the main camera's transform
	private Vector3 previousCamPos;    //Store the position of the camera in the previous frame
	
	//Is called before Start(). Loads after objects. Great for references
	void Awake() {
		//set up the camera reference
		cam = Camera.main.transform;
		Debug.Log(cam);
	}
	
    // Start is called before the first frame update
    void Start()
    {
        // Previous frame had the current frames camera position
		previousCamPos = cam.position;
	
	//Assigning corresponding aprallaxscales
	parallaxScales = new float[backgrounds.Length];		
		for (int i =0; i < backgrounds.Length; i++) {
			parallaxScales[i] = backgrounds[i].position.z*-1;
			
		}
		
    }

    // Update is called once per frame
    void Update()
    {
		
		//for each background
       for(int i = 0; i < backgrounds.Length; i++){
		   //parallax is the opposite of the camera movement because the previous fframe multiplied by the scale
		   float  parallax_X= (previousCamPos.x - cam.position.x) * parallaxScales[i];
		   float  parallax_Y= (previousCamPos.y - cam.position.y) * parallaxScales[i];
		   //set a traget x position which is the current position plus the parallax
		   float backgroundTargetPosX = backgrounds[i].position.x + parallax_X;
		float backgroundTargetPosY = backgrounds[i].position.y + parallax_Y;
			//create a target position which is the background current position with its target x position
			Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX,backgroundTargetPosY , backgrounds[i].position.z);
		
		 // fadeb between current position and target position using lerp
		 backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		   
		   
	   }
		
		//set previous cam position to cameras position at end of frame	'
		previousCamPos = cam.position;
		
		
    }
}
