using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{

public void Pausado()
{
    Time.timeScale = 0;
}

public void SairDoPause()
{
    Time.timeScale = 1;

}

public void VoltarParaMenuPrincipal()
{
    
    Time.timeScale = 1f;

    SceneManager.LoadScene("MainMenu"); 
}




}