using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Cliente : MonoBehaviour
{
    public float velocidade = 2f;
    public Image barraPaciência;
    public float tempoMaximo = 10f;
    private float tempoAtual;

    private Transform destino;
    private Mesa mesaAtual;
    private bool chegou = false;

    public GameObject pedidoVisual;
    public Sprite[] pedidosPossiveis;

    void Awake()
    {
        if (pedidoVisual == null)
        {
            pedidoVisual = transform.Find("PedidoClone")?.gameObject;

            if (pedidoVisual == null)
            {
                Debug.LogError("pedidoVisual não foi encontrado como filho do cliente!");
            }
        }
    }

    void Update()
    {
        if (!chegou && destino != null)
        {
            Debug.Log($"Cliente {gameObject.name} indo para {destino.name} | Posição atual: {transform.position} | Destino: {destino.position}");
            transform.position = Vector2.MoveTowards(transform.position, destino.position, velocidade * Time.deltaTime);

            if (Vector2.Distance(transform.position, destino.position) < 0.1f)
            {
                chegou = true;
                FazerPedido();
            }
        }
        else if (!chegou && destino == null)
        {
            Debug.LogWarning($"Cliente {gameObject.name} sem destino definido!");
        }

        if (chegou)
        {
            tempoAtual -= Time.deltaTime;
            barraPaciência.fillAmount = tempoAtual / tempoMaximo;

            if (tempoAtual <= 0)
            {
                Desistir();
            }
        }
    }

    public void DefinirDestino(Transform destinoMesa)
{
    if (destinoMesa == null)
    {
        Debug.LogError($"Destino recebido é nulo para {gameObject.name}.");
        return;
    }

    destino = destinoMesa;
    mesaAtual = destino.GetComponent<Mesa>();

    if (mesaAtual == null)
    {
        Debug.LogError($"Transform {destino.name} não possui um componente Mesa!");
        return;
    }

    mesaAtual.clienteAtual = this;

    tempoAtual = tempoMaximo;
    chegou = false;

    if (pedidoVisual != null)
    {
        pedidoVisual.SetActive(false);
    }
    else
    {
        Debug.LogWarning($"pedidoVisual não definido para {gameObject.name}.");
    }

    Debug.Log($"Destino definido para {gameObject.name}: {destino.name}.");
}

    void FazerPedido()
    {
        int indice = Random.Range(0, pedidosPossiveis.Length);
        pedidoVisual.GetComponent<SpriteRenderer>().sprite = pedidosPossiveis[indice];
        pedidoVisual.SetActive(true);
        PontuacaoManager.Instance.AdicionarPontos(1);
    }

    public void DefinirPedido(string nomeDoPedido, Sprite iconePedido)
    {
        if (pedidoVisual != null && iconePedido != null)
        {
            pedidoVisual.GetComponent<SpriteRenderer>().sprite = iconePedido;
            pedidoVisual.SetActive(true);
        }

        if (mesaAtual != null)
        {
            mesaAtual.pedidoEsperado = nomeDoPedido;
            mesaAtual.ocupada = true;
        }

        tempoAtual = tempoMaximo;
    }

    public void ReceberPrato()
    {
        mesaAtual.ocupada = false;
        Destroy(gameObject);
    }

    void Desistir()
    {
        mesaAtual.ocupada = false;
        Destroy(gameObject);
    }
}
