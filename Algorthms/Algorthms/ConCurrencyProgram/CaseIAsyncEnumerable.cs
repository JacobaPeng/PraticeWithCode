using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorthms.ConCurrencyProgram
{
    public class CaseIAsyncEnumerable
    {
        public async IAsyncEnumerable<string> GetValuesAsync(HttpClient client) {

            int offset = 0;
            const int limit = 10;
            while (true)
            {
                string result = await client.GetStringAsync($"https://xxx/api/values?offset={offset}&limit={limit}");
                string[] valuesOnThisPage=result.Split('\n');

                //生成此页的结果
                foreach (string value in valuesOnThisPage)
                {
                    yield return value;
                }
                //若为最后一页，则工作结束
                if (valuesOnThisPage.Length!=limit)
                {
                    break;
                }
                //继续下一页
                offset += limit;
            }
        }
        /// <summary>
        /// /调用异步流
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public async Task ProcessValueAsync(HttpClient client) {
            await foreach (string value in GetValuesAsync(client).ConfigureAwait(false))
            {
                await Task.Delay(100).ConfigureAwait(false);    //使用configawait false避免隐式捕获上下文
                Console.WriteLine(value);   
            }
        }
    }
}
