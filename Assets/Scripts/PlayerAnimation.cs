using System.Collections;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    bool start = true;
    Animator animator = null;
    public GameObject audio;
    private IEnumerator ATTack()
    {
        animator.Play("Rogue_attack_03");
        start = false;
        yield return new WaitForSeconds(0.5f);
        start = true;
    }
    private IEnumerator AttackAudio()
    {
        audio.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        audio.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    Rigidbody2D rigidbody2D;
    public double mouseCount = 0;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        mouseCount = 0;
    }
    private void Update()
    {
        if (this.transform.position.y < -2.15f)
        {
            mouseCount = 2;
        }
        if (this.transform.position.y < -5f)
        {
            Time.timeScale = 0;
        }
        if (Input.touchCount > 0)
        {
            for(int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                if (touch.position.x < Screen.width / 2)
                {
                    if (mouseCount < 2d)
                    {
                        if (touch.phase == TouchPhase.Began)
                        {
                            mouseCount++;
                            if (mouseCount <1.1d )
                            {
                                rigidbody2D.AddForce(new Vector2(0, 4f), ForceMode2D.Impulse);
                            }
                        }
                        if (touch.phase == TouchPhase.Stationary)
                        {
                            rigidbody2D.AddForce(new Vector2(0, 0.1f), ForceMode2D.Impulse);
                            mouseCount += 1.5 * Time.deltaTime;
                        }
                        if (touch.phase == TouchPhase.Moved)
                        {
                            rigidbody2D.AddForce(new Vector2(0, 0.1f), ForceMode2D.Impulse);
                            mouseCount += 1.5 * Time.deltaTime;
                        }
                    }
                }
                if (touch.position.x > Screen.width / 2)
                {
                    if (start == true)
                    {
                        StartCoroutine(ATTack());
                        StartCoroutine(AttackAudio());
                    }
                }
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "JumpCheck")
        {
            mouseCount = 0;
        }
    }
}
