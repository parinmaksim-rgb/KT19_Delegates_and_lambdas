namespace KT19
{
    using System;
    using System.Collections.Generic;

    public class NumberProcessor
    {
        private const int EvenDivisor = 2;
        private const int EvenRemainder = 0;

        public Func<int, bool> IsEven { get; set; }
        public Func<int, int> Square { get; set; }
        public Action<int> PrintToScreen { get; set; }
        public Action<int> SaveToList { get; set; }
        public Action<int> CombinedAction { get; set; }

        public NumberProcessor(List<int> targetList)
        {
            IsEven = n => n % EvenDivisor == EvenRemainder;
            Square = n => n * n;
            PrintToScreen = n => Console.Write(n + " ");
            SaveToList = n => targetList.Add(n);

            CombinedAction = PrintToScreen;
            CombinedAction += SaveToList;
        }
    }
}