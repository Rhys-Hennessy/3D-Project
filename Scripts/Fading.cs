using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour {

    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.8f;

    private int drawDepth = -1000;
    private float alpha = 1f;
    private float fadeDirection = -1;


    private void OnGUI()
    {
        alpha += fadeDirection * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
        
        if (alpha > 0.8)
        {
            SceneManager.LoadScene(1);
        }
    }
        
    public float BeginFade (int direction)
    {
       
        fadeDirection = direction;
        return (fadeSpeed);
    }

    private void OnLevelWasLoaded(int level)
    {
        BeginFade(-1);
    }
}
