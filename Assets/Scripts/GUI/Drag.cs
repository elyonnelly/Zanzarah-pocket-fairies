﻿using UnityEngine;

namespace Assets.Scripts.GUI
{
    public class Drag : MonoBehaviour
    {
        private Vector3 initialPosition;
        private Vector3 screenPoint;
        private Vector3 offset;

        void OnMouseDown()
        {
            initialPosition = transform.position;
            //Instantiate(gameObject.tag == "Active Fairy" ? Resources.Load<GameObject>("Fairy") : gameObject, initialPosition, Quaternion.identity).transform.SetParent(GameObject.FindGameObjectWithTag("List of fairies").transform);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            //if (gameObject.transform.position != initialPosition)
            //{
                Instantiate(gameObject.tag == "Active Fairy" ? Resources.Load<GameObject>("Fairy") : gameObject, initialPosition, Quaternion.identity);//.transform.SetParent(Parent.transform);

            //}
        }

        void OnMouseUp()
        {
            Destroy(gameObject);
        }
        void OnMouseDrag()
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
            //Debug.Log(transform.position);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("Collision");
            if (collision.gameObject.tag == "Allow Fairy")
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = collision.gameObject.GetComponent<SpriteRenderer>().sprite;
                //TODO очень плохо рушить один объект изнутри другого, перенести в другое место в коде
                Destroy(collision.gameObject);
            }
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            Debug.Log("Trigger");
        }
    }
}
