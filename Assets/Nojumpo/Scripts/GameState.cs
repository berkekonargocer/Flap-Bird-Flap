using System;

namespace Nojumpo.Scripts
{
    [Serializable]
    public enum GameState
    {
        READYTOPLAY = 0,
        PLAYING = 1, 
        DEAD = 2,
    }
}