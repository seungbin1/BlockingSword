using System.Collections;
using UnityEngine;

public class EnemyPooling : MonoBehaviour
{
    private int childNum=0;
    private Vector2 EnemyPosition;
    private float waitcount=4;
    private float waitcountMin = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }
    private IEnumerator Spawn()
    {

        while (true)
        {
            childNum += 1;
            Waitcount();
            if (childNum > 3)
            {
                childNum = 0;
            }
            yield return new WaitForSeconds(Random.Range(waitcountMin, waitcount));
            EnemyPosition =  new Vector2(2, Random.Range(-1.6f, 1.7f));
            this.transform.GetChild(childNum).gameObject.SetActive(true);
            this.transform.GetChild(childNum).transform.localPosition = EnemyPosition;
        }
    }
    private void Waitcount()
    {
        if (waitcount > 2f)
        {
            waitcount -= 0.035f;
            Debug.Log(waitcount);
        }
        if (waitcountMin > 0.6f)
        {
            waitcountMin -= 0.0075f;
            Debug.Log(waitcountMin);
        }
    }
}
