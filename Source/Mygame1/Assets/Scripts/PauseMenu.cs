using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    
  public static bool gameIsPaused = false;
  public GameObject pauseMenuUI;
  private GameObject playercontroller;
 
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
			
			if(gameIsPaused){
				Resume();
			} else{
				Pause();
			
			}
			
			
		}
    }
	
	public void Resume(){
		
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1;
		gameIsPaused = false;
		playercontroller.GetComponent<PlayerController>().enabled = true;
		playercontroller.GetComponent<PlayerCombat>().enabled = true;
		
		
	}
	
	
	
	public void Pause(){
		
	playercontroller = GameObject.FindWithTag("Player");
		
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0;
		gameIsPaused = true;
		playercontroller.GetComponent<PlayerController>().enabled = false;
		playercontroller.GetComponent<PlayerCombat>().enabled = false;
		
	}
	
	public void LoadMenu(){
		Time.timeScale = 1f;
		gameIsPaused = false;
		SceneManager.LoadScene(0);
	}
	
	public void QuitGame(){
		Application.Quit();
	}
	
	
	
	
}
