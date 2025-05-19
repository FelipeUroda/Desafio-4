using UnityEngine;

public class ObjetoInterativo : MonoBehaviour
{
    public string mensagem = "Você interagiu com o objeto!";

    public void Interagir()
    {
        Debug.Log(mensagem);
        // Aqui você pode colocar lógica: abrir porta, pegar item, ativar diálogo etc.
    }
}
