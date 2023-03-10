using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TileController : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public Button tileButton;

    public void OnTileClick()
    {
        if (textMesh.text == "")
        {
            textMesh.text = "0";
        }
        else if (textMesh.text=="0")
        {
            textMesh.text = "1";
        }
        else
        {
            textMesh.text = "";
        }
    }
}
