﻿namespace RedBadger.Xpf.Presentation.Media
{
    using Microsoft.Xna.Framework;

    using RedBadger.Xpf.Graphics;

    public interface ISpriteJob
    {
        void Draw(ISpriteBatch spriteBatch);

        void SetAbsoluteOffset(Vector2 offset);
    }
}