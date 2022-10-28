using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;


namespace my_priority_queue
{
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [Guid("F3442FB2-8003-42FA-8FBD-CF76467A3C3D")]
    public interface IPriorityQueue
    {
        void pushValue(int v, int p);

        int popValue();

    }

    public class queueItem {
        public int value;
        public int priority;
        public queueItem(int v, int p) {
            this.value = v;
            this.priority = p;
        }
    }

    [ClassInterface(ClassInterfaceType.None)]
    [Guid("0957F186-2C36-4D95-925A-E3338DAAFA5E")]
    [ProgId("my_custom_queue")]
    public class PriorityQueue : IPriorityQueue {

        public List<queueItem> queueItems = new List<queueItem>();

        

        public void pushValue(int v, int p) {
            this.queueItems.Add(new queueItem(v, p));
        }

       
        public int popValue() {

            int higest_p = this.queueItems[0].priority;
            foreach (var el in this.queueItems) 
            {
                if (el.priority > higest_p) 
                {
                    higest_p = el.priority;
                }     
            }

            int value_to_return;
            foreach (var el in this.queueItems) { 
                if(el.priority == higest_p)
                {
                    value_to_return = el.value;
                    this.queueItems.Remove(el);
                    return value_to_return; 
                }
            }

            throw new Exception("queue is empty");
        }
        
    }


}
