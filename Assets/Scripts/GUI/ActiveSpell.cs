﻿using UnityEngine;

namespace Assets.Scripts.GUI
{
    public class ActiveSpell : MonoBehaviour
    {
        public bool IsEmpty;
        public int Number;

        public bool isDrag;

        private Vector3 initialPosition;
        private Vector3 screenPoint;
        private Vector3 offset;

        private void OnMouseDown()
        {
            if (IsEmpty)
            {
                return;
            }

            if (!isDrag)
            {
                initialPosition = transform.position;
                isDrag = true;
            }
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2);

            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }

        private void OnMouseUp()
        {
            if (IsEmpty)
            {
                return;
            }

            var fairy = gameObject.transform.GetComponentInParent<ActiveFairy>();
            if (!IsEmpty)
            {
                EventAggregator.PublishRemovalSpell(fairy.Number, Number, gameObject.name);
            }

            MakeEmpty();
        }

        private void OnMouseDrag()
        {
            if (IsEmpty)
            {
                return;
            }

            var curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            var curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }

        private void MakeEmpty()
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/EmptySpell");
            gameObject.name = $"ActiveSpell{Number}";
            transform.position = initialPosition;
            IsEmpty = true;
            isDrag = false;
        }
    }
}