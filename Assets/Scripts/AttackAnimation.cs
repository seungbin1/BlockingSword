using System.Collections;
using UnityEngine;

public class AttackAnimation : MonoBehaviour
{
    public GameObject audio;
    public bool pscore = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            audio.gameObject.SetActive(true);
            other.gameObject.SetActive(false);
            pscore = true;
            StartCoroutine(attackaudio());
        }
    }
    IEnumerator attackaudio()
    {
        audio.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        audio.gameObject.SetActive(false);
    }
}
