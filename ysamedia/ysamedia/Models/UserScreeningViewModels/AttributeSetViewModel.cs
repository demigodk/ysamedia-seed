using System.Collections.Generic;

namespace ysamedia.Models.UserScreeningViewModels
{
    public class AttributeSetViewModel
    {
        public List<int> PosAttribute { get; set; }
       
        public List<int> NegAttribute { get; set; }

        public int[] SelectedValues { get; set; }
    }
}
