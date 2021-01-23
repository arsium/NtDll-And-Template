using System.Runtime.InteropServices;

namespace Native
{
    public class Kernel32
    {
        //Retrieves a pseudo handle for the calling thread.
        [DllImport("kernel32.dll")]
        public static unsafe extern void* GetCurrentThread();


        //Retrieves a pseudo handle for the current process.
        [DllImport("kernel32.dll")]
        public static unsafe extern void* GetCurrentProcess();


        //Retrieves the thread identifier of the calling thread.
        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();


        //Retrieves the process identifier of the specified process.
        [DllImport("kernel32.dll")]
        public static extern int GetCurrentProcessId();

    }
}
