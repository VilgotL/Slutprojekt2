﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Template
{
    class Enemy3 : EnemyClass
    {
        protected List<Bullet> bulletList = new List<Bullet>();

        protected Texture2D bulletTexture;

        protected Stopwatch shootTimer = new Stopwatch();

        public Enemy3(Texture2D texture, Texture2D bulletTexture, Vector2 position, Rectangle rectangle) : base(texture, position, rectangle)
        {
            this.texture = texture;
            this.bulletTexture = bulletTexture;
            this.position = position;
            this.rectangle = rectangle;

            ySpeed = 1.5f;
            xSpeed = 0f;
            lives = 1;

            shootTimer.Start();
        }

        private void RestartTimer()
        {
            shootTimer.Stop();
            shootTimer.Reset();
            shootTimer.Start();
        }

        private void Shoot()
        {
            if (shootTimer.ElapsedMilliseconds > 1000)
            {
                bulletList.Add(
            }
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.LightYellow);
        }
    }
}