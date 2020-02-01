using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float jumpHeight = 4;
	public float timeToJumpApex = .4f;
	float accelerationTimeAirborne = .2f;
	float accelerationTimeGrounded = .1f;
	float moveSpeed = 6;

	float gravity;
	float jumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;

    Rigidbody2D Rb2D;

    public float JumpVel;

	void Start() {
        Rb2D = GetComponent<Rigidbody2D>();

        gravity = (-(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2)) / Mathf.Abs(Physics2D.gravity.y);
        Rb2D.gravityScale = Mathf.Abs(gravity);
		jumpVelocity = Mathf.Abs(gravity * Mathf.Abs(Physics2D.gravity.y)) * timeToJumpApex;
		print ("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);
	}

	void Update() {

		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		if (Input.GetKeyDown (KeyCode.Space)) {
            Rb2D.velocity = new Vector2(Rb2D.velocity.x, jumpVelocity);
        }

		float targetVelocityX = input.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, accelerationTimeGrounded);
		//velocity.y += gravity * Time.deltaTime;
        Rb2D.velocity = new Vector2(velocity.x, Rb2D.velocity.y);
	}
}
