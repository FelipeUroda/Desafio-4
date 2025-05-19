using UnityEngine;

public class InteracaoCozinha : MonoBehaviour
{
    private ObjetoInterativo objetoProximo;

    void Update()
    {
        if (objetoProximo != null && Input.GetKeyDown(KeyCode.E))
        {
            objetoProximo.Interagir();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        objetoProximo = other.GetComponent<ObjetoInterativo>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<ObjetoInterativo>() == objetoProximo)
        {
            objetoProximo = null;
        }
    }
}
