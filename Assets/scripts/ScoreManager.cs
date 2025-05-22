using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PontuacaoManager : MonoBehaviour
{
    public static PontuacaoManager Instance;
    public int pontos = 0;
    public TextMeshProUGUI textoPontuacao;

    [Header("Vitória")]
    public GameObject painelVitoria;




    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AdicionarPontos(int valor)
    {
        pontos += valor;
        AtualizarUI();

        if (pontos >= 10)
        {
            CarregarCenaVitoria();
        }

    }

    void AtualizarUI()
    {
        if (textoPontuacao != null)
        {
            textoPontuacao.text = pontos.ToString();
            Debug.Log("Ponto " + pontos);
        }
    }

    void CarregarCenaVitoria()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("CenaVitoria");
    }


}
/*alterar o metodo de adicionar pontos para receber o valor do cliente, e adicionar o valor no cliente, e depois somar os pontos*/