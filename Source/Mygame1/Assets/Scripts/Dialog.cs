using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Dialog : MonoBehaviour
{
	
	public TextMeshProUGUI textDisplay;
	public string[] sentences;
	private int index;
	public float typingSpeed;
    public bool cantalk = true;   //to prevent spam pressing talk button
	public bool donetalking = false;
	
    void Start(){
		StartCoroutine(Type());
		donetalking = false;
	}
	
	void Update(){
		if(textDisplay.text == sentences[index]){
			cantalk = true;
			
		}
	}
	

	
	
	
IEnumerator Type(){
	
	foreach(char letter in sentences[index].ToCharArray()){       //type one letter at a time
		textDisplay.text += letter;
		yield return new WaitForSeconds(typingSpeed);
	}
	
}

public void NextSentence(){
	
	cantalk = false;
	donetalking = false;
	if(index < sentences.Length - 1){    //check to see if current sentence ended
		index++;
		textDisplay.text = "";
		StartCoroutine(Type());
		
	}
	else {
		textDisplay.text = "";
		donetalking = true;
		cantalk = true;
		index = 0;
	}
	
	
	
	
}

}
