using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedoUndoManager : MonoBehaviour
{
    private List<RedoUndoBlock> list;
    private int top;

    public static RedoUndoManager Instance { get; private set; }

    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        list = new List<RedoUndoBlock>();
        top = -1;
    }

    public void OnAction(int x,int y ,int oldValue,int newValue)
    {
        RedoUndoBlock temp = new RedoUndoBlock(x, y, oldValue,newValue);
        if(list.Count-1 != top)
        {
            list.RemoveRange(top + 1, list.Count - top - 1);
            
        }
        list.Add(temp);
        top++;
    }

    public void Undo()
    {
        if (top != -1)
        {
            BoardController.Instance.RestoreTileValue(list[top].x, list[top].y, list[top].oldValue);
            top--;
        }
        
    }
    public void Redo()
    {
        if (top < list.Count - 1)
        {
            top++;
            BoardController.Instance.RestoreTileValue(list[top].x, list[top].y, list[top].newValue);
        }
    }

}

public class RedoUndoBlock
{
    public int x;
    public int y;
    public int oldValue;
    public int newValue;

    public RedoUndoBlock(int x, int y, int oldValue,int newValue)
    {
        this.x = x;
        this.y = y;
        this.oldValue = oldValue;
        this.newValue = newValue;
    }
}