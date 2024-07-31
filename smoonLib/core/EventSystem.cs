using SDL2;

namespace smoonLib.core;

internal static class EventSystem
{
    internal static void UpdateEvent()
    {
        SDL.SDL_PumpEvents();
        while (SDL.SDL_PollEvent(out SDL.SDL_Event e) != 0)
        {
            switch (e.type)
            {
                case SDL.SDL_EventType.SDL_QUIT:
                    App.CloseApp();
                    break;
            }
        }
    }
}