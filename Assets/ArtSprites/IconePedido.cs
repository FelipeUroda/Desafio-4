using UnityEngine;

public class PedidoCliente : MonoBehaviour
{
    public SpriteRenderer pedidoIconeRenderer; 
    public Sprite[] pratosSprites;             

    private int pratoIndex;

    void Start()
    {
    
        pratoIndex = Random.Range(0, pratosSprites.Length);
        pedidoIconeRenderer.sprite = pratosSprites[pratoIndex];
    }

    public int GetPratoIndex()
    {
        return pratoIndex;
    }
}