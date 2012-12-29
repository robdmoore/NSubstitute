using System;

namespace NSubstitute.Core
{
    public class DisposableAction : IDisposable
    {
        private readonly Action _action;

        public DisposableAction(Action action)
        {
            _action = action;
        }

        public void Dispose()
        {
            _action();
        }

        public static readonly DisposableAction EmptyAction = new DisposableAction(() => {});
    }
}
