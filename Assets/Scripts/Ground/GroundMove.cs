using UnityEngine;

public class GroundMove : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    private void Update()
    {
        if (Time.timeScale == 1)
        {
            this.transform.Translate(new Vector2(-6.75f*Time.deltaTime,0));
        }
    }
}
