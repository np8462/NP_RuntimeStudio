using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.Core.IntelliSense
{
    public class SuggestionItem
    {
        public string Text
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string Extension
        {
            get;
            set;
        }

        public override string ToString()
        {
            try
            {
                string ext = "";

                if (!string.IsNullOrEmpty(
                    Extension))
                {
                    ext =
                        " (" +
                        Extension +
                        ")";
                }

                return
                    Text + ext;
            }
            catch
            {
                return Text;
            }
        }
    }
}