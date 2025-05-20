using UnityEngine;
using TMPro;

public class PontuacaoManager : MonoBehaviour
{
    public static PontuacaoManager Instance;
    public int pontos = 0;
    public TextMeshProUGUI textoPontuacao;

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
    }

    void AtualizarUI()
    {
        if (textoPontuacao != null)
        {
        textoPontuacao.text = pontos.ToString();
            Debug.Log("Ponto " + pontos);
        }
    }
}
