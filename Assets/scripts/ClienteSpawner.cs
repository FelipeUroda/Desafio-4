using UnityEngine;
using System.Collections.Generic;

public class ClientSpawner : MonoBehaviour
{
    public GameObject clientPrefab;
    public List<Transform> mesasDisponiveis;
    public float tempoEntreClientes = 30f;
    private float timer = 0f;

    private int clientesAtivos = 0;

    void Update()
    {
        timer += Time.deltaTime;

        if (clientesAtivos < 2 && timer >= tempoEntreClientes)
        {
            bool clienteCriado = SpawnCliente();

            if (clienteCriado)
            {
                clientesAtivos++;
                timer = 0f;
            }
        }
    }

    bool SpawnCliente()
    {
        foreach (Transform mesa in mesasDisponiveis)
        {
            Mesa mesaScript = mesa.GetComponent<Mesa>();
            if (!mesaScript.ocupada)
            {
                GameObject novoCliente = Instantiate(clientPrefab, transform.position, Quaternion.identity);

                Cliente clienteScript = novoCliente.GetComponent<Cliente>();
                clienteScript.DefinirDestino(mesa);
                mesaScript.ocupada = true;
                return true;
            }
        }

        return false; 
    }

    public void ClienteSaiu()
    {
        clientesAtivos = Mathf.Max(0, clientesAtivos - 1);
    }
}
