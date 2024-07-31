using SDL2;

namespace smoonLib.core;

public static class Engine
{
    internal static bool IsRunning = true;
    
    private static void InitEngine()
    {
        SDL.SDL_Init(SDL.SDL_INIT_VIDEO);
        SDL_image.IMG_Init(SDL_image.IMG_InitFlags.IMG_INIT_PNG | SDL_image.IMG_InitFlags.IMG_INIT_JPG);
        MemoryManager.sdlWindowMemory = SDL.SDL_CreateWindow(App.AppWindowName, SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WINDOWPOS_CENTERED, App.AppWindowSize.width, App.AppWindowSize.height, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
        MemoryManager.sdlRendererMemory = SDL.SDL_CreateRenderer(MemoryManager.sdlWindowMemory, -1,
            SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);
        if (MemoryManager.sdlWindowMemory == IntPtr.Zero) DebugUtility.DebugException("Can't create Window");
        else if (MemoryManager.sdlRendererMemory == IntPtr.Zero) DebugUtility.DebugException("Can't create Renderer");
        MemoryManager.CashedTexture = Texture.CreateEmptyTexture();
        Collector.ChangeContainer(0);
    }

    public static void RunApp()
    {
        InitEngine();
        UpdateLoop();
    }

    private static void UpdateLoop()
    {
        while (IsRunning)
        {
            EventSystem.UpdateEvent();
            SDL.SDL_RenderClear(MemoryManager.sdlRendererMemory);
            Collector.UpdateState();
            Collector.UpdateContainer();
            SDL.SDL_RenderPresent(MemoryManager.sdlRendererMemory);
        }
        MemoryManager.QuitApp();
    }
}