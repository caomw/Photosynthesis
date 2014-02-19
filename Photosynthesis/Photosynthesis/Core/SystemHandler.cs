using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Photosynthesis.Core
{
    public class SystemHandler
    {
        public List<String> CurrentText;
        public int TextIndex;

        public enum Stage
        {
            PhotosystemTwo,
            Plastoquinone,
            Cytochrome,
            Plastocyanin,
            PhotosystemOne
        };

        public void DrawText(List<String> text)
        {
            this.CurrentText = text;
            this.TextIndex = 0;
        }
    }
}
