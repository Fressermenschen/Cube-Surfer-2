using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove instance;

    public LayerMask groundLayer;
    private TrailRenderer tr;
    [HideInInspector] public Animator anim;
    public Camera cam;
    public List<GameObject> cubes = new List<GameObject>();
    private Vector3 firstTouchPosition;
    private Vector3 curTouchPosition;
    public float speed;
    private float sensitivityMultiplier = 0.01f;
    private float finalTouchX;
    private float xBound = 2f;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (GameManager.instance.isGameOver || GameManager.instance.isGameWin || !GameManager.instance.isGameStart)
        {
            return;
        }

        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            firstTouchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            curTouchPosition = Input.mousePosition;

            Vector2 touchDelta = (curTouchPosition - firstTouchPosition);

            finalTouchX = (transform.position.x + (touchDelta.x * sensitivityMultiplier));
            finalTouchX = Mathf.Clamp(finalTouchX, -xBound, xBound);

            transform.position = new Vector3(finalTouchX, transform.position.y, transform.position.z);

            firstTouchPosition = Input.mousePosition;
        }
    }
}
