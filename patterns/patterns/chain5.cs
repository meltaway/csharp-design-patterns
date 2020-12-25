using System;
using System.Collections.Generic;
using System.Threading;

namespace patterns
{
    public interface IHandler {
        IHandler SetNext(IHandler handler);
        string HandleBread();
    }
    
    public abstract class AbstractHandler: IHandler {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler handler) {
            _nextHandler = handler;
            return handler;
        }
        
        public virtual string HandleBread() {
            Thread.Sleep(100);
            if (_nextHandler != null)
                return _nextHandler.HandleBread();
            return null;
        }
    }

    class WifeHandler: AbstractHandler {
        public override string HandleBread() {
            int coin = (new Random()).Next(0, 51);
            if (coin >= 25) 
                return "Wife: I bought the bread today, like always.\n";
            else Console.WriteLine($"   Wife: Somebody else is buying bread.");
            return base.HandleBread();
        }
    }
    
    class HusbandHandler: AbstractHandler {
        public override string HandleBread() {
            int coin = (new Random()).Next(0, 51);
            if (coin >= 25) 
                return "Husband: I bought the bread today. We don't have any money now.\n";
            else Console.WriteLine($"   Husband: Somebody else is buying bread.");
            return base.HandleBread();
        }
    }
    
    class SonHandler: AbstractHandler {
        public override string HandleBread() {
            int coin = (new Random()).Next(0, 51);
            if (coin >= 25) 
                return "Son: I bought the bread today. The cashier yelled at me.\n";
            else Console.WriteLine($"   Son: Somebody else is buying bread.");
            return base.HandleBread();
        }
    }
    
    class DaughterHandler: AbstractHandler {
        public override string HandleBread() {
            int coin = (new Random()).Next(0, 51);
            if (coin >= 25) 
                return "Daughter: I bought the bread today when I was coming home.\n";
            return "Daughter: I ordered the bread online today.\n";
        }
    }
}