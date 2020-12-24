using System;

namespace patterns {
    public interface ISubject {
        void getBooks();
        void getBookByTitle();
        void takeBook();
        void returnBook();
    }

    class RealSubject : ISubject {
        public void getBooks() {
            Console.WriteLine("Here are all the books in our library:");
            foreach (string b in Globals.books)
                Console.WriteLine($"\"{b}\"");
            Console.WriteLine();
        }

        public void getBookByTitle() {
            Console.Write("Please enter a book title: ");
            string title = Console.ReadLine();
            if (title.Length != 0) {
                if (Globals.books.Contains(title))
                    Console.WriteLine($"Book by title \"{title}\" found!");
                else
                    Console.WriteLine($"Book by title \"{title}\" not found!");
            }
            else
                Console.WriteLine("Invalid input!");

            Console.WriteLine();
        }

        public void takeBook() {
            Console.Write("Please enter a book title: ");
            string title = Console.ReadLine();
            if (title.Length != 0) {
                if (Globals.books.Contains(title)) {
                    Console.WriteLine($"Book by title \"{title}\" found! Taking...");
                    Globals.books.Remove(title);
                    Console.WriteLine("Taken!");
                }
                else
                    Console.WriteLine($"Book by title \"{title}\" not found!");
            }
            else
                Console.WriteLine("Invalid input!");
            Console.WriteLine();
        }

        public void returnBook() {
            Console.Write("Please enter a book title: ");
            string title = Console.ReadLine();
            if (title.Length != 0) {
                if (Globals.books.Contains(title))
                    Console.WriteLine($"Book by title \"{title}\" found! Please keep it :)");
                else {
                    Console.WriteLine($"Book by title \"{title}\" not found! Returning...");
                    Globals.books.Add(title);
                    Console.WriteLine("Returned!");
                }
            }
            else
                Console.WriteLine("Invalid input!");
            Console.WriteLine();
        }
    }

    class Proxy : ISubject {
        private RealSubject _realSubject;
        private string login = "";
        
        public Proxy(RealSubject realSubject) {
            _realSubject = realSubject;
        }

        public bool signIn() {
            Console.Write("Please enter your login: ");
            string l = Console.ReadLine();
            if (l.Length != 0) {
                if (Globals.logins.Contains(l)) {
                    if (login != "")
                        Console.WriteLine("You're already logged in!");
                    else {
                        Console.WriteLine("Great! You logged in!");
                        login = l;
                    }
                    Console.WriteLine();
                    return true;
                }
                Console.Write("Hm... It seems your login is not in our system. Register instead? [y/n]");
                string answer = Console.ReadLine();
                switch (answer.ToLower().Trim()) {
                    case "y":
                        register();
                        return true;
                    case "n":
                        Console.WriteLine("Oh well, see you next time!");
                        Console.WriteLine();
                        return false;
                    default:
                        Console.WriteLine("Invalid input!");
                        Console.WriteLine();
                        return false;
                }
            }
            else {
                Console.WriteLine("Invalid input!\n");
                return false;
            }
        }

        public bool register() {
            Console.Write("Please enter your new login: ");
            string l = Console.ReadLine();
            if (l.Length != 0) {
                login = l;
                Globals.logins.Add(l);
                Console.WriteLine("Successfully registered!");
                return true;
            }
            return false;
        }
        
        public void getBooks() {
            if (CheckAccess(login)) 
                _realSubject.getBooks();
        }

        public void getBookByTitle() {
            if (CheckAccess(login)) 
                _realSubject.getBookByTitle();
        }

        public void takeBook() {
            if (CheckAccess(login)) 
                _realSubject.takeBook();
        }

        public void returnBook() {
            if (CheckAccess(login))
                _realSubject.returnBook();
        }

        public bool CheckAccess(string login) {
            return Globals.logins.Contains(login);
        }
    }
}