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
            if (MemoryManager.SdlWindowMemory == IntPtr.Zero) return;
            SDL.SDL_SetWindowTitle(MemoryManager.SdlWindowMemory, _appWindowName);
        }
    }
    
    private static SizeInt _appWindowSize = new(640, 480);

    public static SizeInt AppWindowSize
    {
        get => _appWindowSize;
        set
        {
            _appWindowSize = value;
            if (MemoryManager.SdlWindowMemory == IntPtr.Zero) return;
            SDL.SDL_SetWindowSize(MemoryManager.SdlWindowMemory, _appWindowSize.X, _appWindowSize.Y);
            SDL.SDL_GetWindowPosition(MemoryManager.SdlWindowMemory, out int x, out int y);
            SDL.SDL_SetWindowPosition(MemoryManager.SdlWindowMemory, x, y);
        }
    }
}