using Breakfast.Ingredients;

namespace Breakfast
{
    class Program
    {
        // Wenn Sie Erfahrung mit dem Kochen haben, würden Sie diese Anweisungen asynchron ausführen. Sie würden erst die Pfanne für die Eier vorwärmen und dann den Speck zubereiten. Sie würden das Brot in den Toaster stecken und dann mit den Eiern beginnen. Bei jedem Schritt des Prozesses würden Sie eine Aufgabe beginnen und sich dann den Aufgaben zuwenden, die Ihre Aufmerksamkeit erfordern.

        static async Task Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            await ProcessTaskResultsInOrderTheyAreCompleted(eggsTask, baconTask, toastTask);

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
        }

        private static async Task ProcessTaskResultsInOrderTheyAreCompleted(Task<Egg> eggsTask, Task<Bacon> baconTask, Task toastTask)
        {
            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (breakfastTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggsTask)
                {
                    Console.WriteLine("eggs are ready");
                }
                else if (finishedTask == baconTask)
                {
                    Console.WriteLine("bacon is ready");
                }
                else if (finishedTask == toastTask)
                {
                    Console.WriteLine("toast is ready");
                }
                breakfastTasks.Remove(finishedTask);
            }
        }

        private static async Task MakeToastWithButterAndJamAsync(int slices)
        {   
            Toast toast = await ToastBreadAsync(slices);;
            ApplyButter(toast);
            ApplyJam(toast);
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Juice: Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) => 
            Console.WriteLine("Toast: Putting jam on the toast");

        private static void ApplyButter(Toast toast) => 
            Console.WriteLine("Toast: Putting butter on the toast");

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Toast: Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Toast: Start toasting...");
            await Task.Delay(2000);
            // Console.WriteLine("Toast: Fire! Toast is ruined!");
            // throw new InvalidOperationException("Toast: The toaster is on fire");
            await Task.Delay(1000);
            Console.WriteLine("Toast: Remove toast from toaster");

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"Bacon: putting {slices} slices of bacon in the pan");
            Console.WriteLine("Bacon: cooking first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Bacon: flipping a slice of bacon");
            }
            Console.WriteLine("Bacon: cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Bacon: Put bacon on plate");

            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Egg: Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"Egg: cracking {howMany} eggs");
            Console.WriteLine("Egg: cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Egg: Put eggs on plate");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Coffee: Pouring coffee");
            return new Coffee();
        }
    }
}