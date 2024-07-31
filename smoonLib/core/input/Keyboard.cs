using SDL2;

namespace smoonLib.core;

public static class Keyboard
{
    public static bool GetKey(KeyCode keyCode)
    {
        bool prevKeyState = EventSystem.PreviousKeysPressed[(int)keyCode];
        bool currentKeyState = EventSystem.KeysPressed[(int)keyCode];
        
        return prevKeyState || currentKeyState;
    }
    
    public static bool GetKeyDown(KeyCode keyCode)
    {
        bool prevKeyState = EventSystem.PreviousKeysPressed[(int)keyCode];
        bool currentKeyState = EventSystem.KeysPressed[(int)keyCode];
        
        return !prevKeyState && currentKeyState;
    }
    
    public static bool GetKeyUp(KeyCode keyCode)
    {
        bool prevKeyState = EventSystem.PreviousKeysPressed[(int)keyCode];
        bool currentKeyState = EventSystem.KeysPressed[(int)keyCode];
        
        return prevKeyState && !currentKeyState;
    }
}

public enum KeyCode : byte
{
    ANY = 1,
    SPACE = SDL.SDL_Scancode.SDL_SCANCODE_SPACE,
    A = SDL.SDL_Scancode.SDL_SCANCODE_A,
    B = SDL.SDL_Scancode.SDL_SCANCODE_B,
    C = SDL.SDL_Scancode.SDL_SCANCODE_C,
    D = SDL.SDL_Scancode.SDL_SCANCODE_D,
    E = SDL.SDL_Scancode.SDL_SCANCODE_E,
    F = SDL.SDL_Scancode.SDL_SCANCODE_F,
    G = SDL.SDL_Scancode.SDL_SCANCODE_G,
    H = SDL.SDL_Scancode.SDL_SCANCODE_H,
    I = SDL.SDL_Scancode.SDL_SCANCODE_I,
    J = SDL.SDL_Scancode.SDL_SCANCODE_J,
    K = SDL.SDL_Scancode.SDL_SCANCODE_K,
    L = SDL.SDL_Scancode.SDL_SCANCODE_L,
    M = SDL.SDL_Scancode.SDL_SCANCODE_M,
    N = SDL.SDL_Scancode.SDL_SCANCODE_N,
    O = SDL.SDL_Scancode.SDL_SCANCODE_O,
    P = SDL.SDL_Scancode.SDL_SCANCODE_P,
    Q = SDL.SDL_Scancode.SDL_SCANCODE_Q,
    R = SDL.SDL_Scancode.SDL_SCANCODE_R,
    S = SDL.SDL_Scancode.SDL_SCANCODE_S,
    T = SDL.SDL_Scancode.SDL_SCANCODE_T,
    U = SDL.SDL_Scancode.SDL_SCANCODE_U,
    V = SDL.SDL_Scancode.SDL_SCANCODE_V,
    W = SDL.SDL_Scancode.SDL_SCANCODE_W,
    X = SDL.SDL_Scancode.SDL_SCANCODE_X,
    Y = SDL.SDL_Scancode.SDL_SCANCODE_Y,
    Z = SDL.SDL_Scancode.SDL_SCANCODE_Z,
    K0 = SDL.SDL_Scancode.SDL_SCANCODE_0,
    K1 = SDL.SDL_Scancode.SDL_SCANCODE_1,
    K2 = SDL.SDL_Scancode.SDL_SCANCODE_2,
    K3 = SDL.SDL_Scancode.SDL_SCANCODE_3,
    K4 = SDL.SDL_Scancode.SDL_SCANCODE_4,
    K5 = SDL.SDL_Scancode.SDL_SCANCODE_5,
    K6 = SDL.SDL_Scancode.SDL_SCANCODE_6,
    K7 = SDL.SDL_Scancode.SDL_SCANCODE_7,
    K8 = SDL.SDL_Scancode.SDL_SCANCODE_8,
    K9 = SDL.SDL_Scancode.SDL_SCANCODE_9,
    F1 = SDL.SDL_Scancode.SDL_SCANCODE_F1,
    F2 = SDL.SDL_Scancode.SDL_SCANCODE_F2,
    F3 = SDL.SDL_Scancode.SDL_SCANCODE_F3,
    F4 = SDL.SDL_Scancode.SDL_SCANCODE_F4,
    F5 = SDL.SDL_Scancode.SDL_SCANCODE_F5,
    F6 = SDL.SDL_Scancode.SDL_SCANCODE_F6,
    F7 = SDL.SDL_Scancode.SDL_SCANCODE_F7,
    F8 = SDL.SDL_Scancode.SDL_SCANCODE_F8,
    F9 = SDL.SDL_Scancode.SDL_SCANCODE_F9,
    F10 = SDL.SDL_Scancode.SDL_SCANCODE_F10,
    F11 = SDL.SDL_Scancode.SDL_SCANCODE_F11,
    F12 = SDL.SDL_Scancode.SDL_SCANCODE_F12,
    ESC = SDL.SDL_Scancode.SDL_SCANCODE_ESCAPE,
    LSHIFT = SDL.SDL_Scancode.SDL_SCANCODE_LSHIFT,
    RSHIFT = SDL.SDL_Scancode.SDL_SCANCODE_RSHIFT,
    LALT = SDL.SDL_Scancode.SDL_SCANCODE_LALT,
    RALT = SDL.SDL_Scancode.SDL_SCANCODE_RALT,
    TAB = SDL.SDL_Scancode.SDL_SCANCODE_TAB,
    ENTER = SDL.SDL_Scancode.SDL_SCANCODE_RETURN,
    BACKSPACE = SDL.SDL_Scancode.SDL_SCANCODE_BACKSPACE,
    LCTRL = SDL.SDL_Scancode.SDL_SCANCODE_LCTRL,
    RCTRL = SDL.SDL_Scancode.SDL_SCANCODE_RCTRL,
    UP = SDL.SDL_Scancode.SDL_SCANCODE_UP,
    DOWN = SDL.SDL_Scancode.SDL_SCANCODE_DOWN,
    LEFT = SDL.SDL_Scancode.SDL_SCANCODE_LEFT,
    RIGHT = SDL.SDL_Scancode.SDL_SCANCODE_RIGHT,
    EQUALS = SDL.SDL_Scancode.SDL_SCANCODE_EQUALS,
    MINUS = SDL.SDL_Scancode.SDL_SCANCODE_MINUS,
    DELETE = SDL.SDL_Scancode.SDL_SCANCODE_DELETE,
    HOME = SDL.SDL_Scancode.SDL_SCANCODE_HOME,
    DOT = SDL.SDL_Scancode.SDL_SCANCODE_PERIOD,
    COMMA = SDL.SDL_Scancode.SDL_SCANCODE_COMMA,
    CAPSLOCK = SDL.SDL_Scancode.SDL_SCANCODE_CAPSLOCK
}