using UnityEngine;

public class interacaoCliente : MonoBehaviour
{
    private bool pertoDoCliente = false;
    private bool pertoDaCozinha = false;

    private bool temPedido = false;
    private bool pedidoPronto = false;
    private bool temPedidoPronto = false;

    void Update()
    {
        if (pertoDoCliente && Input.GetKeyDown(KeyCode.E) && !temPedido && !temPedidoPronto)
        {
            Debug.Log("Pegou pedido do cliente.");
            temPedido = true;
        }

        if (pertoDaCozinha && temPedido && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Preparando pedido...");
            temPedido = false;
            Invoke("PedidoFicouPronto", 2f); // simula tempo de preparo
        }

        if (pertoDaCozinha && pedidoPronto && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Pegou pedido pronto.");
            pedidoPronto = false;
            temPedidoPronto = true;
        }

        if (pertoDoCliente && temPedidoPronto && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Pedido entregue!");
            temPedidoPronto = false;
        }
    }

    void PedidoFicouPronto()
    {
        Debug.Log("Pedido ficou pronto!");
        pedidoPronto = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cliente"))
            pertoDoCliente = true;
        if (other.CompareTag("Cozinha"))
            pertoDaCozinha = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Cliente"))
            pertoDoCliente = false;
        if (other.CompareTag("Cozinha"))
            pertoDaCozinha = false;
    }
}
