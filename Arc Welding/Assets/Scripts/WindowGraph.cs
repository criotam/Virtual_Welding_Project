using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowGraph : MonoBehaviour {

    RectTransform GraphContainer;
    [SerializeField] Sprite CircleSprite;

    private RectTransform LabelTempelateX, LabelTempelateY;

    private void Awake()
    {
        GraphContainer = transform.Find("GraphContainer").GetComponent<RectTransform>();
        LabelTempelateX = GraphContainer.Find("LabelTempelateX").GetComponent<RectTransform>();
        LabelTempelateY = GraphContainer.Find("LabelTempelateY").GetComponent<RectTransform>();
        //List<float> ValueList = new List<float>() { 5, 10, 11, 1, 5, 18, 20, 28, 49, 68, 89 };
        //ShowGraph(ValueList);
    }

    private GameObject CreateCircle(Vector2 anchorPosition)
    {
        GameObject gameobject = new GameObject("circle", typeof(Image));
        gameobject.transform.SetParent(GraphContainer, false);
        gameobject.GetComponent<Image>().sprite = CircleSprite;
        RectTransform rectTransform = gameobject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchorPosition;
        rectTransform.sizeDelta = new Vector2(11f, 11f);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        gameobject.GetComponent<Image>().color = Color.blue;
        return gameobject;
    }

    public void ShowSpeedGraph(List<float> ValueList)
    {
        float xsize = 20f, graphHeight = GraphContainer.sizeDelta.y;
        //float yMaximum = Mathf.RoundToInt(Mathf.Max(ValueList.ToArray()))';
        float yMaximum = 30;
        //float yOffset = -20f;
        Debug.Log("Graph heigh: "+graphHeight.ToString());
        GameObject lastCircleGameObject = null;
        for (int i = 0; i< ValueList.Count; ++i)
        {
            float xpos = xsize + i * xsize;
            float ypos = (ValueList[i] / yMaximum) * graphHeight;
            if (ypos > graphHeight)
            {
                ypos = graphHeight;
            }
            GameObject circleGameObject =  CreateCircle(new Vector2(xpos, ypos));
            if (lastCircleGameObject != null)
            {
                CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition,
                    circleGameObject.GetComponent<RectTransform>().anchoredPosition);
            }
            lastCircleGameObject = circleGameObject;

            RectTransform LabelX = Instantiate(LabelTempelateX);
            LabelX.SetParent(GraphContainer);
            LabelX.gameObject.SetActive(true);
            LabelX.anchoredPosition = new Vector2(xpos, -10f);
            LabelX.GetComponent<Text>().text = i.ToString();
            LabelX.localScale = new Vector3(1, 1, 1);
            LabelX.localPosition = new Vector3(LabelX.localPosition.x, LabelX.localPosition.y, 0f);
        }

        int seperatorCount = 10;
        for (int i = 0; i<= seperatorCount; ++i) { 
            RectTransform LabelY = Instantiate(LabelTempelateY);
            LabelY.SetParent(GraphContainer);
            LabelY.gameObject.SetActive(true);

            float normalizedValue = i*1f / seperatorCount;

            LabelY.anchoredPosition = new Vector2(-10f, normalizedValue*graphHeight);
            LabelY.GetComponent<Text>().text = Mathf.RoundToInt(normalizedValue*yMaximum).ToString();
            LabelY.localScale = new Vector3(1, 1, 1);
            LabelY.localPosition = new Vector3(LabelY.localPosition.x, LabelY.localPosition.y, 0f);
        }

    }

    private void CreateDotConnection(Vector2 dotpos1, Vector2 dotpos2)
    {
        GameObject gameobject = new GameObject("dotConnection", typeof(Image));
        gameobject.transform.SetParent(GraphContainer, false);
        gameobject.GetComponent<Image>().color = Color.black;
        RectTransform rectTransform = gameobject.GetComponent<RectTransform>();
        float distance = Vector3.Distance(dotpos1, dotpos2);
        Vector2 dir = (dotpos2 - dotpos1).normalized; 
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 3f);
        rectTransform.anchoredPosition = dotpos1 + dir * distance * .5f;

        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0)
            n += 360;
        rectTransform.localEulerAngles = new Vector3(0,0, n);

    }
}
