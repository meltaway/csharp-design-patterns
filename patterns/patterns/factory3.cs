using System;

namespace patterns {
    public interface IProduct {
        void showInfo();
        void Repair();
        void Wear();
    }
    
    public abstract class Factory {
        public abstract IProduct ProduceShoe();

        public string Type() {
            var product = ProduceShoe();
            var result = "Factory: The same Factory's code has just worked with " + product.GetType();
            return result;
        }
    }
    
    class wShoeFactory : Factory {
        public override IProduct ProduceShoe() {
            return new wShoes();
        }
    }

    class mShoeFactory : Factory {
        public override IProduct ProduceShoe() {
            return new mShoes();
        }
    }

    class tShoeFactory : Factory {
        public override IProduct ProduceShoe() {
            return new tShoes();
        }
    }

    class wShoes : IProduct {
        private int integrity = 100;
        private string color;
        private string model;
        private int size;

        public wShoes() {
            color = "black";
            model = "kitten heels";
            size = 37;
        }

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

    class mShoes : IProduct {
        private int integrity = 100;
        private string color;
        private string model;
        private int size;

        public mShoes() {
            color = "black";
            model = "oxfords";
            size = 42;
        }

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

        public tShoes() {
            color = "black";
            purpose = "running";
            footLength = 27;
        }

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