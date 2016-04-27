using System.Collections;
using System.Collections.ObjectModel;
using System.Data.Common;

namespace GUI.Model
{
    class ListCategories:ObservableCollection<DbDataRecord>
    {
        public ListCategories()
        {
            ArrayList categories = HotelClassLibrary.DataLayer.GetAllCategories();

            foreach (DbDataRecord v in categories)
                this.Add(v);
        }
    }
}
