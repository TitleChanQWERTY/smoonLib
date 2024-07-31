using SDL2;

namespace smoonLib.core;

public static class App
{
    private static string _appWindowName = "smoonLib";

    public static string AppWindowName
    {
        get => _appWindowName;
        set
        {
            _appWindowName = value;
            if (MemoryManager.sdlWindowMemory == IntPtr.Zero) return;
            SDL.SDL_SetWindowTitle(MemoryManager.sdlWindowMemory, _appWindowName);
        }
    }
    
    private static SizeInt _appWindowSize = new(640, 480);

    public static SizeInt AppWindowSize
    {
        get => _appWindowSize;
        set
        {
            _appWindowSize = value;
            if (MemoryManager.sdlWindowMemory == IntPtr.Zero) return;
            SDL.SDL_SetWindowSize(MemoryManager.sdlWindowMemory, _appWindowSize.width, _appWindowSize.height);
            SDL.SDL_GetWindowPosition(MemoryManager.sdlWindowMemory, out int x, out int y);
            SDL.SDL_SetWindowPosition(MemoryManager.sdlWindowMemory, x, y);
        }
    }

    public static void CloseApp()
    {
        Engine.IsRunning = false;
        DebugUtility.DebugWarning("Client starting close operation");
    }
}