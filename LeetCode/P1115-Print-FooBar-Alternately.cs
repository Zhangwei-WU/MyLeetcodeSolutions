namespace LeetCode.P1115
{
    using System;
    using System.Threading;

    public class FooBar
    {
        private int n;
        SemaphoreSlim mutexFoo = new SemaphoreSlim(1, 1);
        SemaphoreSlim mutexBar = new SemaphoreSlim(0, 1);

        public FooBar(int n)
        {
            this.n = n;
        }

        public void Foo(Action printFoo)
        {

            for (int i = 0; i < n; i++)
            {
                mutexFoo.Wait();
                // printFoo() outputs "foo". Do not change or remove this line.
                printFoo();
                mutexBar.Release();
            }
        }

        public void Bar(Action printBar)
        {

            for (int i = 0; i < n; i++)
            {
                mutexBar.Wait();
                // printBar() outputs "bar". Do not change or remove this line.
                printBar();
                mutexFoo.Release();
            }
        }
    }
}
