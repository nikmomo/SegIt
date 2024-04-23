using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorDataSegmentation
{
    /// <summary>
    /// Manages keyboard shortcuts and executes associated actions.
    /// </summary>
    public class ShortcutManager
    {
        private Dictionary<Keys, Action> shortcuts;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShortcutManager"/> class.
        /// </summary>
        public ShortcutManager()
        {
            shortcuts = new Dictionary<Keys, Action>();
        }

        /// <summary>
        /// Registers a keyboard shortcut with the specified action.
        /// </summary>
        /// <param name="keyCombo">The key combination of the shortcut.</param>
        /// <param name="action">The action to be executed when the shortcut is triggered.</param>
        public void RegisterShortcut(Keys keyCombo, Action action)
        {
            shortcuts[keyCombo] = action;
        }

        /// <summary>
        /// Executes the action associated with the specified keyboard shortcut, if any.
        /// </summary>
        /// <param name="keyCombo">The key combination to check.</param>
        /// <returns>True if the shortcut was found and executed successfully; otherwise, false.</returns>
        public bool ExecuteShortcut(Keys keyCombo)
        {
            if (shortcuts.TryGetValue(keyCombo, out Action action))
            {
                action?.Invoke();
                return true;
            }
            return false;
        }
    }
}
