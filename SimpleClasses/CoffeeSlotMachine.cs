using System;

namespace SimpleClasses
{
    public class CoffeeSlotMachine
    {
        const int Price = 50;  // Einheitspreis für alle Produkte

        /// <summary>
        /// Parameterloser Constructor initialisiert das Depot mit jeweils drei Münzen
        /// und die Produkte mit den drei Standardprodukten Cappuccino, Mocca, Kakao
        /// </summary>
        public CoffeeSlotMachine()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sowohl das Münzdepot als auch die produkte werden übergeben
        /// </summary>
        /// <param name="coinDepot"></param>
        /// <param name="productNames"></param>
        public CoffeeSlotMachine(int[] coinDepot, string[] productNames) 
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Summe des aktuell eingeworfenen Geldes
        /// </summary>
        public int CurrentMoney
        {
            get 
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Wie viele Münzen befinden sich im Münzdepot
        /// </summary>
        public int CoinsInDepot 
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Wie viele Produkte sind verfügbar
        /// </summary>
        public int ProductsAvailable
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        /// <summary>
        /// Eine Münze wird eingeworfen. Der Wert wird in Cent angegeben
        /// Ungültige Werte (z.B. 17) fallen genau so durch, wie unzulässige
        /// Münzen (1 Cent, 2 Cent). Wurden schon zumindest 50 Cent eingeworfen,
        /// fällt die Münze ebenfalls durch.
        /// </summary>
        /// <param name="coinValue"></param>
        /// <returns>Wurde die Münze übernommen</returns>
        public bool InsertCoin(int coinValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Der Kunde wählt das Produkt aus. Falls es existiert, wird der
        /// jeweilige Produktzähler erhöht und das geld eingenommen.
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="returnCoins"></param>
        /// <param name="donation">Spende, die nicht mehr zurükgegeben werden konnte</param>
        /// <returns>Existiert das Produkt</returns>
        public bool SelectProduct(string productName, out int[] returnCoins, out int donation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Die aktuelle Bestellung wird abgebrochen. 
        /// Die Anzahl der eingeworfenen Münzen wird je Wert 5c-200c in einem
        /// Array zurückgegeben (5 cent == Index:0, 200 cent == Index 5
        /// </summary>
        /// <returns>Array mit der Anzahl der Münzen je Wert</returns>
        public int[] CancelOrder()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Depot leeren und Summe des Inhalts zurückgeben
        /// </summary>
        /// <returns></returns>
        public int EmptyDepot()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Liest den aktuellen Produktzählerstand für 
        /// das Produkt aus.
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="counter">aktueller Produktzählerstand</param>
        /// <returns>true, wenn das Produkt existiert</returns>
        public bool GetCounterForProduct(string productName, out int counter)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Liest den aktuellen Produktzählerstand für 
        /// das Produkt aus.
        /// </summary>
        /// <param name="coinValue"></param>
        /// <param name="counter">aktueller Produktzählerstand</param>
        /// <returns>true, wenn die Münze existiert</returns>
        public bool GetCounterForCoin(int coinValue, out int counter)
        {
            throw new NotImplementedException();
        }
    }
}
