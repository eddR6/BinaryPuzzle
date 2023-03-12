using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TileController : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public Button tileButton;
    public int tileValue;

    public void OnTileClick()
    {
        if (textMesh.text == "")
        {
            textMesh.text = "0";
            tileValue = 0;
            BoardController.Instance.CheckForWin();
        }
        else if (textMesh.text=="0")
        {
            textMesh.text = "1";
            tileValue = 1;
            BoardController.Instance.CheckForWin();
        }
        else
        {
            textMesh.text = "";
            tileValue = -1;
        }
    }
}
