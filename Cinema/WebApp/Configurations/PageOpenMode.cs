namespace WebApp.Configurations
{
    public enum PageModes 
    {
        Add,
        Update
    }
    public static class PageOpenMode
    {
        private static Queue<PageModes> _modeQueue;
        //constructor
        static PageOpenMode()
        {
            _modeQueue = new Queue<PageModes>();
        }
        public static PageModes DequeueCurrentPageMode ()
        {
            return _modeQueue.Count == 0 ? PageModes.Add : _modeQueue.Dequeue();
        }
        public static PageModes PeekCurrentPageMode()
        {
            return _modeQueue.Count == 0 ? PageModes.Add : _modeQueue.Peek();
        }
        public static void OpenNextPageInSettingMode(PageModes mode)
        {
            _modeQueue.Enqueue(mode);
        }
    }
}
