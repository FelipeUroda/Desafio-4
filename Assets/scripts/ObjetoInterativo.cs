using UnityEngine;

public class ObjetoInterativo : MonoBehaviour
{
    public string mensagem = "Voc� interagiu com o objeto!";

    public void Interagir()
    {
        Debug.Log(mensagem);
        // Aqui voc� pode colocar l�gica: abrir porta, pegar item, ativar di�logo etc.
    }
}
