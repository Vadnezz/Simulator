using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
public class TeleportOnCollision : MonoBehaviour
{
    
    public Vector3 startPosition; // ��������� ������� ��� ������������ 
    private void Start()
    {
        // ������ ��������� ������� ��������� ��� ������ ���� 
        startPosition = transform.position; 
    }
private void OnCollisionEnter(Collision collision)
{
    // ���������, ���������� �� �������� � ��������, ������� ��� "Teleport" 
    if (collision.gameObject.tag == "Teleport")
    {
        // ���� ��, ������������� ��� ������� � ��������� ������� 
        transform.position = new Vector3( 0.001420928f , -0.007769636f , -0.0303386f); 
        }
    }
}