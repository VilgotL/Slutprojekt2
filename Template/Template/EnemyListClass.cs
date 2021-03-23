using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Template
{
    class EnemyListClass
    {
        protected List<EnemyClass> enemyList = new List<EnemyClass>();

        public List<EnemyClass> EnemyList
        {
            get { return enemyList; }
        }
    }
}
