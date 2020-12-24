using System;

namespace patterns
{
    class MilitaryContext {
        private Position _state = null;

        public MilitaryContext(Position state) => TransitionTo(state);
 
        public int Order => _state.Order;
        
        public void TransitionTo(Position state) {
            Console.WriteLine($"MilitaryContext: Transition to {state.GetType().Name}.\n");
            _state = state;
            _state.SetContext(this);
        }
        
        public void TransitionTo(int order) {
            Console.WriteLine($"MilitaryContext: Transition to position in order {order}.\n");
            switch (order) {
                case 1:
                    _state = new Private();
                    break;
                case 2:
                    _state = new Sergeant();
                    break;
                case 3:
                    _state = new Lieutenant();
                    break;
                case 4:
                    _state = new Major();
                    break;
                case 5:
                    _state = new Colonel();
                    break;
                case 6:
                    _state = new General();
                    break;
            }
            _state.SetContext(this);
        }

        public void ShowChevron() => _state.HandleChevron();
    }

    abstract class Position {
        protected MilitaryContext _context;
        protected int order;
        public int Order => order;
        protected string chevron = "";

        public void SetContext(MilitaryContext MilitaryContext) => _context = MilitaryContext;
        public abstract void HandleChevron();
    }
    
    class Private: Position {
        public Private() {
            order = 1;
            chevron = "<o|    |";
        }
        public override void HandleChevron() => Console.WriteLine($"Handling private chevron: {chevron}\n");
    }

    class Sergeant: Position {
        public Sergeant() {
            order = 2;
            chevron = "<o| <<<|";
        }
        public override void HandleChevron() => Console.WriteLine($"Handling sergeant chevron: {chevron}\n");
    }
    
    class Lieutenant: Position {
        public Lieutenant() {
            order = 3;
            chevron = "<o|  oo|";
        }
        public override void HandleChevron() => Console.WriteLine($"Handling lieutenant chevron: {chevron}\n");
    }
    
    class Major: Position {
        public Major() {
            order = 4;
            chevron = "<o|   o||";
        }
        public override void HandleChevron() => Console.WriteLine($"Handling major chevron: {chevron}\n");
    }
    
    class Colonel: Position {
        public Colonel() {
            order = 5;
            chevron = "<o| ooo||";
        }
        public override void HandleChevron() => Console.WriteLine($"Handling colonel chevron: {chevron}\n");
    }
    
    class General: Position {
        public General() {
            order = 6;
            chevron = "<o|oooo%|";
        }
        public override void HandleChevron() => Console.WriteLine($"Handling general chevron: {chevron}\n");
    }
}