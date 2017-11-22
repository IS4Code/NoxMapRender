using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using NoxShared;

namespace MapEditor.render
{
    abstract class CustomRenderObject : Map.Object
    {
        readonly Action<Graphics> renderer;

        public CustomRenderObject(Action<Graphics>  renderer)
        {
            this.renderer = renderer;
        }

        public void Render(Graphics g)
        {
            renderer(g);
        }
    }
}
