using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f;  // Velocidade de movimento do inimigo
    public float chaseRange = 5f; // Raio de perseguição

    private Transform player;     // Referência ao transform do jogador
    private bool isChasing = false; // Verifica se o inimigo está perseguindo
    private Animator anim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Encontrar o jogador no início
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Verificar se o jogador está dentro do raio de perseguição
        if (distanceToPlayer < chaseRange)
        {
            isChasing = true;
            // Olhar na direção do jogador
            Vector3 direction = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
        else
        {
            isChasing = false;
            
        }

        // Se estiver perseguindo, mover em direção ao jogador
        if (isChasing)
        {
            anim.SetInteger("condicao", 1);
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            transform.Translate(dirToPlayer * moveSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            anim.SetInteger("condicao", 0);
        }
    }
}
