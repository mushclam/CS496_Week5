using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropSystem : MonoBehaviour{

    private Camera m_cam;
    private Canvas m_canvas;

    private void Start()
    {
        m_cam = GetComponentInChildren<Camera>();
        m_canvas = GetComponentInChildren<Canvas>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 movePos;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                m_canvas.transform as RectTransform,
                Input.mousePosition, m_cam,
                out movePos);

            Vector3 mousePos = m_canvas.transform.TransformPoint(movePos);

            string test = m_canvas.transform.name;
            Debug.Log("Test: " + test);
        }
    }
}
