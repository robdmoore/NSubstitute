using NSubstitute.Core;

namespace NSubstitute.Routing.Handlers
{
    public class RecordCallHandler : ICallHandler
    {
        private readonly ICallStack _callStack;
        private readonly SequenceNumberGenerator _generator;

        public RecordCallHandler(ICallStack callStack, SequenceNumberGenerator generator)
        {
            _callStack = callStack;
            _generator = generator;
        }

        public RouteAction Handle(ICall call)
        {
            if (!SubstitutionContext.Current.IsHandlingCall(call))
                return RouteAction.Continue();

            call.AssignSequenceNumber(_generator.Next());
            _callStack.Push(call);
            return RouteAction.Continue();
        }
    }
}