#region Using statements

using System;
using System.Windows.Forms;

#endregion Using statements

namespace WeekNumber
{
    internal class WeekNumberContextMenu : IDisposable
    {
        #region Internal context menu

        internal ContextMenu ContextMenu { get; private set; }

        #endregion Internal context menu

        #region Internal contructor

        internal WeekNumberContextMenu()
        {
            Log.LogCaller();
            CreateContextMenu();
        }

        #endregion Internal constructor

        #region Private event handling

        private static void ExitMenuClick(object o, EventArgs e)
        {
            Log.LogCaller();
            Application.Exit();
        }

        #endregion Private event handling

        #region Private method for context menu creation

        internal void CreateContextMenu()
        {
            Log.LogCaller();
            ContextMenu = new ContextMenu(new MenuItem[1]
            {
                new MenuItem(Resources.ExitMenu, ExitMenuClick)
                {
                    DefaultItem = true
                }
            });
        }

        #endregion Private method for context menu creation

        #region IDisposable methods

        /// <summary>
        /// Disposes the context menu
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }
            CleanupContextMenu();
        }

        private void CleanupContextMenu()
        {
            Log.LogCaller();
            ContextMenu?.Dispose();
            ContextMenu = null;
        }

        #endregion IDisposable methods
    }
}