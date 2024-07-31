using SDL2;

namespace smoonLib.core;

internal static class EventSystem
{
    internal static MouseButton MouseButton { get; private set; }
    internal static readonly bool[] KeysPressed = new bool[(int)SDL.SDL_Scancode.SDL_NUM_SCANCODES];
    internal static readonly bool[] PreviousKeysPressed = new bool[(int)SDL.SDL_Scancode.SDL_NUM_SCANCODES];

    internal static void CleanEvent()
    {
        Array.Copy(KeysPressed, PreviousKeysPressed, KeysPressed.Length);
    }
    
    internal static void UpdateEvent()
    {
        while (SDL.SDL_PollEvent(out SDL.SDL_Event e) != 0)
        {
            switch (e.type)
            {
                case SDL.SDL_EventType.SDL_QUIT:
                    App.CloseApp();
                    break;
                case SDL.SDL_EventType.SDL_KEYDOWN:
                    KeysPressed[(int)e.key.keysym.scancode] = true;
                    KeysPressed[1] = true;
                    break;
                case SDL.SDL_EventType.SDL_KEYUP:
                    KeysPressed[(int)e.key.keysym.scancode] = false;
                    KeysPressed[1] = false;
                    break;
                case SDL.SDL_EventType.SDL_MOUSEBUTTONDOWN:
                    MouseButton = (MouseButton)e.button.button;
                    Mouse.isButtonClicked = true;
                    Mouse.isButtonUp = false;
                    Mouse.isButtonDown = true;
                    break;
                case SDL.SDL_EventType.SDL_MOUSEBUTTONUP:
                    MouseButton = (MouseButton)e.button.button;
                    Mouse.isButtonUp = true;
                    Mouse.isButtonDown = false;
                    break;
            }
        }
    }
}