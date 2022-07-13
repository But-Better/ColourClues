using UnityEngine;
[RequireComponent(typeof(NetworkMovementScript))]
public class CharacterAnimationController : MonoBehaviour {

    private NetworkMovementScript networkMovementScript;
    private Animator animator;

    private void Awake() {
        networkMovementScript = GetComponent<NetworkMovementScript>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if(networkMovementScript.Grounded) {
            animator.SetBool("airborn", true);
            return;
        }

        if(networkMovementScript.Velocity.x > 0f) {
            animator.SetBool("walk", true);
            return;
        }
    }
}