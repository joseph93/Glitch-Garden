using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadePanel : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    StartCoroutine(FadeInScene(1.5f));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public IEnumerator FadeInScene(float fadeTime)
    {

        Color panelColor = Color.black;
        float startAlpha = panelColor.a;

        while (panelColor.a > 0)
        {
            panelColor.a -= startAlpha*Time.deltaTime/fadeTime;
            GetComponent<Image>().color = panelColor;
            yield return null;
        }
        
        gameObject.SetActive(false);

    }
}
