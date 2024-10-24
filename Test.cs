using System;

class Program
{
    class Singleton
    {
        private static Singleton instance;

        // Private Constructor
        private Singleton() { }

        public static Singleton GetInstance()
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }

        public void DisplayMessage()
        {
            Console.WriteLine("Singleton instance is used.");
        }
    }

    static void Main()
    {
        Singleton singleton = Singleton.GetInstance();
        singleton.DisplayMessage();
    }
}
