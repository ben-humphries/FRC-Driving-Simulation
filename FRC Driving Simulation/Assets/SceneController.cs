using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	public static bool firstLoad = false;

	void Start(){

		//COMMENT AND UNCOMMENT BEFORE BUILD

		if (PlayerPrefs.GetInt ("FirstLoad") == 0) {
			firstLoad = true;
			PlayerPrefs.SetInt ("FirstLoad", 1);
		}

		//UNCOMMENT AND RECOMMENT BEFORE BUILD
		//PlayerPrefs.SetInt("FirstLoad", 0);
	}
	
	public void SwitchScenes(string sceneName){
		SceneManager.LoadScene (sceneName);
	}
	public void ReloadScene(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}
	public void MainMenu(){
		SceneManager.LoadScene ("MainMenu");
	}
	public void Quit(){
		Application.Quit ();
	}
}
