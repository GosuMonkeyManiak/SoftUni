using System;

namespace Farm
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Dog shoro = new Dog();

            shoro.Eat();
            shoro.Bark();

            Puppy shoro2 = new Puppy();

            shoro2.Weep();
            shoro2.Bark();

            Cat newCat = new Cat();

            newCat.Meow();
        }
    }
}
