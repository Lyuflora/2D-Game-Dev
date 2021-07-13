using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private BoxCollider2D boxcollider;
    [SerializeField]
    private Vector3 deltaMove;
    private RaycastHit2D hit;

    void Start()
    {
        boxcollider = GetComponent<BoxCollider2D>();

    }

    private void FixedUpdate()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        deltaMove = new Vector3(x, y, 0f);
        
        if (deltaMove.x < 0)
        {
            transform.localScale = Vector3.one;
        }else if (deltaMove.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        hit = Physics2D.BoxCast(transform.position, boxcollider.size, 0, new Vector2(0, deltaMove.y), Mathf.Abs(deltaMove.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            // ´íÎóµÄÐ´·¨£ºtransform.position += deltaMove;
            transform.Translate(0, deltaMove.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxcollider.size, 0, new Vector2(deltaMove.x,0), Mathf.Abs(deltaMove.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(deltaMove.x * Time.deltaTime, 0, 0);
        }

    }
}
