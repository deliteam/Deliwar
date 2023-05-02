using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BacktoMenu : MonoBehaviour
{
   
    public void Back()
    {
        //SceneManager.LoadScene("Menu_GameVictory");
		
    }
	
	
	private void OnTriggerEnter2D(Collider2D collision)
{

        SceneManager.LoadScene("Menu_GameVictory");
   
    
}
	
	
	
	
	
	
 }
