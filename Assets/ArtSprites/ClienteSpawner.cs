using UnityEngine;
using System.Collections.Generic;

public class ClientSpawner : MonoBehaviour
{
    public GameObject clientPrefab; 
    public List<Transform> mesasDisponiveis; 
    public float tempoEntreClientes = 8f;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= tempoEntreClientes)
        {
            SpawnCliente();
            timer = 0f;
        }
    }

    void SpawnCliente()
    {
        bool clienteInstanciado = false;

        foreach (Transform mesa in mesasDisponiveis)
        {
            Mesa mesaScript = mesa.GetComponent<Mesa>();
            if (!mesaScript.ocupada)
            {
                GameObject novoCliente = Instantiate(clientPrefab, transform.position, Quaternion.identity);
                novoCliente.GetComponent<Cliente>().DefinirDestino(mesa);
                mesaScript.ocupada = true;
                clienteInstanciado = true;
                break;
            }
        }

        if (!clienteInstanciado)
        {
            Debug.LogWarning("Todas as mesas estão ocupadas! Cliente não foi instanciado.");
        }
    }
}
