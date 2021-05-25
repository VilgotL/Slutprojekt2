using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    interface IDamageable
    {
        /// <summary>
        /// Gör så att objektet skadas
        /// </summary>
        void Damage();
    }
}
