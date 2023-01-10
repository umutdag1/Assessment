namespace ProjectApp.libs
{
    public class FileActionHandler
    {
        public static IEnumerable<string> GetFileContents(string filePath)
        {
            return File.ReadLines(filePath);
        }

        public static void WriteFileContents(string fullPath, IEnumerable<string> contents)
        {
            File.WriteAllLines(fullPath, contents);
        }
    }
}