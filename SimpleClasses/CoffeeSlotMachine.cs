using System;

namespace SimpleClasses
{
    public class CoffeeSlotMachine
    {
        private const int Price = 50;  // Einheitspreis für alle Produkte
        readonly private int[] _coinValues = new int[] { 5, 10, 20, 50, 100, 200 };
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
            bool orderIsValid;
            bool nameNotFound = true;
            int productArrayCounter = 0;
            returnCoins = new int[] { 0, 0, 0, 0, 0, 0 };
            donation = 0;

            if (CurrentMoney < Price)
            {
                orderIsValid = false;
            }
            else
            {
                while (productArrayCounter < _productNames.Length && nameNotFound)
                {
                    if (productName.Equals(_productNames[productArrayCounter]))
                    {
                        nameNotFound = false;
                    }
                    if (nameNotFound)
                    {
                        productArrayCounter++;
                    }
                }

                if (nameNotFound)
                {
                    orderIsValid = false;
                }
                else
                {
                    orderIsValid = true;
                    _productCounter[productArrayCounter]++;
                    int moneySum = CurrentMoney;
                    int checkSum = 0;

                    for (int i = 0; i < _coinDepot.Length; i++)
                    {
                        _coinDepot[i] += _currentCoins[i];
                        _currentCoins[i] = 0;
                    }

                    if (moneySum > Price)
                    {
                        //200 - 50 = 150 --> 100+50
                        moneySum = moneySum - Price;
                        checkSum = moneySum;
                        do
                        {
                            if (moneySum >= 200 && checkSum >= 200)
                            {
                                GetCounterForCoin(200, out int count);
                                if (count > 0)
                                {
                                    _coinDepot[5]--;
                                    returnCoins[5]++;
                                    moneySum -= 200;
                                }
                                else
                                {
                                    checkSum = 100;
                                }
                            }
                            else if (moneySum >= 100 && checkSum >= 100)
                            {
                                GetCounterForCoin(100, out int count);
                                if (count > 0)
                                {
                                    _coinDepot[4]--;
                                    returnCoins[4]++;
                                    moneySum -= 100;
                                }
                                else
                                {
                                    checkSum = 50;
                                }
                            }
                            else if (moneySum >= 50 && checkSum >= 50)
                            {
                                GetCounterForCoin(50, out int count);
                                if (count > 0)
                                {
                                    _coinDepot[3]--;
                                    returnCoins[3]++;
                                    moneySum -= 50;
                                }
                                else
                                {
                                    checkSum = 20;
                                }
                            }
                            else if (moneySum >= 20 && checkSum >= 20)
                            {
                                GetCounterForCoin(20, out int count);
                                if (count > 0)
                                {
                                    _coinDepot[2]--;
                                    returnCoins[2]++;
                                    moneySum -= 20;
                                }
                                else
                                {
                                    checkSum = 10;
                                }
                            }
                            else if (moneySum >= 10 && checkSum >= 10)
                            {
                                GetCounterForCoin(10, out int count);
                                if (count > 0)
                                {
                                    _coinDepot[1]--;
                                    returnCoins[1]++;
                                    moneySum -= 10;
                                }
                                else
                                {
                                    checkSum = 5;
                                }
                            }
                            else
                            {
                                GetCounterForCoin(5, out int count);
                                if (count > 0)
                                {
                                    _coinDepot[0]--;
                                    returnCoins[0]++;
                                    moneySum -= 5;
                                }
                                else
                                {
                                    donation += moneySum;
                                    moneySum = 0;
                                }
                            }
                        } while (moneySum > 0);
                    }
                    else
                    {
                        //returnCoins --> 0
                        //donation --> 0
                    }
                }
            }

            return orderIsValid;
        }

        /// <summary>
        /// Die aktuelle Bestellung wird abgebrochen.
        /// Die Anzahl der eingeworfenen Münzen wird je Wert 5c-200c in einem
        /// Array zurückgegeben (5 cent == Index:0, 200 cent == Index 5
        /// </summary>
        /// <returns>Array mit der Anzahl der Münzen je Wert</returns>
        public int[] CancelOrder()
        {
            int[] coinsToReturn = new int[_currentCoins.Length];
            for (int i = 0; i < coinsToReturn.Length; i++)
            {
                coinsToReturn[i] = _currentCoins[i];
            }
            _currentCoins = new int[coinsToReturn.Length];
            return coinsToReturn;
        }

        /// <summary>
        /// Depot leeren und Summe des Inhalts zurückgeben
        /// </summary>
        /// <returns></returns>
        public int EmptyDepot()
        {
            int sum = 0;
            for (int i = 0; i < _coinDepot.Length; i++)
            {
                sum += _coinDepot[i] * _coinValues[i];
            }
            int index = _coinDepot.Length;
            _coinDepot = new int[index];
            return sum;
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
            bool isValidProductName = false;
            int count = 0;
            counter = 0;

            do
            {
                if (productName.Equals(_productNames[count]))
                {
                    isValidProductName = true;
                    counter = _productCounter[count];
                }
                count++;
            } while (count < _productNames.Length && !isValidProductName);

            return isValidProductName;
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
            bool isValidCoinValue = false;
            int count = 0;
            counter = 0;

            do
            {
                if (coinValue == _coinValues[count])
                {
                    isValidCoinValue = true;
                    counter = _coinDepot[count];
                }
                count++;
            } while (count < _coinValues.Length && !isValidCoinValue);

            return isValidCoinValue;
        }
    }
}