using UnityEngine;
using UnityEngine.SceneManagement;

public class CenaVitoria : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0f; 
    }


    public void VoltarAoMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MainMenu");


    }
}
