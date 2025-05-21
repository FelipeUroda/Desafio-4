using UnityEngine;
using System.Collections;

public class ClienteSpawner : MonoBehaviour
{

    public GameObject clientePrefab;
    public Transform[] mesas; 
    public Sprite[] pedidos; 
    public float tempoEntreClientes = 5f;
    public string[] nomesPratos; 
    private float tempoProximoCliente;

    void Update()
    {
        if (Time.time >= tempoProximoCliente)
        {
            SpawnCliente();
            tempoProximoCliente = Time.time + tempoEntreClientes;
        }
    }


    void SpawnCliente()
{
    GameObject novoCliente = Instantiate(clientePrefab, transform.position, Quaternion.identity);
    Cliente clienteScript = novoCliente.GetComponent<Cliente>();

    Transform mesa = mesas[Random.Range(0, mesas.Length)];

    int indicePedido = Random.Range(0, pedidos.Length);

    Sprite pedidoSprite = pedidos[indicePedido];
    string nomePrato = nomesPratos[indicePedido];

    clienteScript.DefinirPedido(nomePrato, pedidoSprite);
}

}


