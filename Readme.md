<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))
<!-- default file list end -->
# ASPxHint - How to use server-side controls  inside ASPxHint


<p>When the mouse pointer is over the <strong><em>"event"</em></strong> or <strong><em>"date" </em></strong>word, ASPxHint is shown with ASPxListBox or ASPxCalendar inside.<br><br>Every time ASPxHint is shown, a callback is sent to the server to get the control's rendering. The <a href="https://documentation.devexpress.com/#AspNet/clsDevExpressWebASPxCallbacktopic">ASPxCallback</a> control is used to send callbacks.The <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxCallback_GetRenderResulttopic">ASPxCallback.GetRenderResult</a> method passes this rendering to the client side.<br><br>The page hierarchy is restored using ASPxHiddenField in the Page_Init event handler. It allows server-side controls to work using internal callbacks (for example, ASPxListbox loads items "on demand" using callbacks).</p>

<br/>


