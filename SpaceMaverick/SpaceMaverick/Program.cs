using System;

namespace SpaceMaverick
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Game1 game = new Game1())
            {
                ////try
                //{

                    game.Run();
                //}
                //catch (Exception ex)
                //{
                  //  System.Windows.Forms.MessageBox.Show(ex.ToString());
                //}
            }
        }
    }
#endif
}

