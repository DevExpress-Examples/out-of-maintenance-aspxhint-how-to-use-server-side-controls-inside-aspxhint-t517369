using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;

public partial class ServerSideContent : System.Web.UI.Page {

    protected void Page_Init(object sender, EventArgs e) {
        object parameters;
        if(ASPxHiddenField1.TryGet("hintContent", out parameters)) {
            getCreateHintContent(parameters.ToString());
        }
    }
    protected void Page_Load(object sender, EventArgs e) {
    }

    protected void ASPxCallback1_Callback(object source, CallbackEventArgs e) {
        var control = getCreateHintContent(e.Parameter);
        e.Result = ASPxCallback.GetRenderResult(control);
    }

    protected WebControl getCreateHintContent(string parameters) {
        var splitted = parameters.Split(';');
        var targetID = splitted[0];
        var editorType = splitted[1];

        WebControl editor = null;

        switch(editorType) {
            case "calendar":
                editor = CreateCalendar(targetID);
                break;
            case "listbox":
                editor = CreateListBox(targetID);
                break;
        }

        Form.Controls.Add(editor);
        return editor;
    }

    private static WebControl CreateCalendar(string targetID) {
        var calendar = new ASPxCalendar();
        calendar.ID = targetID + "_calendar";
        calendar.ClientSideEvents.SelectionChanged = string.Format("function(s, e) {{ OnEditorChanged('{0}', s.GetSelectedDate().toLocaleDateString()); }}", targetID);
        return calendar;
    }

    private static WebControl CreateListBox(string targetID) {
        var listbox = new ASPxListBox();
        listbox.ID = targetID + "_listbox";
        listbox.ClientSideEvents.SelectedIndexChanged = string.Format("function(s, e) {{ OnEditorChanged('{0}', s.GetSelectedItem().text); }}", targetID);
        listbox.EnableCallbackMode = true;
        listbox.CallbackPageSize = 10;
        for(int i = 0; i < 100; i++) {
            listbox.Items.Add(string.Format("event #{0}", i), i);
        }
        return listbox;
    }

}