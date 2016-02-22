using System.Collections.Generic;
using System.Globalization;
using Windows.Globalization.Collation;

namespace CXS.Mpos.POS.Windows.Pages.CustomersPage
{
    public class AlphaKeyGroup<T> : List<T>
    {
        public delegate string GetKeyDelegate(T item);

        public string Key { get; private set; }

        public AlphaKeyGroup(string key)
        {
            Key = key;
        }

        private static List<AlphaKeyGroup<T>> CreateGroups(CharacterGroupings slg)
        {
            List<AlphaKeyGroup<T>> list = new List<AlphaKeyGroup<T>>();

            foreach (CharacterGrouping key in slg)
            {
                if (string.IsNullOrWhiteSpace(key.Label) == false)
                    list.Add(new AlphaKeyGroup<T>(key.Label));
            }

            return list;
        }

        public static List<AlphaKeyGroup<T>> CreateGroups(IEnumerable<T> items, CultureInfo ci, GetKeyDelegate getKey, bool sort)
        {
            CharacterGroupings slg = new CharacterGroupings();
            List<AlphaKeyGroup<T>> list = CreateGroups(slg);

            foreach (T item in items)
            {
                string index = "";
                index = slg.Lookup(getKey(item));
                if (string.IsNullOrEmpty(index) == false)
                {
                    list.Find(a => a.Key == index).Add(item);
                }
            }

            if (sort)
            {
                foreach (AlphaKeyGroup<T> group in list)
                {
                    group.Sort((c0, c1) => { return ci.CompareInfo.Compare(getKey(c0), getKey(c1)); });
                }
            }

            return list;
        }

    }
}
