using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToggleLargeMap : MonoBehaviour
{
    [SerializeField] private GameObject map; //Map game object
    [SerializeField] private AnimationCurve curve; //Used for easing-in and easing-out the animation
    [SerializeField] private TextMeshProUGUI MapStateTextMesh;
    #region private Variables
    private float speed = 0.1f; //Animation Speed
    private bool animIsPlaying; //Bool if the animation is playing
    private bool isShowing; //Bool if the map is shown
    private float finalScaleX = 1; //The expected x-scale when the map pops up
    private float finalScaleY = 1; // The expected y-scale when the map pops up 
    #endregion

    private void Start()
    {
        isShowing = false;
        finalScaleX = map.transform.localScale.x;
        finalScaleY = map.transform.localScale.y;
        MapStateTextMesh.text = "Show\nMap";
        map.SetActive(false);
        //map.SetActive(isShowing);
    }

    public void Toggle()
    {
        if (animIsPlaying)
        {
            return;
        }

        if (!isShowing)
        {
            StartCoroutine(PopIn2());
        }
        else
        {
            StartCoroutine(PopOut2());
        }
        
    }

    #region Animations
    //Pop in variant 1
    IEnumerator PopIn1()
    {
        animIsPlaying = true;
        map.SetActive(true);
        float time = 0.0f; //Reset to 0 so that the curve can work
        float curScaleX = 0.0f;
        float curScaleY = 0.0f;
        map.transform.localScale = new Vector2(0.001f, 0.001f);
        while (curScaleX < finalScaleX && curScaleY < finalScaleY)
        {
            time += Time.deltaTime;
            if(curScaleX < finalScaleX)
            {
                curScaleX += speed * curve.Evaluate(time);
                //curScaleX = Mathf.Clamp(curScaleX, 0.0f, finalScaleX);
            }

            if(curScaleY < finalScaleY)
            {
                curScaleY += speed * curve.Evaluate(time);
                //curScaleY = Mathf.Clamp(curScaleY, 0.0f, finalScaleY);
            }
            

            map.transform.localScale = new Vector2(curScaleX, curScaleY);
            yield return null;
        }
        map.transform.localScale = new Vector2(finalScaleX, finalScaleY);
        isShowing = true;
        MapStateTextMesh.text = "Hide\nMap";
        animIsPlaying = false;
    }

    //Pop in variant 2
    IEnumerator PopIn2()
    {
        animIsPlaying = true;
        map.SetActive(true);
        float time = 0.0f;
        float curScaleX = 0.0f;
        float curScaleY = 0.01f;
        map.transform.localScale = new Vector2(0.01f, 0.01f);
        while (curScaleX < finalScaleX)
        {
            time += Time.deltaTime;
            curScaleX += speed * curve.Evaluate(time);
            //curScaleX = Mathf.Clamp(curScaleX, 0.0f, finalScaleX);

            map.transform.localScale = new Vector2(curScaleX, 0.01f);
            yield return null;
        }
        map.transform.localScale = new Vector2(finalScaleX, 0.01f);
        time = 0.0f;
        while (curScaleY < finalScaleY)
        {
            time += Time.deltaTime;
            curScaleY += speed * curve.Evaluate(time);
            //curScaleY = Mathf.Clamp(curScaleY, 0.0f, finalScaleY);

            map.transform.localScale = new Vector2(finalScaleX, curScaleY);
            yield return null;
        }
        map.transform.localScale = new Vector2(finalScaleX, finalScaleY);
        isShowing = true;
        MapStateTextMesh.text = "Hide\nMap";
        animIsPlaying = false;
    }

    //Pop out variant 2
    IEnumerator PopOut2()
    {
        //It will not play the animation again while the animation is still playing
        animIsPlaying = true;
        map.SetActive(true);
        float time = 0.0f;
        float curScaleX = finalScaleX;
        float curScaleY = finalScaleY;
        map.transform.localScale = new Vector2(finalScaleX, finalScaleY);
        while (curScaleY >= 0.01f)
        {
            time += Time.deltaTime;
            curScaleY -= speed * curve.Evaluate(time);
            //curScaleY = Mathf.Clamp(curScaleY, 0.0f, finalScaleY);

            map.transform.localScale = new Vector2(curScaleX, curScaleY);
            yield return null;
        }
        map.transform.localScale = new Vector2(0.01f, curScaleY);

        time = 0.0f;
        while (curScaleX >= 0.01f)
        {
            time += Time.deltaTime;
            curScaleX -= speed * curve.Evaluate(time);
            curScaleX = Mathf.Clamp(curScaleX, 0.0f, finalScaleX);

            map.transform.localScale = new Vector2(curScaleX, 0.01f);
            yield return null;
        }
        //map.transform.localScale = new Vector2(0.01f, 0.01f);

        isShowing = false;
        map.SetActive(false);
        MapStateTextMesh.text = "Show\nMap";
        animIsPlaying = false;
        //It can now play the animation again
    }
    #endregion
}
