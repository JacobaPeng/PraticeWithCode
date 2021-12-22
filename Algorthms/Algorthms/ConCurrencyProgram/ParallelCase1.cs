using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorthms.ConCurrencyProgram
{
    internal class ParallelCase1
    {
        /// <summary>
        /// 多任务遍历树
        /// </summary>
        /// <param name="cureent"></param>
        void Traverse(TreeNode cureent) {
            //to do someting

            if (cureent.left!=null)
            {
                Task.Factory.StartNew(()=>Traverse(cureent.left),
                    CancellationToken.None,
                    TaskCreationOptions.AttachedToParent,
                    TaskScheduler.Default);
            }


            if (cureent.right != null)
            {
                Task.Factory.StartNew(() => Traverse(cureent.right),
                    CancellationToken.None,
                    TaskCreationOptions.AttachedToParent,
                    TaskScheduler.Default);
            }

        }

        void ProcessTree(TreeNode root) { 
            Task task = Task.Factory.StartNew(()=>Traverse(root), CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default);
            task.Wait();
        }

        /*----------------------------------PLINQ-------------------------------------------------*/

        IEnumerable<int> MultiplyBy2(IEnumerable<int> values) { 
            return values.AsParallel().AsOrdered().Select(i => i*2);    
        }
        int ParallelSum(IEnumerable<int> values)
        {
            return values.AsParallel().Sum();
        }
    }
}
