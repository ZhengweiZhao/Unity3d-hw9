using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour {

    // 分别对应按钮和文本内容
    private Button button;
    public Text text;

    private float height; // 公告文本的高度
    private int frame = 20;    // 公告内容变化帧数

    void Start()
    {
        // 获取button，添加监听事件
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(showOrHide);

        // 并获取公告文本的高度，以便还原
        height = text.rectTransform.sizeDelta.y;
    }

    void showOrHide()
    {
        // 判断公告文本是否激活，分别选择隐藏或显示
        if (text.gameObject.activeSelf)
            StartCoroutine(hide());
        else
            StartCoroutine(show());

    }

    IEnumerator hide()
    {
        float h = height;

        for (int i = 0; i < frame; i++)
        {
            h -= height / frame;
            text.rectTransform.sizeDelta = new Vector2(text.rectTransform.sizeDelta.x, h);
            // 在这停顿，下一帧再执行
            yield return null;
        }

        text.gameObject.SetActive(false);
        // 禁用文本
    }

    IEnumerator show()
    {
        float h = 0;
        text.gameObject.SetActive(true);
        // 激活文本

        for (int i = 0; i < frame; i++)
        {
            h += height / frame;            
            text.rectTransform.sizeDelta = new Vector2(text.rectTransform.sizeDelta.x, h);
            // 在这停顿，下一帧再执行
            yield return null;
        }

    }
}
