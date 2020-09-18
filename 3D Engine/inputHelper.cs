using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace _3D_Engine
{
    public enum MouseButtons { LeftButton, RightButton }

    public class InputHelper
    {
        public KeyboardState currentKeyboardState = new KeyboardState();
        public static MouseState currentMouseState = new MouseState();
        public KeyboardState lastKeyboardState = new KeyboardState();
        public MouseState lastMouseState = new MouseState();
        private int previousScrollValue = currentMouseState.ScrollWheelValue;
        private int currentScrollValue = currentMouseState.ScrollWheelValue;
        public Vector2 cursorPos = new Vector2(0, 0);

        public InputHelper() { }

        public void Update()
        {
            previousScrollValue = currentMouseState.ScrollWheelValue;

            lastKeyboardState = currentKeyboardState;
            lastMouseState = currentMouseState;

            currentKeyboardState = Keyboard.GetState();
            currentMouseState = Mouse.GetState();
            currentScrollValue = currentMouseState.ScrollWheelValue;

            //track cursor position
            cursorPos.X = currentMouseState.X;
            cursorPos.Y = currentMouseState.Y;
        }

        //check for keyboard key press, hold, and release
        public bool IsNewKeyPress(Keys key)
        {
            return (currentKeyboardState.IsKeyDown(key) &&
                lastKeyboardState.IsKeyUp(key));
        }

        public bool IsKeyDown(Keys key)
        { return (currentKeyboardState.IsKeyDown(key)); }

        public bool IsNewKeyRelease(Keys key)
        {
            return (lastKeyboardState.IsKeyDown(key) &&
                currentKeyboardState.IsKeyUp(key));
        }

        public bool IsMouseWheelScrolledUp()
        {
            return currentScrollValue > previousScrollValue;
        }

        public bool IsMouseWheelScrolledDown()
        {
            return currentScrollValue < previousScrollValue;
        }

        public bool IsNewMouseButtonPress(MouseButtons button)
        {   //check to see the mouse button was pressed
            if (button == MouseButtons.LeftButton)
            {
                return (currentMouseState.LeftButton == ButtonState.Pressed &&
                    lastMouseState.LeftButton == ButtonState.Released);
            }
            else if (button == MouseButtons.RightButton)
            {
                return (currentMouseState.RightButton == ButtonState.Pressed &&
                    lastMouseState.RightButton == ButtonState.Released);
            }
            else { return false; }
        }

        public bool IsNewMouseButtonRelease(MouseButtons button)
        {   //check to see the mouse button was released
            if (button == MouseButtons.LeftButton)
            {
                return (lastMouseState.LeftButton == ButtonState.Pressed &&
                    currentMouseState.LeftButton == ButtonState.Released);
            }
            else if (button == MouseButtons.RightButton)
            {
                return (lastMouseState.RightButton == ButtonState.Pressed &&
                    currentMouseState.RightButton == ButtonState.Released);
            }
            else { return false; }
        }

        public Boolean IsMouseButtonDown(MouseButtons button)
        {   //check to see if the mouse button is being held down
            if (button == MouseButtons.LeftButton)
            { return (currentMouseState.LeftButton == ButtonState.Pressed); }
            else if (button == MouseButtons.RightButton)
            { return (currentMouseState.RightButton == ButtonState.Pressed); }
            else { return false; }
        }
    }
}
