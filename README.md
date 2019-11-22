# 3D Game Programming & Design：UI系统--Quest Log 公告牌

# UI系统概述
UI 即 User Interface（用户界面）的简称。在许多软件中，采用狭义的概念，特指窗体、面板、按钮、文本框等人们熟悉的人机交互元素，及其组织与风格（也称皮肤）。Unity UI 系统采用上述狭义概念。

5.0 及以后 - Unity GUI / UGUI 是面向对象的 UI 系统。所有 UI 元素都是游戏对象，友好的图形化设计界面， 可在场景渲染阶段渲染这些 UI 元素。

- **UGUI 的产生与优势**
	
	随着游戏开发的普及，为了让设计师也能参与参与程序开发，从简单的地图编辑器、菜单编辑器等工具应运而生。设计师甚至不需要程序员帮助，使用这些工具就可直接创造游戏元素，乃至产生游戏程序。除此之外，现代游戏 UI 必须要满足以下要求：
	
	- 跨设备执行，自动适应不同分辨率
	- UI 元素与游戏场景融为一体的交互
	- 支持复杂的布局
	- 多摄像机支持	

	以至于即使优秀的程序员在现代 UI 面前，传统代码驱动的 UI 面临开发效率低下，难以调试等问题。 对于 Unity 平台， 当 NGUI: Next-Gen UI kit 的出现使得不依赖 Unity Pro 功能，使用所见即所得（WYSIWYG）设计工具，集成了 tweening 运动管理系统， 可以制作多数 2D 游戏，直接威胁了 Unity 的生意。 Unity 最终高薪聘了 NGUI 的主设计师，最终又分道扬镳，于是就有了 UGUI，青出于蓝而胜于蓝！
	
	UGUI 的优势：
	
	- 所见即所得（WYSIWYG）设计工具
	- 支持多模式、多摄像机渲染
	- 面向对象的编程
# UGUI 基础
## 画布（Cavas）
画布（Cavas）是绘图区域, 同时是 ui 元素的容器。 容器中 ui 元素及其子 UI 元素都将绘制在其上。 拥有Canvas组件的游戏对象都有一个画布，它空间中的子对象，如果是 UI 元素将渲染在画布上。画布区域在场景视图中显示为矩形。这使得定位UI元素变得非常容易，无需随时显示游戏运行视图。

## UI 布局基础
每个UI元素都被表示为一个矩形，为了相对于 Canvas 和 其他 UI 元素实现定位，Unity 在 Transform 基础上定义了 RectTransform （矩形变换） 支持矩形元素在 2/3D 场景中变换。

## UI 组件与元素
UI 部件都是用 Script 开发的自定义组件。包括在 UI、Layout 和 Rendering 等分类中。

1、可视化组件

可视化组件，在组件 UI 分类中，包括：

- Text：显示的文本的文本区域。可以设置字体，字体样式，字体大小以及文本是否具有丰富的文本功能。
- Image：显示图片的区域。可以设置GUI精灵、色彩。
- Raw Image：原始图像采用纹理，进行 UV 矩形贴图。
- Mask：Mask不是一个可见的UI控件。遮罩将子元素限制（即“掩蔽”）为父元素的形状。如果孩子比父控件大，那么只有适合父节点遮罩的部分是可见的。
Effects：应用各种简单的效果，例如简单的投影或轮廓。

2、UI 交互元素

UI 交互元素是 GameObject，它拥有 UI 交互组件、UI可视化组件、及相关组件的组合，以及一些 UI 子元素构成，以方便用户在设计场景中创建交互界面。

例如：Button 元素，除了 UI 必须拥有的 RectTransform 和 Canvas renderer 外，还有 Image 和 Button 组件，以及一个 Text 子元素。

 - Button 
 - Toggle 
 - Toggle Group 
 - Slider 
 - Scrollbar
 -  Dropdown 
 - Input Field
 - Scroll Rect (Scroll View)

