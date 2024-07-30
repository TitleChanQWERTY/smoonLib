using SDL2;

namespace smoonLib.core;

public static class MemoryManager
{
    internal static IntPtr SdlWindowMemory = IntPtr.Zero;
    internal static IntPtr SdlRendererMemory = IntPtr.Zero;
    
    private static void CleanMemory()
    {
        SDL.SDL_DestroyRenderer(SdlRendererMemory);
        SDL.SDL_DestroyWindow(SdlWindowMemory);
        SDL.SDL_Quit();
    }
    
    internal static void QuitApp()
    {
        CleanMemory();
    }
}