using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
	
	public void SwitchScenes(string sceneName){
		SceneManager.LoadScene (sceneName);
	}
	public void MainMenu(){
		SceneManager.LoadScene ("MainMenu");
	}
	public void Quit(){
		Application.Quit ();
	}
}
