using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;

    public int pontuacaoAtual = 0;
    public int pontuacaoParaVitoria = 10;
    public TextMeshProUGUI textoPontuacao;

    void Awake()
    {
        if (instancia == null)
            instancia = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        AtualizarTextoPontuacao();
        if (Time.timeScale == 0)
        {
            Debug.LogWarning(" Time.timeScale foi pausado!");
        }
    }

    public void AdicionarPonto(int valor)
    {
        pontuacaoAtual += valor;
        AtualizarTextoPontuacao();

        if (pontuacaoAtual >= pontuacaoParaVitoria)
        {
            Debug.Log("Vitória!");

        }
    }

    public void RemoverPonto(int valor)
    {
        pontuacaoAtual -= valor;
        if (pontuacaoAtual < 0) pontuacaoAtual = 0;

        AtualizarTextoPontuacao();
    }

    void AtualizarTextoPontuacao()
    {
        if (textoPontuacao != null)
            textoPontuacao.text = "Pontos: " + pontuacaoAtual;
    }
}