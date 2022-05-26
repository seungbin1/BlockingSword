using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = -5.5f;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition += new Vector3(speed * Time.deltaTime, 0, 0);
        if (speed > -16)
        {
            speed += -0.15f * Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Time.timeScale = 0;
        }
    }
}
