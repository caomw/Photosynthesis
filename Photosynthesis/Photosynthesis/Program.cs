using System;

namespace Photosynthesis
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Photosynthesis game = new Photosynthesis())
            {
                game.Run();
            }
        }
    }
#endif
}

