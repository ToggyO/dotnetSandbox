using System.Threading;
using System.Threading.Tasks;

namespace Threads.Transaction
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Balance { get; set; }

        public static void Transfer(Person buyer, Person seller, decimal amount)
        {
            var lock1 = buyer.Id < seller.Id ? buyer : seller;
            var lock2 = buyer.Id < seller.Id ? seller : buyer;
            lock (lock1)
            {
                Thread.Sleep(3000);
                lock (lock2)
                {
                    if (buyer.Balance >= amount)
                    {
                        buyer.Balance -= amount;
                        seller.Balance += amount;
                    }
                }
            }
        }
        
        public static Task TransferAsync(Person buyer, Person seller, decimal amount)
            => Task.Run(() => Transfer(buyer, seller, amount));
    }
}