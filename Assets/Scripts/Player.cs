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
    public float distToGround;
    BoxCollider2D coll;
    public LayerMask Layer;

	void Start() {
        Rb2D = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();

        distToGround = coll.bounds.extents.y;

        gravity = (-(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2)) / Mathf.Abs(Physics2D.gravity.y);
        Rb2D.gravityScale = Mathf.Abs(gravity);
		jumpVelocity = Mathf.Abs(gravity * Mathf.Abs(Physics2D.gravity.y)) * timeToJumpApex;
		print ("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);
	}

    public bool IsGrounded() {

        return Physics2D.Raycast(transform.position, Vector2.down, distToGround + 0.1f, Layer);
    }

	void Update() {
        Debug.DrawLine(transform.position, transform.position + Vector3.down * (distToGround + 0.1f), Color.white);
        Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
        print(IsGrounded());
		if (Input.GetKeyDown (KeyCode.Space) && IsGrounded()) {
            Rb2D.velocity = new Vector2(Rb2D.velocity.x, jumpVelocity);
        }

		float targetVelocityX = input.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, accelerationTimeGrounded);
		//velocity.y += gravity * Time.deltaTime;
        Rb2D.velocity = new Vector2(velocity.x, Rb2D.velocity.y);
	}
}
