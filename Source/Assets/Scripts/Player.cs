using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 2000;
    public float playerSpeed = 200;
    public float playerJump = 2000;
    public List<string> resetObject;
    public List<CollisionSound> collisionSound;
    public bool insideMenu = false;

    private GameManager manager;

    private ForceMode mode = ForceMode.VelocityChange;
    private bool jump = true;
    // Start is called before the first frame update
    private void Awake()
    {
        manager = GameManager.getGameManager();
    }
    void Start()
    {
        if (manager != null)
        {
            manager.restart(this);
        }
    }
    private void jumpAction()
    {
        if (jump)
        {
            SoundManager.SoundLibrary().play("Jump");
            rb.AddForce(0, playerJump * Time.deltaTime, 0);
            jump = false;
        }
    }
    private void moveX(float multiply)
    {
        rb.AddForce((playerSpeed * multiply) * Time.deltaTime, 0, 0, mode);
    }

    private void input()
    {
        if (Input.GetButton("Horizontal"))
        {
            moveX(Input.GetAxis("Horizontal"));
        }

        moveX(Input.GetAxisRaw("Horizontal gamepad"));

        if (Input.GetButtonDown("Jump"))
        {
            jumpAction();
        }

        if (Input.GetButtonDown("Pause"))
        {
            GameManager.getGameManager().pause();
        }

        if (Input.GetButtonDown("Restart"))
        {
            manager.restart(this);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!insideMenu)
        {
            input();
        }
        rb.AddForce(0, 0, force * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach(string val in resetObject)
        {
            if(collision.collider.name == val)
            {
                jump = true;
            }

        }
        foreach (CollisionSound val in collisionSound)
        {
            string formated = collision.collider.name;
            if (collision.collider.name.IndexOf(" ") != -1)
            {
                formated = collision.collider.name.Substring(0, collision.collider.name.IndexOf(" "));
            }

            if (formated == val.objectHit)
            {
                SoundManager.SoundLibrary().play(val.soundName);
            }
        }
    }
}
