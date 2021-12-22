using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorthms.ConCurrencyProgram
{
    public class PrograssReport
    {

        public static async Task MymethoAsync(IProgress<double> progress = null)
        {
            bool done = false;
            double percentComplete = 0;
            while (!done)
            {
                percentComplete++;
                if (percentComplete == 100)
                {
                    done = true;
                }
                progress?.Report(percentComplete);

                Task.Delay(100).Wait();
            }
        }


        public static async Task CallMymethodAsync()
        {
            var progress = new Progress<double>();
            progress.ProgressChanged += (sender, args) => {
                Console.WriteLine(args);
            };

            await MymethoAsync(progress);
        }

    }
}
