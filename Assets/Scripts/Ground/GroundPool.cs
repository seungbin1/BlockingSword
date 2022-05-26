using System.Collections;
using UnityEngine;

public class GroundPool : MonoBehaviour
{
    float waitp = 0.6f;
    float wait3=3.5f;
    float wait2=1.5f;
    float wait=0;
    float waitCount = 0;
    float randomWait = 3;
    int childCount = 0;
    private void Destroy()
    {
        this.transform.GetChild(childCount).gameObject.SetActive(false);
    }
    private void Start()
    {   
        StartCoroutine(Delay());
    }
    private void Update()
    {
        if (this.transform.GetChild(childCount).transform.position.x < -13f)
        {
            Destroy();
        }
    }
    IEnumerator Delay()
    {
        while (true)
        {
            if (this.transform.GetChild(childCount).gameObject.activeSelf == false)
            {
                this.transform.GetChild(childCount).transform.position = new Vector2(13.5f, -3.56f);
                this.transform.GetChild(childCount).gameObject.SetActive(true);
                childCount++;
                waitCount += 0.3f;
                if (childCount > 10)
                {
                    childCount = 0;
                    if (wait2 > 0.45f)
                    {
                        wait2 -= 0.25f;
                    }
                    if (wait3 > 1.2f)
                    {
                        wait3 -= 0.25f;
                    }
                    if (waitp < 1.32f)
                    {
                        waitp += 0.1f;
                    }
                }
            }
            if (randomWait < waitCount)
            {
                randomWait = Random.Range(wait2, wait3);
                wait = Random.Range(0.45f,waitp);
                waitCount = 0;
            }
            yield return new WaitForSeconds(0.365f);
            yield return new WaitForSeconds(wait);
            wait = 0;
        }
    }
}
