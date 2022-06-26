using System;
using System.Text;
using System.Collections;
using System.Reflection;

namespace shapesTest
{
    public class ShapesManager
    {
        Dictionary<String,Shape> shapes;
        public ShapesManager()
        {
            shapes = new Dictionary<String, Shape>();
        }

        public void Add()
        {
            Shape shape = new Shape();
            foreach (FieldInfo prop in shape.GetType().GetRuntimeFields())
            {
                bool set = false;
                do
                {
                    if (prop.Name.StartsWith("_") || prop.Name.Equals("ID"))
                        break;
                    String s = ReadLine(prop.Name + ": ");
                    set = shape.setProp(prop.Name, s);
                } while (set == false);
            }
            shapes.Add(shape.getID(), shape);
        }

        public bool Delete()
        {
            String ID = ReadLine("ID: ");
            return shapes.Remove(ID);
        }

        public bool Store(String path)
        {
            Byte[] data;
            try
            {
                FileStream f = File.OpenWrite(path);
                data = new UTF8Encoding(true).GetBytes(Shape.getFields() + Environment.NewLine);
                f.Write(data, 0, data.Length);
                foreach (String key in shapes.Keys)
                {
                    data = new UTF8Encoding(true).GetBytes(shapes[key].getData() + Environment.NewLine);
                    f.Write(data, 0, data.Length);
                }
                f.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public bool Update(String ID, Shape shape, ValueToUpdate vtu)
        {
            if (shapes.ContainsKey(ID))
            {
                shapes[ID].update(shape, vtu);
                return true;
            }
            return false;
        }

        public bool Edit(String ID, ValueToUpdate vtu)
        {
            if (shapes.ContainsKey(ID))
            {
                Shape shape = shapes[ID];
                switch (vtu)
                {
                    case ValueToUpdate.Scale:
                        shape.setScale(ReadLine(vtu.ToString() + ": "));
                        break;
                    case ValueToUpdate.Position:
                        shape.setPosition(ReadLine(vtu.ToString() + ": "));
                        break;
                    case ValueToUpdate.Rotation:
                        shape.setRotation(ReadLine(vtu.ToString() + ": "));
                        break;
                }
                return true;
            }
            return false;
        }

        public static String ReadLine(String prefix)
        {
            Console.Write(prefix);
            String line = Console.ReadLine();
            if (line == null)
                throw new IOException("input file closed");
            return line;
        }

        public void List(String ID = "")
        {
            if (ID.Equals(""))
            {
                foreach (String key in shapes.Keys)
                {
                    Console.WriteLine(shapes[key].ToString());
                }
            }
            else if (shapes.ContainsKey(ID))
            {
                Console.WriteLine(shapes[ID].ToString("\r\n"));
            }
            else
            {
                Console.WriteLine("Bad ID");
            }
        }
        public int ShapesCount()
        {
            return shapes.Count();
        }
    }
}

