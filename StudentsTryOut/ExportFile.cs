using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTryOut
{
    [Serializable]
    class ExportFile
    {
        public string Export(List<string> imput, string path)
        {
            try
            {
                FileStream aFile = new FileStream(path, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(aFile);

                //Write data to file
                for (int i = 0; i < imput.Count; i++)
                {
                    sw.WriteLine(imput[i]);
                }

                sw.Close();

                return "Success";
            }
            catch (IOException e)
            {
                return e.ToString();
            }
        }

    }
}
