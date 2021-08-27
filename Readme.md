<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128554723/17.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T517369)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))
<!-- default file list end -->
# ASPxHint - How to use server-side controls  inside ASPxHint
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t517369/)**
<!-- run online end -->


<p>When the mouse pointer is over the <strong><em>"event"</em></strong> or <strong><em>"date" </em></strong>word, ASPxHint is shown with ASPxListBox or ASPxCalendar inside.<br><br>Every time ASPxHint is shown, a callback is sent to the server to get the control's rendering. The <a href="https://documentation.devexpress.com/#AspNet/clsDevExpressWebASPxCallbacktopic">ASPxCallback</a> control is used to send callbacks.The <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxCallback_GetRenderResulttopic">ASPxCallback.GetRenderResult</a> method passes this rendering to the client side.<br><br>The page hierarchy is restored using ASPxHiddenField in the Page_Init event handler. It allows server-side controls to work using internal callbacks (for example, ASPxListbox loads items "on demand" using callbacks).</p>

<br/>


