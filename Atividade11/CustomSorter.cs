namespace Atividade11
{
    public class CustomSorter {
    
        public List<int> SortDescending(List<int> numbers)
        {
            return numbers.OrderByDescending(n => n).ToList();
        }
    }
}
