using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
public class TeleportOnCollision : MonoBehaviour
{
    
    public Vector3 startPosition; // Начальная позиция для телепортации 
    private void Start()
    {
        // Задаем начальную позицию персонажа при старте игры 
        startPosition = transform.position; 
    }
private void OnCollisionEnter(Collision collision)
{
    // Проверяем, столкнулся ли персонаж с объектом, имеющим тег "Teleport" 
    if (collision.gameObject.tag == "Teleport")
    {
        // Если да, телепортируем его обратно в начальную позицию 
        transform.position = new Vector3( 0.001420928f , -0.007769636f , -0.0303386f); 
        }
    }
}