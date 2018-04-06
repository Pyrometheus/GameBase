﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogsKickAss
{
    public class Block
    {
        //LOCATION and VELOCITY
        public Vector Position;
        //WEIGHT
        public float weight;
        //DIMENSIONS
        public float height;
        public float width;
        public Block(Vector alpha, float kg, float w, float h)
        {
            this.Position = alpha;
            this.weight = kg;
            this.height = h;
            this.width = w;
        }
    }
}