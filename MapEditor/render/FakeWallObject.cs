using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using NoxShared;

namespace MapEditor.render
{
    class FakeWallObject : CustomRenderObject, IComparable<Map.Object>
    {
        int index;
        Map.Wall wall;

        public FakeWallObject(int index, Map.Wall wall, MapViewRenderer mapView) : base(CreateRenderer(wall, mapView))
        {
            this.index = index;
            this.wall = wall;
        }

        private static Action<Graphics> CreateRenderer(Map.Wall wall, MapViewRenderer mapView)
        {
            return g => {
                if(EditorSettings.Default.Edit_PreviewMode)
                {
                    mapView.DrawTexturedWall(g, wall, false, false);
                }
            };
        }

        public int CompareTo(Map.Object other)
        {
            var wallObj = other as FakeWallObject;
            if(wallObj != null)
            {
                return this.index.CompareTo(wallObj.index);
            }

            return (wall.Location.Y * 23f).CompareTo(other.Location.Y);
        }
    }
}
