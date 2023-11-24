using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Throw : MonoBehaviour
{
    public float forcaLancamento = 10f; // Ajuste conforme necessário
    public Transform pontoLancamento; // Ponto de origem do arremesso
    public GameObject objetoParaArremessar; // Objeto que será arremessado
    private Animator anim;
    public PlayerMovementTutorial play;

    private void Start()
    {
        play = GetComponent<PlayerMovementTutorial>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        
    }

    private void ArremessarObjeto()
    {
        Debug.Log("Entrou");
        GameObject objetoArremessado = Instantiate(objetoParaArremessar, pontoLancamento.position, pontoLancamento.rotation);
        Rigidbody rb = objetoArremessado.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(pontoLancamento.forward * forcaLancamento, ForceMode.Impulse);
            Destroy(objetoArremessado, 3f); // Destruir o objeto após 3 segundos
        }
        else
        {
            Debug.LogError("O objeto para arremessar não tem um Rigidbody anexado.");
        }
        
        //anim.SetBool("transition", false);
    }
}
