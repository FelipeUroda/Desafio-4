using UnityEngine;

public class Mesa : MonoBehaviour
{
    public bool ocupada = false;
    public string pedidoEsperado;
    public Cliente clienteAtual; 


    public void ReceberPrato(GameObject prato)
    {
        if (!ocupada)
        {
            Debug.Log("Nenhum cliente na mesa para receber o prato.");
            Destroy(prato);
            return;
        }

        
        if (prato.name.Contains(pedidoEsperado))
        {
            Debug.Log("Pedido correto entregue!");

            if (PontuacaoManager.Instance != null)
                PontuacaoManager.Instance.AdicionarPontos(10);

                clienteAtual.ReceberPrato();

            
            Destroy(prato);
        }
        else    //atualizar com animações
        {
            Debug.Log(" Pedido errado entregue!");
    
            Destroy(prato);
        }
    }



















}

