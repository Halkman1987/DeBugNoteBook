using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructurPatterns.Compozite
{
    class Folder : Component
    {
        List<Component> subFolder = new List<Component>();
        public Folder(string name) : base(name)
        {

        }

        public override void Add(Component c)
        {
            subFolder.Add(c);
            Console.WriteLine($" В {this.Name} добавленно :{c.Name}");
        }

        public override void Display()
        {
            Console.WriteLine($"{Name} содержит :");
            foreach (Component comp in subFolder)
                comp.Display();
        }

        public override void Remove(Component c)
        {
            subFolder.Remove(c);
            Console.WriteLine($" Из {this.Name} удаленно :{c.Name}");
        }
    }
}
