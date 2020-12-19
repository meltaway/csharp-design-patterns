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
            
        }

        public void getBookByTitle() {
            
        }

        public void takeBook() {
            
        }

        public void returnBook() {
            
        }
    }

    class Proxy : ISubject {
        private RealSubject _realSubject;
        private string login = "";
        
        public Proxy(RealSubject realSubject) {
            _realSubject = realSubject;
        }

        public void signIn() {
            
        }

        public void register() {
            
        }
        
        public void getBooks() {
            if (CheckAccess(login)) {
                _realSubject.getBooks();
                LogAccess();
            }
        }

        public void getBookByTitle() {
            if (CheckAccess(login)) {
                _realSubject.getBookByTitle();
                LogAccess();
            }
        }

        public void takeBook() {
            if (CheckAccess(login)) {
                _realSubject.takeBook();
                LogAccess();
            }
        }

        public void returnBook() {
            if (CheckAccess(login)) {
                _realSubject.returnBook();
                LogAccess();
            }
        }

        public bool CheckAccess(string login) {
            Console.WriteLine("Proxy: Checking access prior to firing a real request.");

            return true;
        }
        
        public void LogAccess() {
            Console.WriteLine("Proxy: Logging the time of request.");
        }
    }
    
    public class Client
    {
        public void ClientCode(ISubject subject)
        {
            // ...
            
            subject.Request();
            
            // ...
        }
    }
    
}