using System;

namespace estoty_test
{
    public interface IController : IDisposable
    {
        void LinkModel(IModel model);
        void LinkView(IView view);
    }
}
