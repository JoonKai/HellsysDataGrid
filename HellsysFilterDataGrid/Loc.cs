using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellsysFilterDataGrid
{
    public enum Local
    {
        English,
        Korean
    }

    public class Loc
    {
        #region Private Fields

        private Local language;

        // culture name(used for dates)
        private static readonly Dictionary<Local, string> CultureNames = new Dictionary<Local, string>
        {
            { Local.English, "en-US" },
            { Local.Korean,  "ko-KR" },
        };

        /// <summary>
        /// Translation dictionary
        /// </summary>
        private static readonly Dictionary<string, Dictionary<Local, string>> Translation =
            new Dictionary<string, Dictionary<Local, string>>
            {
                {
                    "All", new Dictionary<Local, string>
                    {
                        { Local.English, "(Select all)" },
                        { Local.Korean,  "(Select all)" }
                    }
                },
                {
                    "Empty", new Dictionary<Local, string>
                    {
                        { Local.English, "(Blank)" },
                        { Local.Korean,  "(Blank)" }
                    }
                },
                {
                    "Clear", new Dictionary<Local, string>
                    {
                        { Local.English, "Clear filter \"{0}\"" },
                        { Local.Korean,  "Clear filter \"{0}\"" },
                    }
                },

                {
                    "Contains", new Dictionary<Local, string>
                    {
                        { Local.English, "Search (contains)" },
                        { Local.Korean,  "Search (contains)" },
                    }
                },

                {
                    "StartsWith", new Dictionary<Local, string>
                    {
                        { Local.English, "Search (startswith)" },
                        { Local.Korean,  "Search (startswith)" },
                    }
                },

                {
                    "Toggle", new Dictionary<Local, string>
                    {
                        { Local.English, "Toggle contains/startswith" },
                        { Local.Korean,  "Toggle contains/startswith" },
                    }
                },

                {
                    "Ok", new Dictionary<Local, string>
                    {
                        { Local.English, "Ok" },
                        { Local.Korean,  "Ok" },
                    }
                },
                {
                    "Cancel", new Dictionary<Local, string>
                    {
                        { Local.English, "Cancel" },
                        { Local.Korean,  "Cancel" },
                    }
                },
                {
                    "Status", new Dictionary<Local, string>
                    {
                        { Local.English, "{0:n0} record(s) found on {1:n0}" },
                        { Local.Korean,  "{0:n0} record(s) found on {1:n0}" },
                    }
                },
                {
                    "ElapsedTime", new Dictionary<Local, string>
                    {
                        { Local.English, "Elapsed time {0:mm}:{0:ss}.{0:ff}" },
                        { Local.Korean,  "Elapsed time {0:mm}:{0:ss}.{0:ff}" },
                    }
                }
            };

        #endregion Private Fields

        #region Constructors

        public Loc()
        {
            Language = Local.English;
        }

        #endregion Constructors

        #region Public Properties

        public Local Language
        {
            get => language;
            set
            {
                language = value;
                Culture = new CultureInfo(CultureNames[value]);
            }
        }

        public CultureInfo Culture { get; private set; }

        public string CultureName => CultureNames[Language];

        public string LanguageName => Enum.GetName(typeof(Local), Language);

        public string All => Translate("All");

        public string Cancel => Translate("Cancel");

        public string Clear => Translate("Clear");

        public string Contains => Translate("Contains");

        public string ElapsedTime => Translate("ElapsedTime");

        public string Empty => Translate("Empty");

        public string Ok => Translate("Ok");

        public string StartsWith => Translate("StartsWith");

        public string Status => Translate("Status");

        public string Toggle => Translate("Toggle");

        #endregion Public Properties

        #region Private Methods

        /// <summary>
        /// Translated into the language
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private string Translate(string key)
        {
            return Translation.ContainsKey(key) && Translation[key].ContainsKey(Language)
                ? Translation[key][Language]
                : "unknow";
        }

        #endregion Private Methods
    }
}
