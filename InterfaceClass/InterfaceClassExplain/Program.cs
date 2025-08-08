namespace InterfaceClassExplain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Learning Classes and Interfaces");
            IDeveloper []devs = new IDeveloper[] { new Deven(), new SanjayVyas() };

            for (int i = 0; i < devs.Length; i++)
            {
                devs[i].WriteCode();
            }

            IVisualizeConcepts[] visualizeConcepts = new IVisualizeConcepts[] { new SanjayVyas()};
            for (int i = 0; i< visualizeConcepts.Length; i++)
            {
                visualizeConcepts[i].VisualizeProgramingConcepts();
            }

            Human[] humans = new Human[] { new SanjayVyas(), new Deven() };
            for (int i = 0; i < humans.Length; i++)
            {
                // write later.
            }
        }
    }
}

interface IDeveloper
{
    public void WriteCode();
}

interface IVisualizeConcepts
{
    public void VisualizeProgramingConcepts();
}

class Human
{
    protected void Eat() { Console.WriteLine("Eat food"); }
    protected void Love() { Console.WriteLine("Eat food"); }
    protected void Sleep() { Console.WriteLine("Eat food"); }
}

class Deven : Human, IDeveloper
{
    public void WriteCode()
    {
        Console.WriteLine("Deven wrote C# code");
    }

    public void MakeArt() { Console.WriteLine("Make Art"); }
}

class SanjayVyas : Human, IVisualizeConcepts, IDeveloper
{
    public void VisualizeProgramingConcepts()
    {
        Console.WriteLine("Visualizing Programming concepts.");
    }

    public void WriteCode()
    {
        Console.WriteLine("Sanjay sir wrote All lang code.");
    }

    public void PlayMusic()
    {
        Console.WriteLine("Play Music");
    }
}