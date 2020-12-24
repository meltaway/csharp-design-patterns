using System;
using System.Collections.Generic;

namespace patterns
{
    public interface IHandler {
        IHandler SetNext(IHandler handler);
        object HandleBread();
    }
    
    public abstract class AbstractHandler: IHandler {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler handler) {
            _nextHandler = handler;
            return handler;
        }
        
        public virtual object HandleBread() {
            if (_nextHandler != null)
                return _nextHandler.HandleBread();
            return null;
        }
    }

    class WifeHandler: AbstractHandler {
        public override object HandleBread() {
            int coin = (new Random()).Next(0, 2);
            if (coin == 1) 
                return "Wife: I bought the bread today.\n";
            else Console.WriteLine($"   Wife: Somebody else is buying bread.");
            return base.HandleBread();
        }
    }
    
    class HusbandHandler: AbstractHandler {
        public override object HandleBread() {
            int coin = (new Random()).Next(0, 2);
            if (coin == 1) 
                return "Husband: I bought the bread today.\n";
            else Console.WriteLine($"   Husband: Somebody else is buying bread.");
            return base.HandleBread();
        }
    }
    
    class SonHandler: AbstractHandler {
        public override object HandleBread() {
            int coin = (new Random()).Next(0, 2);
            if (coin == 1) 
                return "Son: I bought the bread today.\n";
            else Console.WriteLine($"   Son: Somebody else is buying bread.");
            return base.HandleBread();
        }
    }
    
    class DaughterHandler: AbstractHandler {
        public override object HandleBread() {
            int coin = (new Random()).Next(0, 2);
            if (coin == 1) 
                return "Daughter: I bought the bread today.\n";
            return "Daughter: I ordered the bread online today.\n";
        }
    }
    
}