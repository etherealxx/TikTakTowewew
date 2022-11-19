using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    private int turn = 0;
    private string[] papan = new string[9];
    private bool gameOver = false;
    public TextMeshProUGUI announcementText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void KetikaNodeDiKlik(TextMeshProUGUI _textObj)
    {
        if (gameOver == false)
        {
            var parent = _textObj.transform.parent.gameObject;
            int parentName = int.Parse(parent.name);


            if (turn == 0)
            {
                _textObj.text = "X";
                papan[parentName - 1] = "X";
                turn = 1;
            }
            else
            {
                _textObj.text = "O";
                papan[parentName - 1] = "O";
                turn = 0;
            }

            parent.GetComponent<Button>().interactable = false;

            CheckGame();
        }
    }

    private void CheckGame()
    {
        if(CheckVertical("X") || CheckHorizontal("X") || CheckDiagonal("X"))
        {
            announcementText.text ="Player X menang coy";
            gameOver = true;
        }
        else if (CheckVertical("O") || CheckHorizontal("O") || CheckDiagonal("O"))
        {
            announcementText.text = "Player O menang coy";
            gameOver = true;
        }
        else if  (CheckDraw())
        {
            announcementText.text = "Seri coy";
            gameOver = true;
        }
    }

    private bool CheckDraw()
    {
        for (int i = 0; i < papan.Length; i++)
        {
            if (papan[i] == null)
            {
                return false;
            }
        }

        return true;
    }

    private bool CheckVertical(string _node)
    {
        if (papan[0] == _node && papan[3] == _node && papan[6] == _node)
        {
            return true;
        }
        else if (papan[1] == _node && papan[4] == _node && papan[7] == _node)
        {
            return true;
        }
        else if (papan[2] == _node && papan[5] == _node && papan[8] == _node)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckHorizontal(string _node)
    {
        if (papan[0] == _node && papan[1] == _node && papan[2] == _node)
        {
            return true;
        }
        else if (papan[3] == _node && papan[4] == _node && papan[5] == _node)
        {
            return true;
        }
        else if (papan[6] == _node && papan[7] == _node && papan[8] == _node)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckDiagonal(string _node)
    {
        if (papan[0] == _node && papan[4] == _node && papan[8] == _node)
        {
            return true;
        }
        else if (papan[2] == _node && papan[4] == _node && papan[6] == _node)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
