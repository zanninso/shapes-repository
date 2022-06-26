// See https://aka.ms/new-console-template for more information
using shapesTest;
try
{
    ShapesManager manager = new ShapesManager();
    Menu menu = new Menu("Shapes Manager");
    Menu editMenu = new Menu("Edit Shape");

    menu.addChoice("Add shape")
        .addChoice("Edit shape")
        .addChoice("Store shapes")
        .addChoice("Delete shape")
        .addChoice("Show all")
        .addChoice("Show Count")
        .addChoice("Show one")
        .addChoice("Exit");

    editMenu.addChoice("Edit Scale")
            .addChoice("Edit Position")
            .addChoice("Edit Rotation")
            .addChoice("back");

    Console.Clear();

    while (true)
    {
        menu.show();
        switch (menu.getChoice())
        {
            case 1:
                manager.Add();
                break;
            case 2:
                String ID = ShapesManager.ReadLine("ID: ");
                editMenu.show();
                manager.Edit(ID, (ValueToUpdate)editMenu.getChoice());
                break;
            case 3:
                manager.Store(ShapesManager.ReadLine("Path to store in: "));
                break;
            case 4:
                manager.Delete();
                break;
            case 5:
                manager.List();
                break;
            case 6:
                Console.WriteLine("Shapes count is " + manager.ShapesCount());
                break;
            case 7:
                manager.List(ShapesManager.ReadLine("ID: "));
                break;
            case 8:
                Console.WriteLine("exit");
                Environment.Exit(0);
                break;
        }
        Console.WriteLine("{0} Click Any botton to go back", Environment.NewLine);
        Console.ReadKey();
        Console.Clear();
    }
}
catch(Exception e)
{
    Console.WriteLine("exception: " + e.Message);
}