using System;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    public Rigidbody2D rb; // rigidbody referansı
    public float speed = 5f; // hareket hızı
    public float jumpForce = 10f; // zıplama kuvveti
    float horizontalInput;
    bool jumpInput;

    public bool isGrounded = false; // yerde mi değil mi kontrolü

    // diğer değişkenler buraya gelecek
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal"); // yatay girdi (A ve D tuşları veya sol ve sağ oklar)
        jumpInput = Input.GetKeyDown(KeyCode.Space); // zıplama girdisi (boşluk tuşu)
        // diğer kodlar buraya gelecek
    
     // zıplama için AddForce kullanımı
            
       if (jumpInput && isGrounded) // zıplama girdisi varsa ve yerdeyse
       {
           rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // rigidbody'ye yukarı yönde bir kuvvet uygula
       }
    }

    void FixedUpdate()
    {
        // yatay hareket için MovePosition kullanımı
        Vector2 position = rb.velocity; // mevcut pozisyon
        position.x = horizontalInput * speed; // yatay girdiye göre pozisyonu güncelleme
        rb.velocity = position; 

   
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground")) // diğer collider yer etiketine sahipse
        {
            isGrounded = true; // yerde olduğunu belirle
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground")) // diğer collider yer etiketine sahipse
        {
            isGrounded = false; // yerde olmadığını belirle
        }
    }
}