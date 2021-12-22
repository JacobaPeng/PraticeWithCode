using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorthms.ConCurrencyProgram
{
    public  class TaskResult : IMyAsyncInterface
    {
        public Task<int> GetValueAsync(CancellationToken cancellationToken)
        {
            try
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    return Task.FromCanceled<int>(cancellationToken);
                }
                //任务完成返回值0
                return Task.FromResult(0);
                //无返回值，返回任何完成
                //return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.FromResult(-1);

                //return Task.FromException(ex)
            }
           
        }

        public Task<int> GetValueAsync()
        {
            throw new NotImplementedException();
        }
    }
    public interface IMyAsyncInterface
    {
        Task<int> GetValueAsync();
    }
}
