using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Vector2 moveInput;

    public Rigidbody2D theRB;
    public Transform gunArm;
    private Camera theCam;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        theCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        moveInput.Normalize();

        //transform.position += new Vector3(moveInput.x * Time.deltaTime * moveSpeed, moveInput.y * Time.deltaTime * moveSpeed, 0f);

        theRB.velocity = moveInput * moveSpeed;

        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = theCam.WorldToScreenPoint(transform.localPosition);

        // flifing player and gun
        if (mousePos.x < screenPoint.x)
        {
            transform.localScale = new Vector3(-1f, 1, 1);
            gunArm.localScale = new Vector3(-1, -1, 1);

        }
        else
        {
            transform.localScale = Vector3.one;
            gunArm.localScale = Vector3.one;

        }

        // rotate a Gun Arm
        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        gunArm.rotation = Quaternion.Euler(0, 0, angle);

        // moving Animation
        if (moveInput != Vector2.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }
}
