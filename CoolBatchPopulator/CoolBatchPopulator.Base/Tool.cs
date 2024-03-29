﻿using System;
using System.Windows.Forms;
using System.Drawing;


namespace CoolBatchPopulator
{
	/// <summary>
	/// Base class for all drawing tools
	/// </summary>
	public abstract class Tool
	{

        /// <summary>
        /// Left nous button is pressed
        /// </summary>
        /// <param name="WorkArea"></param>
        /// <param name="e"></param>
        public virtual void OnMouseDown(WorkArea workarea, MouseEventArgs e)
        {
        }


        /// <summary>
        /// Mouse is moved, left mouse button is pressed or none button is pressed
        /// </summary>
        /// <param name="WorkArea"></param>
        /// <param name="e"></param>
        public virtual void OnMouseMove(WorkArea workarea, MouseEventArgs e)
        {
        }


        /// <summary>
        /// Left mouse button is released
        /// </summary>
        /// <param name="WorkArea"></param>
        /// <param name="e"></param>
        public virtual void OnMouseUp(WorkArea workarea, MouseEventArgs e)
        {
        }
    }
}