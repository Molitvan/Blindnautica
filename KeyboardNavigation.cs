using MelonLoader;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Blindnautica
{
    public class KeyboardNavigation
    {
        public static void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                NavigateWithKeyboard(Direction.Up);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                NavigateWithKeyboard(Direction.Down);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                NavigateWithKeyboard(Direction.Left);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                NavigateWithKeyboard(Direction.Right);
            }
            else if (Input.GetKeyDown(KeyCode.Tab))
            {
                NavigateWithKeyboard(Direction.Right);
            }
            else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Tab))
            {
                NavigateWithKeyboard(Direction.Left);
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                ClickSelectedElement();
            }
        }

        private static void NavigateWithKeyboard(Direction direction)
        {
            EventSystem eventSystem = EventSystem.current;

            if (eventSystem != null)
            {
                GameObject selectedObject = eventSystem.currentSelectedGameObject;

                if (selectedObject != null)
                {
                    switch (direction)
                    {
                        case Direction.Up:
                            eventSystem.SetSelectedGameObject(selectedObject.GetComponent<Selectable>().FindSelectableOnUp().gameObject);
                            break;
                        case Direction.Down:
                            eventSystem.SetSelectedGameObject(selectedObject.GetComponent<Selectable>().FindSelectableOnDown().gameObject);
                            break;
                        case Direction.Left:
                            eventSystem.SetSelectedGameObject(selectedObject.GetComponent<Selectable>().FindSelectableOnLeft().gameObject);
                            break;
                        case Direction.Right:
                            eventSystem.SetSelectedGameObject(selectedObject.GetComponent<Selectable>().FindSelectableOnRight().gameObject);
                            break;
                    }
                }
            }
        }

        private static void ClickSelectedElement()
        {
            EventSystem eventSystem = EventSystem.current;

            if (eventSystem != null)
            {
                GameObject selectedObject = eventSystem.currentSelectedGameObject;

                if (selectedObject != null)
                {
                    ExecuteEvents.Execute(selectedObject, new PointerEventData(eventSystem), ExecuteEvents.pointerClickHandler);
                }
            }
        }

        private enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
    }
}
