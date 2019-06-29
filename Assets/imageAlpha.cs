using UnityEngine;
using UnityEngine.UI;

public class imageAlpha : MonoBehaviour
{
    Image m_Image;
    Color tempColor;

    void Start()
    {
        m_Image = GetComponent<Image>();
	tempColor = m_Image.color;
	tempColor.a = 0.8f;
	m_Image.color = tempColor;
    }

    void Update()
    {

    }
}