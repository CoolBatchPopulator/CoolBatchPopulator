using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;

namespace CoolBatchPopulator
{
    public class GraphicsList
    {
        private ArrayList graphicsList;

        public GraphicsList()
        {
            graphicsList = new ArrayList();
        }

        public void Draw(Graphics g)
        {
            int n = graphicsList.Count;
            DrawObject o;

            // Enumerate list in reverse order
            // to get first object on the top
            for (int i = n - 1; i >= 0; i-- )
            {
                o = (DrawObject)graphicsList[i];

                o.Draw(g);

                if ( o.Selected == true )
                {
                    o.DrawTracker(g);
                }
            }
        }

        /// <summary>
        /// Clear all objects in the list
        /// </summary>
        /// <returns>
        /// true if at least one object is deleted
        /// </returns>
        public bool Clear()
        {
            bool result = (graphicsList.Count > 0);
            graphicsList.Clear();
            return result;
        }

        /// <summary>
        /// Count and this [nIndex] allow to read all graphics objects
        /// from GraphicsList in the loop.
        /// </summary>
        public int Count
        {
            get
            {
                return graphicsList.Count;
            }
        }

        public DrawObject this [int index]
        {
            get
            {
                if ( index < 0  ||  index >= graphicsList.Count )
                    return null;

                return ((DrawObject)graphicsList[index]);
            }
        }

        /// <summary>
        /// SelectedCount and GetSelectedObject allow to read
        /// selected objects in the loop
        /// </summary>
        public int SelectionCount
        {
            get
            {
                int n = 0;

                foreach (DrawObject o in graphicsList)
                {
                    if ( o.Selected )
                        n++;
                }

                return n;
            }
        }

        public DrawObject GetSelectedObject(int index)
        {
            int n = -1;

            foreach (DrawObject o in graphicsList)
            {
                if ( o.Selected )
                {
                    n++;

                    if ( n == index )
                        return o;
                }
            }

            return null;
        }

        public IEnumerable<DrawObject> Selection
        {
            get
            {
                foreach (DrawObject o in graphicsList)
                {
                    if (o.Selected)
                    {
                        yield return o;
                    }
                }
            }
        }


        public void Add(DrawObject obj)
        {
            // insert to the top of z-order
            graphicsList.Insert(0, obj);
        }

        public void SelectInRectangle(Rectangle rectangle)
        {
            UnselectAll();

            foreach (DrawObject o in graphicsList)
            {
                if ( o.IntersectsWith(rectangle) )
                    o.Selected = true;
            }

        }

        public void UnselectAll()
        {
            foreach (DrawObject o in graphicsList)
            {
                o.Selected = false;
            }
        }

        public void SelectAll()
        {
            foreach (DrawObject o in graphicsList)
            {
                o.Selected = true;
            }
        }

        /// <summary>
        /// Delete selected items
        /// </summary>
        /// <returns>
        /// true if at least one object is deleted
        /// </returns>
        public bool DeleteSelection()
        {
            bool result = false;

            int n = graphicsList.Count;

            for ( int i = n-1; i >= 0; i-- )
            {
                if ( ((DrawObject)graphicsList[i]).Selected )
                {
                    graphicsList.RemoveAt(i);
                    result = true;
                }
            }

            return result;
        }


        /// <summary>
        /// Move selected items to front (beginning of the list)
        /// </summary>
        /// <returns>
        /// true if at least one object is moved
        /// </returns>
        public bool MoveSelectionToFront()
        {
            int n;
            int i;
            ArrayList tempList;

            tempList = new ArrayList();
            n = graphicsList.Count;

            // Read source list in reverse order, add every selected item
            // to temporary list and remove it from source list
            for ( i = n - 1; i >= 0; i-- )
            {
                if ( ((DrawObject)graphicsList[i]).Selected )
                {
                    tempList.Add(graphicsList[i]);
                    graphicsList.RemoveAt(i);
                }
            }

            // Read temporary list in direct order and insert every item
            // to the beginning of the source list
            n = tempList.Count;

            for ( i = 0; i < n; i++ )
            {
                graphicsList.Insert(0, tempList[i]);
            }

            return ( n > 0 );
        }

        /// <summary>
        /// Move selected items to back (end of the list)
        /// </summary>
        /// <returns>
        /// true if at least one object is moved
        /// </returns>
        public bool MoveSelectionToBack()
        {
            int n;
            int i;
            ArrayList tempList;

            tempList = new ArrayList();
            n = graphicsList.Count;

            // Read source list in reverse order, add every selected item
            // to temporary list and remove it from source list
            for ( i = n - 1; i >= 0; i-- )
            {
                if ( ((DrawObject)graphicsList[i]).Selected )
                {
                    tempList.Add(graphicsList[i]);
                    graphicsList.RemoveAt(i);
                }
            }

            // Read temporary list in reverse order and add every item
            // to the end of the source list
            n = tempList.Count;

            for ( i = n - 1; i >= 0; i-- )
            {
                graphicsList.Add(tempList[i]);
            }

            return ( n > 0 );
        }

     
        //private ObjectProperties GetProperties()
        //{
        //    ObjectProperties properties = new ObjectProperties();

        //    int n = SelectionCount;

        //    if ( n < 1 )
        //        return properties;

        //    DrawObject o = GetSelectedObject(0);

        //    int firstColor = o.Color.ToArgb();
        //    int firstPenWidth = o.PenWidth;

        //    bool allColorsAreEqual = true;
        //    bool allWidthAreEqual = true;

        //    for ( int i = 1; i < n; i++ )
        //    {
        //        if ( GetSelectedObject(i).Color.ToArgb() != firstColor )
        //            allColorsAreEqual = false;

        //        if ( GetSelectedObject(i).PenWidth != firstPenWidth )
        //            allWidthAreEqual = false;
        //    }

        //    if ( allColorsAreEqual )
        //    {
        //        properties.ColorDefined = true;
        //        properties.Color = Color.FromArgb(firstColor);
        //    }

        //    if ( allWidthAreEqual )
        //    {
        //        properties.PenWidthDefined = true;
        //        properties.PenWidth = firstPenWidth;
        //    }

        //    return properties;
        //}

    
        //private void ApplyProperties(GraphicsProperties properties)
        //{
        //    foreach ( DrawObject o in graphicsList )
        //    {
        //        if ( o.Selected )
        //        {
        //            if ( properties.ColorDefined )
        //            {
        //                o.Color = properties.Color;
        //                DrawObject.LastUsedColor = properties.Color;
        //            }

        //            if ( properties.PenWidthDefined )
        //            {
        //                o.PenWidth = properties.PenWidth;
        //                DrawObject.LastUsedPenWidth = properties.PenWidth;
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// Show Properties dialog. Return true if list is changed
        ///// </summary>
        ///// <param name="parent"></param>
        ///// <returns></returns>
        //public bool ShowPropertiesDialog(IWin32Window parent)
        //{
        //    if ( SelectionCount < 1 )
        //        return false;

        //    GraphicsProperties properties = GetProperties();
        //    PropertiesDialog dlg = new PropertiesDialog();
        //    dlg.Properties = properties;

        //    if ( dlg.ShowDialog(parent) != DialogResult.OK )
        //        return false;

        //    ApplyProperties(properties);

        //    return true;
        //}
	}
}
