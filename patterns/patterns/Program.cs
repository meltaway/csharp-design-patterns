using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace patterns {
    public class Client {
        //decorator 1
        public static void clientCodeDecorator() {
            Patient p = new VirtualPatient();
            List<Patient> checkup = new List<Patient>();
            checkup.Add(p);
            while (true) {
                checkup[checkup.Count - 1].showInfo();
                Console.WriteLine("Which doctor will see the patient?");
                Console.WriteLine("1. Orthopedist\n2. Otolaryngologist\n3. Neuropathologist\n4. End checkup queue");
                string choice = Console.ReadLine();
                switch (choice) {
                    case "1":
                        Doctor d1 = new Orthopedist();
                        d1.includeInCheckup(checkup[checkup.Count - 1]);
                        checkup.Add(d1);
                        break;
                    case "2":
                        Doctor d2 = new Otolaryngologist();
                        d2.includeInCheckup(checkup[checkup.Count - 1]);
                        checkup.Add(d2);
                        break;
                    case "3":
                        Doctor d3 = new Neuropathologist();
                        d3.includeInCheckup(checkup[checkup.Count - 1]);
                        checkup.Add(d3);
                        break;
                    case "4":
                        Console.WriteLine("Ended queue!");
                        checkup[checkup.Count - 1].showInfo();
                        checkup[checkup.Count - 1].goThroughCheckup();
                        return;
                    default:
                        Console.WriteLine("Invalid operation code!");
                        break;
                }
            }
        }
        
        //proxy 2
        public void getBooks(IService service) => service.getBooks();
        public void getBookByTitle(IService service) => service.getBookByTitle();
        public void takeBook(IService service) => service.takeBook();
        public void returnBook(IService service) => service.returnBook();
        public static void clientCodeProxy() {
            Client client = new Client();
            Service service = new Service();
            Proxy proxy = new Proxy(service);

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
        public IProduct ProduceShoe(Factory factory) => factory.ProduceShoe();
        public void showInfo(IProduct product) => product.showInfo();
        public void Repair(IProduct product) => product.Repair();
        public void Wear(IProduct product) => product.Wear();
        public static void clientCodeFactory() {
            Factory t = new tShoeFactory();
            Factory m = new mShoeFactory();
            Factory w = new wShoeFactory();
            List<IProduct> shoes = new List<IProduct>();
            
            while (true) {
                Console.WriteLine("Choose an operation:");
                Console.WriteLine("1. Produce trainers\n2. Produce women's shoes\n3. Produce men's shoes\n4. Show number of shoes in the warehouse\n5. Exit");
                string choice = Console.ReadLine();
                switch (choice) {
                    case "1":
                        Console.WriteLine("How many should we produce?");
                        string n1 = Console.ReadLine();
                        for (int i = 0; i < int.Parse(n1); i++) {
                            IProduct trainers = t.ProduceShoe();
                            shoes.Add(trainers);
                        }
                        break;
                    case "2":
                        Console.WriteLine("How many should we produce?");
                        string n2 = Console.ReadLine();
                        for (int i = 0; i < int.Parse(n2); i++) {
                            IProduct womens = w.ProduceShoe();
                            shoes.Add(womens);
                        }
                        break;
                    case "3":
                        Console.WriteLine("How many should we produce?");
                        string n3 = Console.ReadLine();
                        for (int i = 0; i < int.Parse(n3); i++) {
                            IProduct mens = m.ProduceShoe();
                            shoes.Add(mens);
                        }
                        break;
                    case "4":
                        int tn = 0, wn = 0, mn = 0;
                        foreach (IProduct item in shoes) {
                            if (item.GetType().ToString() == "patterns.tShoes") tn++;
                            if (item.GetType().ToString() == "patterns.mShoes") mn++;
                            if (item.GetType().ToString() == "patterns.wShoes") wn++;
                        }
                        Console.WriteLine($"Warehouse: trainers [{tn}], women's [{wn}], men's [{mn}]");
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
        
        //chain 5
        public AbstractHandler formChain() {
            AbstractHandler wife = new WifeHandler();
            wife.SetNext(new HusbandHandler()).SetNext(new SonHandler()).SetNext(new DaughterHandler());
            return wife;
        }
        public void buyBread(AbstractHandler handler, int chainLength) {
            Console.WriteLine($"Client: Who is buying bread today?");
            var result = handler.HandleBread();
            if (result != null) {
                Console.Write($"   {result}");
                return;
            }
            else {
                Console.WriteLine($"   Somebody else is buying bread.");
                return;
            }
        }
        public static void clientCodeChain() {
            Client client = new Client();
            client.buyBread(client.formChain(), 4);
        }
    }
    
    class Program {
        static void Main(string[] args) {
            //Client.clientCodeDecorator();
            //Client.clientCodeProxy();
            //Client.clientCodeFactory();
            //Client.clientCodeState();
            Client.clientCodeChain();
        }
    }
}