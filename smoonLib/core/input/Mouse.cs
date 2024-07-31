using SDL2;

namespace smoonLib.core;

public static class Mouse
{
    internal static bool isButtonClicked;
    internal static bool isButtonDown = false;
    internal static bool isButtonUp;

    public static Vector2 ScreenPosition { get; private set; }
    public static Vector2 WorldPosition { get; private set; }

    internal static void UpdatePosition()
    {
        SDL.SDL_GetMouseState(out var mouseX, out var mouseY);
        ScreenPosition = new Vector2(mouseX, mouseY);

        WorldPosition = ScreenPosition;
    }
    
    public static bool GetButton(MouseButton mouseButton = MouseButton.ANY)
    {
        if (!isButtonDown) return false;
        
        if(mouseButton != MouseButton.ANY)
            return EventSystem.MouseButton == mouseButton;
        return true;
    }
    
    public static bool GetButtonDown(MouseButton mouseButton = MouseButton.ANY)
    {
        if (!isButtonClicked) return false;

        isButtonClicked = false;
        if(mouseButton != MouseButton.ANY)
            return EventSystem.MouseButton == mouseButton;
        return true;
    }
    
    public static bool GetButtonUp(MouseButton mouseButton = MouseButton.ANY)
    {
        if (!isButtonUp) return false;
        
        isButtonUp = false;
        if(mouseButton != MouseButton.ANY)
            return EventSystem.MouseButton == mouseButton;
        return true;
    }
}

public enum MouseButton : uint
{
    ANY,
    LEFT = SDL.SDL_BUTTON_LEFT,
    RIGHT = SDL.SDL_BUTTON_RIGHT,
    MIDDLE = SDL.SDL_BUTTON_MIDDLE,
}