其他更多关于UI系统的基础操作知识，请移步[Unity3d的官方文档](https://docs.unity3d.com/Manual/UISystem.html)。
# 编程实践
## 作业要求
**UI 效果制作（你仅需要实现以下效果之一）**

进入 NGUI 官方网站，使用 UGUI 实现以下效果
- Inventory 背包系统
- Quest Log 公告牌
- Scroll View 选择板
以上例子需要使用 Unity web player， 仅支持以下操作系统与浏览器，参见官方下载
Windows 版 IE11
Mac OS X 10.7 Safari
出现界面需要等待较长时间，打开页面让它慢慢加载

我选择的题目是实现Quest Log 公告牌。

##  基本配置
按官方手册，EventSystem 在一个场景中 有且仅能有一个，它将游戏操纵杆、键盘、鼠标、触摸屏、触摸屏与 UI 对象交互事件，如 Click，MouseMOver，DragEnter 等等，传递给游戏对象对应的行为组件。

菜单通常由一个 Canvas 和 若干 Panel 组成的，所有 UI 元素组成一个树形结构。

在canvas下新建一个滚动视图scoll view。然后在Scroll View -> Viewport -> Content下添加垂直列表组件vertical layout group和Button1，2，3以及对应的Text1，2，3用于显示公告的按钮和文字。

![在这里插入图片描述](https://img-blog.csdnimg.cn/20191123013136799.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MDM3NzY5MQ==,size_16,color_FFFFFF,t_70)

在button和text上分别设置要显示的文字内容，文字格式等等。

![在这里插入图片描述](https://img-blog.csdnimg.cn/20191123013126222.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MDM3NzY5MQ==,size_16,color_FFFFFF,t_70)

之后可以直接通过UGUI对公告牌的大小位置以及其他属性进行设置。调整垂直列表中的间距还有自适应宽高等的属性。

![在这里插入图片描述](https://img-blog.csdnimg.cn/20191123013159259.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MDM3NzY5MQ==,size_16,color_FFFFFF,t_70)

最后我们可以对公告牌和整个canvas分别添加背景图片，这里我就是在网上找的图片素材，然后添加到asset的img文件夹下即可，唯一要注意的是，要将这些背景图片的Texture Type变为Sprite(2D and UI)，才能够添加成功。

![在这里插入图片描述](https://img-blog.csdnimg.cn/20191123014644576.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MDM3NzY5MQ==,size_16,color_FFFFFF,t_70)

## 代码分析
这一次的作业因为很多部分都是用UGUI直接可以操作的，所以代码比较简单，主要就是实现公告文字的隐藏和展开。

这里我们使用了C#的协程接口IEnumerator，它允许你为自己的集合类型编写枚举器，IEnumerator迭代器和yield关键字需要配合使用。Unity协程长的类似于线程,但却不是线程。因为协程仍然是在主线程中执行，且在使用时不用考虑同步与锁的问题。协程只是控制代码等到特定的时机后再执行后续步骤。我们可以写一段顺序的代码，标明哪里需要暂停，然后在下一帧或者一段时间后，系统会继续执行这段代码。通过每帧来改变文本的角度和文本的高度，来实现隐藏和展开的效果。

完整代码如下：
```javascript
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
        // 判断文本是选择隐藏还是显示
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
```
完成代码后，我们需要把它挂载到我们的每一个button之上，并把每个button对应的text拖到相应的栏目里面即可。
## 游戏界面效果
隐藏文本：

![在这里插入图片描述](https://img-blog.csdnimg.cn/2019112301195659.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MDM3NzY5MQ==,size_16,color_FFFFFF,t_70)

展开文本：

![在这里插入图片描述](https://img-blog.csdnimg.cn/20191123012009701.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MDM3NzY5MQ==,size_16,color_FFFFFF,t_70)

- 最后

[视频链接](https://pan.baidu.com/s/1PewB6taeWr0Ze8rle1Iphg)


