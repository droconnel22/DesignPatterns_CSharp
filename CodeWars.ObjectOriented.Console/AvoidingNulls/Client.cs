using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.ObjectOriented.Console.AvoidingNulls
{
    class Client
    {
        static void ClaimWarranty(SoldArticle article)
        {
            DateTime now = DateTime.Now;

            article.MoneyBackGuarantee.Claim(now, ()=> System.Console.Write("Offer Money Back"));

            //if (article.ExpressTimeLimtedWarranty.IsValidOn(now))
            //{
            //    System.Console.WriteLine("Offer repair");
            //}

        }

        static void Main(string[] args)
        {
          DateTime sellingDate = new DateTime(2016,8,9);
            TimeSpan moneyBackSpan = TimeSpan.FromDays(30);
            TimeSpan warrantySpan = TimeSpan.FromDays(365);

            IWarranty moneyBack = new TimeLimtedWarranty(sellingDate,moneyBackSpan);
            IWarranty warranty = new TimeLimtedWarranty(sellingDate,warrantySpan);

            IWarranty lifetimeWarranty = new LifetimeWarranty(sellingDate);
            
            IWarranty noMoneyBack = VoidWarranty.Instance;

            SoldArticle goods = new SoldArticle(noMoneyBack, warranty);
            ClaimWarranty(goods);

        }
    }
}
