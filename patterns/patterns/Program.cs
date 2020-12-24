using System;
using System.Diagnostics;
using System.IO;

namespace patterns {
    public class Client {
        //proxy 2
        public void getBooks(ISubject subject) => subject.getBooks();
        public void getBookByTitle(ISubject subject) => subject.getBookByTitle();
        public void takeBook(ISubject subject) => subject.takeBook();
        public void returnBook(ISubject subject) => subject.returnBook();
        public static void clientCodeProxy() {
            Client client = new Client();
            RealSubject realSubject = new RealSubject();
            Proxy proxy = new Proxy(realSubject);

            if (proxy.signIn()) {
                while (true) {
                    Console.WriteLine("Choose an operation:");
                    Console.WriteLine("1. Show all books\n2. Check if book is in the library" +
                                      "\n3. Take a book\n4. Return a book\n5. Exit");
                    string choice = Console.ReadLine();
                    switch (choice) {
                        case "1":
                            client.getBooks(proxy);
                            break;
                        case "2":
                            client.getBookByTitle(proxy);
                            break;
                        case "3":
                            client.takeBook(proxy);
                            break;
                        case "4":
                            client.returnBook(proxy);
                            break;
                        case "5":
                            Console.WriteLine("Exiting!");
                            return;
                        default:
                            Console.WriteLine("Invalid operation code!");
                            break;
                    }
                }
            }
        }
        
        //factory 3
        public void Type(Factory factory) => factory.Type();
        public IProduct ProduceShoe(Factory factory) => factory.ProduceShoe();
        public void showInfo(IProduct product) => product.showInfo();
        public void Repair(IProduct product) => product.Repair();
        public void Wear(IProduct product) => product.Wear();
        public static void clientCodeFactory() {
            Client client = new Client();
            var trainers = client.ProduceShoe(new tShoeFactory());
            trainers.showInfo();
            int uses1 = (new Random()).Next(1, 99);
            for (int i = 0; i < uses1; i++) {
                trainers.Wear();
                Console.WriteLine("Wearing trainers...");
            }
            trainers.showInfo();
            trainers.Repair();
            trainers.showInfo();
        }
        
        //state 4
        public static void clientCodeState() {
            var game = new MilitaryContext(new Private());
            while (true) {
                Console.WriteLine("Choose an operation:");
                Console.WriteLine("1. Show chevron\n2. Promote\n3. Demote\n4. Exit");
                string choice = Console.ReadLine();
                switch (choice) {
                    case "1":
                        game.ShowChevron();
                        break;
                    case "2":
                        if (game.Order < 6)
                            game.TransitionTo(game.Order + 1);
                        else
                            Console.WriteLine("Cannot promote a general!");
                        break;
                    case "3":
                        if (game.Order > 1)
                            game.TransitionTo(game.Order - 1);
                        else
                            Console.WriteLine("Cannot demote a private!");
                        break;
                    case "4":
                        Console.WriteLine("Exiting!");
                        return;
                    default:
                        Console.WriteLine("Invalid operation code!");
                        break;
                }
            }
        }

        public AbstractHandler formChain() {
            AbstractHandler wife = new WifeHandler();
            wife.SetNext(new HusbandHandler()).SetNext(new SonHandler()).SetNext(new DaughterHandler());
            return wife;
        }
        public void buyBread(AbstractHandler handler, int chainLength) {
            for(int i = 0; i < chainLength; i++) {
                Console.WriteLine($"Client: Who is buying bread today?");
                var result = handler.HandleBread();
                if (result != null) {
                    Console.Write($"   {result}");
                    break;
                }
                else {
                    Console.WriteLine($"   Somebody else is buying bread.");
                    break;
                }
            }
        }
        public static void clientCodeChain() {
            Client client = new Client();
            client.buyBread(client.formChain(), 4);
        }
        
    }
    
    class Program {
        static void Main(string[] args) {
            //Client.clientCodeProxy();
            //Client.clientCodeFactory();
            //Client.clientCodeState();
            // Client.clientCodeChain();
            Client.clientCodeChain();
        }
    }
}