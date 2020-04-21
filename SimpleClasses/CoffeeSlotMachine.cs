using System;

namespace SimpleClasses
{
    public class CoffeeSlotMachine
    {
        private const int Price = 50;  // Einheitspreis für alle Produkte
        private int[] _coinValues = new int[] { 5, 10, 20, 50, 100, 200 };
        private int[] _coinDepot;
        private int[] _currentCoins;
        private string[] _productNames;
        private int[] _productCounter;

        /// <summary>
        /// Parameterloser Constructor initialisiert das Depot mit jeweils drei Münzen
        /// und die Produkte mit den drei Standardprodukten Cappuccino, Mocca, Kakao
        /// </summary>
        public CoffeeSlotMachine() : this(new int[] { 3, 3, 3, 3, 3, 3 }, new string[] { "Cappuccino", "Mocca", "Kakao" })
        {
        }

        /// <summary>
        /// Sowohl das Münzdepot als auch die produkte werden übergeben
        /// </summary>
        /// <param name="coinDepot"></param>
        /// <param name="productNames"></param>
        public CoffeeSlotMachine(int[] coinDepot, string[] productNames)
        {
            _coinDepot = coinDepot;
            _productNames = productNames;
            _currentCoins = new int[_coinDepot.Length];
            _productCounter = new int[_productNames.Length];
        }

        /// <summary>
        /// Summe des aktuell eingeworfenen Geldes
        /// </summary>
        public int CurrentMoney
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < _coinValues.Length; i++)
                {
                    sum += _coinValues[i] * _currentCoins[i];
                }
                return sum;
            }
        }

        /// <summary>
        /// Wie viele Münzen befinden sich im Münzdepot
        /// </summary>
        public int CoinsInDepot
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < _coinDepot.Length; i++)
                {
                    sum += _coinDepot[i];
                }
                return sum;
            }
        }

        /// <summary>
        /// Wie viele Produkte sind verfügbar
        /// </summary>
        public int ProductsAvailable
        {
            get
            {
                return _productNames.Length;
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
            bool isValid = true;

            if (CurrentMoney < Price)
            {
                switch (coinValue)
                {
                    case 5:
                        _currentCoins[0]++;
                        break;

                    case 10:
                        _currentCoins[1]++;
                        break;

                    case 20:
                        _currentCoins[2]++;
                        break;

                    case 50:
                        _currentCoins[3]++;
                        break;

                    case 100:
                        _currentCoins[4]++;
                        break;

                    case 200:
                        _currentCoins[5]++;
                        break;

                    default:
                        isValid = false;
                        break;
                }
            }
            else
            {
                isValid = false;
            }

            return isValid;
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