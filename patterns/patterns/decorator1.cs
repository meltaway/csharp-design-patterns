using System;
using System.Threading;

namespace patterns
{
    //Component
    public abstract class Patient {
        protected string ptname;
        protected int age;
        protected string sex;
        protected int hp = (new Random()).Next(1, 101);
        public abstract void showInfo();
        public abstract void goThroughCheckup();
        
        protected string dname;
        protected string dlname;
    }
    
    //Concrete component
    public class VirtualPatient: Patient {
        public VirtualPatient(string n, int a, string s) {
            ptname = n;
            age = a;
            sex = s;
        }
        public VirtualPatient(): this("John Doe", 20, "male") {}

        public override void showInfo() {
            Console.WriteLine($"\nName: {ptname}\nAge: {age}\nSex: {sex}\nHP: {hp}");
        }

        public override void goThroughCheckup() {
            Console.WriteLine("Going through virtual checkup...");
        }
    }
    
    //Decorator
    public abstract class Doctor: Patient {
        private Patient pt;

        protected Doctor() {
            Thread.Sleep(100);
            Random r = new Random();
            dname = Globals.names[r.Next(Globals.names.Count)];
            dlname = Globals.lastnames[r.Next(Globals.lastnames.Count)];
        }
        
        public void includeInCheckup(Patient basept) => pt = basept;
        
        public override void showInfo() {
            if (pt != null) pt.showInfo();
        }

        public override void goThroughCheckup() {
            if (pt != null) pt.goThroughCheckup();
        }
    }

    //Concrete decorators
    public class Orthopedist: Doctor {
        public override void showInfo() {
            base.showInfo();
            Console.WriteLine($"The patient has to go to {dname} {dlname} (orthopedist).");
        }
        
        public override void goThroughCheckup() {
            base.goThroughCheckup();
            if (hp >= 70)
                Console.WriteLine("...you have an awesome posture!");
            else 
                Console.WriteLine("...you seem to have some problems with your posture...");
        }
    }
    
    public class Neuropathologist: Doctor {
        public override void showInfo() {
            base.showInfo();
            Console.WriteLine($"The patient has to go to {dname} {dlname} (neuropathologist).");
        }
        
        public override void goThroughCheckup() {
            base.goThroughCheckup();
            if (hp >= 50)
                Console.WriteLine("...your nervous system is in great shape!");
            else
                Console.WriteLine("...you should see other doctors for your headaches! Here are some painkillers...");
        }
    }
    
    public class Otolaryngologist: Doctor {
        public override void showInfo() {
            base.showInfo();
            Console.WriteLine($"The patient has to go to {dname} {dlname} (otolaryngologist).");
        }
        
        public override void goThroughCheckup() {
            base.goThroughCheckup();
            if (hp >= 20)
                Console.WriteLine("...your respiratory tract and ears are healthy!");
            else
                Console.WriteLine("...there is some inflammation in your left ear...");
        }
    }
}