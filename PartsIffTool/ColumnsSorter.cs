using System;
using System.Collections;
using System.Windows.Forms;

namespace PartsIffTool
{
    public class ColumnsSorter : IComparer
    {
        private readonly int _column;
        private readonly SortOrder _sortOrder;

        public ColumnsSorter(int column, SortOrder sortOrder)
        {
            _column = column;
            _sortOrder = sortOrder;
        }

        #region IComparer Members

        public int Compare(object x, object y)
        {
            try
            {
                int intResult = String.Compare((((ListViewItem)x).SubItems[_column].Text),
                                           ((ListViewItem)y).SubItems[_column].Text);

                if (_sortOrder == SortOrder.Descending)
                    intResult = intResult * -1;

                return intResult;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #endregion
    }
}
