using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f;  // Velocidade de movimento do inimigo
    public float chaseRange = 5f; // Raio de persegui��o

    private Transform player;     // Refer�ncia ao transform do jogador
    private bool isChasing = false; // Verifica se o inimigo est� perseguindo
    private Animator anim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Encontrar o jogador no in�cio
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Verificar se o jogador est� dentro do raio de persegui��o
        if (distanceToPlayer < chaseRange)
        {
            isChasing = true;
            // Olhar na dire��o do jogador
            Vector3 direction = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
        else
        {
            isChasing = false;
            
        }

        // Se estiver perseguindo, mover em dire��o ao jogador
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
