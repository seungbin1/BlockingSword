using UnityEngine;

public class DoubleEsc : MonoBehaviour
{

    //public string SceneToLoad;

    // Update is called once per frame
    int ClickCount = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClickCount++;
            if (!IsInvoking("DoubleClick"))
                Invoke("DoubleClick", 1.0f);

        }
        else if (ClickCount == 2)
        {
            CancelInvoke("DoubleClick");
            Application.Quit();
        }

    }

    void DoubleClick()
    {
        ClickCount = 0;
    }

}

