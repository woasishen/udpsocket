using System.Windows.Forms;

namespace SocketServer
{
    public static class HandleCtrlInOtherThread
    {
        public delegate void UpdateSelfCallBack();
        public delegate void UpdateSelfCallBackWithArg(object arg);

        public static void HandleCtrlInBackGroundThread(
                Control ctrl,
                UpdateSelfCallBack call)
        {
            if (ctrl.InvokeRequired)
            {
                var updateSelfCallBack =
                        new UpdateSelfCallBack(call);
                ctrl.Invoke(updateSelfCallBack, new object[] { });
            }
            else
            {
                call.Invoke();
            }
        }

        public static void HandleCtrlInBackGroundThread(
                Control ctrl,
                UpdateSelfCallBackWithArg call,
                object arg)
        {
            if (ctrl.InvokeRequired)
            {
                var updateSelfCallBack =
                        new UpdateSelfCallBackWithArg(call);
                ctrl.Invoke(updateSelfCallBack, new object[] { arg });
            }
            else
            {
                call(arg);
            }
        }
    }
}
