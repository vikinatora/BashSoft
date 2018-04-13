using System.IO;

namespace BashSoft
{
    public static class SessionData
    {
        private static string currentPath = Directory.GetCurrentDirectory();

        public static string GetCurrentDirectoryPath()
        {
            return currentPath;
        }

        public static void ChangeCurrentDirectoryPath(string path)
        {
            currentPath = path;
        }
    }
}
