using SDL2;

namespace smoonLib.core;

public static class Engine
{
    internal static bool IsRunning = true;
    
    private static void InitEngine()
    {
        SDL.SDL_Init(SDL.SDL_INIT_VIDEO);
        MemoryManager.SdlWindowMemory = SDL.SDL_CreateWindow(App.AppWindowName, SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WINDOWPOS_CENTERED, App.AppWindowSize.X, App.AppWindowSize.Y, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
        MemoryManager.SdlRendererMemory = SDL.SDL_CreateRenderer(MemoryManager.SdlWindowMemory, -1,
            SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);
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
            SDL.SDL_RenderClear(MemoryManager.SdlRendererMemory);
            Collector.UpdateState();
            Collector.UpdateContainer();
            SDL.SDL_RenderPresent(MemoryManager.SdlRendererMemory);
        }
        MemoryManager.QuitApp();
    }
}