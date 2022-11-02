using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Control : MonoBehaviour
{
    public static string name;
    public static TextMeshProUGUI Text;
    void Start()
    {
        Text = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        Text.text = name + " died!! You win";
    }
    public void Exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
