﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float minX;
    public float maxX;
    public bool autoPlay = false;
    private Ball ball;

    private void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }
    // Update is called once per frame
    void Update ()
    {
        if (autoPlay == false)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }
    }

    void MoveWithMouse()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        mousePosInBlocks = Mathf.Clamp(mousePosInBlocks, minX, maxX);
        paddlePos.x = mousePosInBlocks;
        this.transform.position = paddlePos;
    }

    void AutoPlay()
    {
        //move the mouse to the position of the ball
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        float ballPosInBlocks = ball.transform.position.x;
        ballPosInBlocks = Mathf.Clamp(ballPosInBlocks, minX, maxX);
        paddlePos.x = ballPosInBlocks;
        this.transform.position = paddlePos;
    }

}
