
using NavigationLibrary;

class Mission
{

    void ReadInputFile()
    {
        string fileName = System.IO.Path.GetFullPath(Directory.GetCurrentDirectory() + @"\Inputs.txt");

        Console.WriteLine("Your file content is:");
        using (StreamReader sr = File.OpenText(fileName))
        {
            string s = "";
            while ((s = sr.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }
        }

        Console.ReadKey();
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        Mission mission = new Mission();
        mission.ReadInputFile();

    }
}
