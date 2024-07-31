using SDL2;

namespace smoonLib.core;

public static class MemoryManager
{
    internal static IntPtr sdlWindowMemory = IntPtr.Zero;
    internal static IntPtr sdlRendererMemory = IntPtr.Zero;

    internal static readonly Dictionary<string, IntPtr> textureCollect = new();

    internal static IntPtr CashedTexture = IntPtr.Zero;
    
    private static void CleanMemory()
    {
        DebugUtility.DebugLog("Clean MEMORY!");
        foreach (var texture in textureCollect) Texture.DestroyTextureFromMemory(texture.Value);
        Texture.DestroyTextureFromMemory(CashedTexture);
        SDL.SDL_DestroyRenderer(sdlRendererMemory);
        SDL.SDL_DestroyWindow(sdlWindowMemory);
        SDL_image.IMG_Quit();
        SDL.SDL_Quit();
    }
    
    internal static void QuitApp()
    {
        CleanMemory();
        DebugUtility.DebugCorrect("Successfully close!");
    }
}