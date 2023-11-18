using System.Collections;
using UnityEngine;

public class ExplodingEyeScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator; 
    public string explosionAnimationName = "Explode";
    public int damageAmount = 1;

    private Vector3 previousPosition;
    private SpriteRenderer spriteRenderer;
    private bool isExploding = false; 

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>(); 
        previousPosition = transform.position;
    }

    void Update() {
        //if exploding, stays in place and does not do anything at the moment
        if (isExploding)
            return; 

        GameObject player = GameObject.FindGameObjectWithTag("Player");
       
        if (player != null) {
            Vector3 targetPosition = player.transform.position;
            MoveCharacter(targetPosition);

            // Determine the direction of movement based on the change in position
            float moveDirection = transform.position.x - previousPosition.x;

            // Flip the sprite based on the direction
            if (moveDirection < 0) {
                spriteRenderer.flipX = true;
            }
            else if (moveDirection > 0) {
                spriteRenderer.flipX = false;
            }
            previousPosition = transform.position;
        }
    }

    void MoveCharacter(Vector3 targetPosition)
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }

    // When the monster touches the player character, it will trigger the explode function
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && !isExploding) {
            StartCoroutine(Explode(other)); // Pass the collider to the coroutine
        }
    }
    
    // Modified coroutine for the explosion animation
    private IEnumerator Explode(Collider2D playerCollider) {
    isExploding = true;
    
    animator.SetBool("isExploding", true);
    
    yield return new WaitForSeconds(1.1f); // Wait for the animation to finish

    // Apply damage to the player
    if (playerCollider != null && playerCollider.gameObject != null) {
        PlayerBehavior playerBehavior = playerCollider.gameObject.GetComponent<PlayerBehavior>();
        if (playerBehavior != null) {
            playerBehavior.PlayerTakeDmg(damageAmount);
        }
    }
    
    Destroy(gameObject);
    }
}