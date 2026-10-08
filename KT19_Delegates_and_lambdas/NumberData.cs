namespace KT19
{
    using System.Collections.Generic;

    public class NumberData
    {
        public List<int> Numbers { get; set; }
        public List<int> SavedResults { get; set; }

        public NumberData()
        {
            Numbers = new List<int>();
            SavedResults = new List<int>();
        }
    }
}