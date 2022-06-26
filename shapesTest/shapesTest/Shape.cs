using System;
using System.Reflection;
using System.Text;
namespace shapesTest
{
    public enum ValueToUpdate
    {
        Scale = 1,
        Position,
        Rotation
    }

    public class Shape
    {
        static int _lastId = 0;
        static int _count = 0;
        String ID;
        float Width; 
        float Height;
        int AmountSides;
        float Scale;
        float[] Position = new float[3];
        float[] Rotation = new float[3];

        public Shape()
        {
            ID = (_lastId++).ToString();
            _count++;

        }

        ~Shape()
        {
            _count--;
        }

        //public override string ToString()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    foreach (PropertyInfo prop in this.GetType().GetProperties())
        //    {
        //        sb.Append(prop.Name);
        //        sb.Append(": ");
        //        sb.Append(prop.GetValue(this).ToString());
        //        if (_MultilineString)
        //            sb.Append("\r\n");
        //        else
        //            sb.Append(" ");
        //    }
        //    return sb.ToString();
        //}

        public string getData()
        {
            StringBuilder sb = new StringBuilder();
            foreach (FieldInfo prop in this.GetType().GetRuntimeFields())
            {
                if (prop.Name.StartsWith("_"))
                    continue;
                if (prop.FieldType.IsArray)
                    sb.Append(string.Join(",", (float[])prop.GetValue(this)));
                else
                    sb.Append(prop.GetValue(this).ToString());
                sb.Append(" ");
            }
            return sb.ToString().TrimEnd();
        }

        public string ToString(String Separator = " ")
        {
            StringBuilder sb = new StringBuilder();
            foreach (FieldInfo prop in this.GetType().GetRuntimeFields())
            {
                if (prop.Name.StartsWith("_"))
                    continue;
                sb.Append(prop.Name).Append(": ");
                if (prop.FieldType.IsArray)
                    sb.Append(string.Join(",", (float[])prop.GetValue(this)));
                else
                    sb.Append(prop.GetValue(this).ToString());
                sb.Append(Separator);
            }
            return sb.ToString();
        }

        public String getID()
        {
            return new String(ID);
        }

        public void update(Shape shape, ValueToUpdate vtu)
        {
            switch (vtu)
            {
                case ValueToUpdate.Scale:
                    this.Scale = shape.Scale;
                    break;
                case ValueToUpdate.Position:
                    this.Position = shape.Position;
                    break;
                case ValueToUpdate.Rotation:
                    this.Rotation = shape.Rotation;
                    break;
            }
        }

        public bool setProp(String name, String value)
        {
            switch (name)
            {
                case "Width":
                    return setWidth(value);
                case "Height":
                    return setHeight(value);
                case "AmountSides":
                    return setAmountSides(value);
                case "Scale":
                    return setScale(value);
                case "Position":
                    return setPosition(value);
                case "Rotation":
                    return setRotation(value);
            }
            return false;
        }

        public bool setWidth(String value)
        {
            try
            {
                Width = float.Parse(value);
                return true;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Too large Number Given");
            }
            catch (FormatException)
            {
                Console.WriteLine("Bad float Format");
            }
            return false;
        }

        public bool setHeight(String value)
        {
            try
            {
                Height = float.Parse(value);
                return true;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Too large Number Given");
            }
            catch (FormatException)
            {
                Console.WriteLine("Bad float Format");
            }
            return false;
        }

        public bool setAmountSides(String value)
        {
            try
            {
                AmountSides = int.Parse(value);
                return true;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Too large Number Given");
            }
            catch (FormatException)
            {
                Console.WriteLine("Bad int Format");
            }
            return false;
        }

        public bool setScale(String value)
        {
            try
            {
                Scale = float.Parse(value);
                return true;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Too large Number Given");
            }
            catch (FormatException)
            {
                Console.WriteLine("Bad float Format");
            }
            return false;
        }

        public bool setPosition(String value)
        {
            String[] values = value.Split(",");
            if (values.Length < 3)
            {
                Console.WriteLine("Bad Argument Format, except x, y, z as float");
                return false;
            }
            for (int i = 0; i < 3; i++)
            {
                 try
                {
                    Position[i] = float.Parse(values[i]);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Too large Number Given");
                    return false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Bad float Format");
                    return false;
                }
            }
            return true;
        }

        public bool setRotation(String value)
        {
            string[] values = value.Split(",");
            if (values.Length < 3)
            {
                Console.WriteLine("Bad Argument Format, exceptx, y, z as float");
                return false;
            }
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    Rotation[i] = float.Parse(values[i]);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Too large Number Given");
                    return false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Bad float Format");
                    return false;
                }
            }
            return true;
        }
        static public String getFields()
        {
            StringBuilder sb = new StringBuilder();
            foreach (FieldInfo prop in typeof(Shape).GetRuntimeFields())
            {
                if (prop.Name.StartsWith("_"))
                    continue;
                sb.Append(prop.Name).Append(" ");
            }
            return sb.ToString().TrimEnd();
        }
    }
}

