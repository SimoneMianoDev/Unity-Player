using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;

    private void Start()   // La funzione start è una funzione speciale-> le robe scritte al suo interno partono all'avvio in automatico 
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()  // La Funzione Speciale FixedUpdate si aggiorna ogni sigolo frame 
    {

        float x = Input.GetAxisRaw("Horizontal"); // Prende in input Movimento Orizzontale
        float y = Input.GetAxisRaw("Vertical");  // Prende in input Movimento Verticale

        // Reset moveDelta
        moveDelta = new Vector3(x, y, 0);

        //Direzione del personaggio (Viso)
        if (moveDelta.x > 0)
            transform.localScale = new Vector3(1, 1, 1);  // Viso verso destra

        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1); //Viso verso Sinistra

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

        if (hit.collider == null)
        {
            //Movimento personaggio
            transform.Translate(0,moveDelta.y * Time.deltaTime,0);

        }
        
        
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));


        if (hit.collider == null)
        {
            //Movimento personaggio
            transform.Translate(moveDelta.x * Time.deltaTime, 0,0);

        }



    }
}
