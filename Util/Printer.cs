using static System.Console;

namespace CoreSchool.Util{
    public static class Printer{
        public static void DrawLine(int size = 10){
            var line = "".PadLeft(size, '=');
            WriteLine(line);
        }

        public static void WriteTitle(string title){
            DrawLine(title.Length + 6);
            WriteLine($"|| {title} ||");
            DrawLine(title.Length + 6);
        }
    }
}