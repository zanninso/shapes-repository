using System;
namespace shapesTest
{
    public class Menu
    {
        List<String> choices = new List<string>();
        String title = "Menu";

        public Menu(String[] choices, String title = "Menu")
        {
            this.title = title;
            this.choices.AddRange(choices);
        }

        public Menu( String title = "Menu")
        {
            this.title = title;
        }

        public Menu addChoice(String choice)
        {
            choices.Add(choice);
            return this;
        }

        public void show()
        {
            Console.WriteLine("###############  " + title + "  ###############");
            for (int i = 0; i < choices.Count; i++)
                Console.WriteLine((i + 1) + ") " + choices[i]);
            Console.WriteLine("");
        }

        public int getChoice()
        {
            int option = -1;
            do
            {
                option = int.Parse(ShapesManager.ReadLine("Select an option:"));
            } while (option < 0 || option > choices.Count());
            Console.Clear();
            return option;
        }
    }
}

