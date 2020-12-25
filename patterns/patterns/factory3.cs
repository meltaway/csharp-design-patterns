using System;
using System.Threading;

namespace patterns {
    public interface IProduct {
        void showInfo();
        void Repair();
        void Wear();
    }
    
    public abstract class Factory {
        public abstract IProduct ProduceShoe();
    }
    
    public class wShoeFactory : Factory {
        public override IProduct ProduceShoe() {
            Thread.Sleep(100);
            Random r = new Random();
            string color = Globals.colors[r.Next(Globals.colors.Count)];
            string model = Globals.wmodels[r.Next(Globals.wmodels.Count)];
            int size = r.Next(20, 51);
            return new wShoes(color, model, size);
        }
    }

    public class mShoeFactory : Factory {
        public override IProduct ProduceShoe() {
            Thread.Sleep(100);
            Random r = new Random();
            string color = Globals.colors[r.Next(Globals.colors.Count)];
            string model = Globals.mmodels[r.Next(Globals.mmodels.Count)];
            int size = r.Next(20, 51);
            return new mShoes(color, model, size);
        }
    }

    public class tShoeFactory : Factory {
        public override IProduct ProduceShoe() {
            Thread.Sleep(100);
            Random r = new Random();
            string color = Globals.colors[r.Next(Globals.colors.Count)];
            string purpose = Globals.purposes[r.Next(Globals.purposes.Count)];
            int size = r.Next(19, 51);
            return new tShoes(color, purpose, size);
        }
    }

    public class wShoes : IProduct {
        private int integrity = 100;
        private string color;
        private string model;
        private int size;

        public wShoes(): this("black", "kitten heels", 37) {}

        public wShoes(string c, string m, int s) {
            color = c;
            model = m;
            if (33 <= s && s <= 43)
                size = s;
            else
                size = 37;
        }

        public void showInfo() {
            Console.WriteLine($"\nWomen's shoes\nSize: {size}\nColor: {color}\nModel: {model}\nIntegrity: {integrity}%\n");
        }

        public void Repair() {
            if (integrity < 100) {
                Console.WriteLine("Repairing...");
                integrity = 100;
                Console.WriteLine("Repaired!");
            }
            else
                Console.WriteLine("The shoes are brand new!");
        }

        public void Wear() {
            if (integrity > 0) {
                integrity--;
                if (integrity == 0)
                    Console.WriteLine("Oh no! The shoes ripped apart... You can't wear them anymore!");
            }
            else
                Console.WriteLine("You can't wear ripped shoes!");
        }

    }

    public class mShoes : IProduct {
        private int integrity = 100;
        private string color;
        private string model;
        private int size;

        public mShoes(): this("black", "oxfords",42) {}

        public mShoes(string c, string m, int s) {
            color = c;
            model = m;
            if (38 <= s && s <= 48)
                size = s;
            else
                size = 42;
        }

        public void showInfo() {
            Console.WriteLine($"\nMen's shoes\nSize: {size}\nColor: {color}\nModel: {model}\nIntegrity: {integrity}%\n");
        }

        public void Repair() {
            if (integrity < 100) {
                Console.WriteLine("Repairing...");
                integrity = 100;
                Console.WriteLine("Repaired!");
            }
            else
                Console.WriteLine("The shoes are brand new!");
        }

        public void Wear() {
            if (integrity > 0) {
                integrity--;
                if (integrity == 0)
                    Console.WriteLine("Oh no! The shoes ripped apart... You can't wear them anymore!");
            }
            else
                Console.WriteLine("You can't wear ripped shoes!");
        }
    }

    class tShoes : IProduct {
        private int integrity = 100;
        private string color;
        private string purpose;
        private int footLength;

        public tShoes(): this("black", "running", 27){}

        public tShoes(string c, string p, int s) {
            color = c;
            purpose = p;
            if (20 <= s && s <= 32)
                footLength = s;
            else
                footLength = 27;
        }

        public void showInfo() {
            Console.WriteLine($"\nTrainers\nFoot Length: {footLength}\nColor: {color}\nPurpose: {purpose}\nIntegrity: {integrity}%\n");
        }

        public void Repair() {
            if (integrity < 100) {
                Console.WriteLine("Repairing...");
                integrity = 100;
                Console.WriteLine("Repaired!");
            }
            else
                Console.WriteLine("The shoes are brand new!");
        }

        public void Wear() {
            if (integrity > 0) {
                integrity--;
                if (integrity == 0)
                    Console.WriteLine("Oh no! The shoes ripped apart... You can't wear them anymore!");
            }
            else
                Console.WriteLine("You can't wear ripped shoes!");
        }
    }
}