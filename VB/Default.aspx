<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="ServerSideContent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style type="text/css">
        .target 
        {
            border-bottom: 1px dashed green;
            cursor: pointer;
        }

        // controls customization for hint's border-radius 
        .dxh-content 
        {
            padding: 0!important;
            border-radius: 4px!important;
            overflow: hidden;
        }
        .dxh-content .dxeCalendar,
        .dxh-content .dxeListBox,
        .dxh-content .dxlbd
        {
            border: none;
            border-radius: 4px;
        }
        .dxh-loading 
        {
            margin: 10px!important;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">

        <p>
        I want to book a ticket for an <span id="event" class="target" data-editor="listbox">event</span> that takes place on a certain <span id="date" class="target" data-editor="calendar">date</span>.
        </p>

        <dx:ASPxHiddenField ID="ASPxHiddenField1" runat="server"></dx:ASPxHiddenField>

        <dx:ASPxCallback ID="ASPxCallback1" runat="server" OnCallback="ASPxCallback1_Callback"></dx:ASPxCallback>

        <dx:ASPxHint ID="ASPxHint1" runat="server" TargetSelector=".target" ClientInstanceName="ASPxHint1" Position="bottom" TriggerAction="Click" Content="Sample content">
            <ClientSideEvents Showing="function(s, e) {
                    var targetID = e.targetElement.id;
                    var editor = e.targetElement.dataset['editor'];
                    var callbackParameter = targetID + ';' + editor;

                    s.SetContentLoading();

                    ASPxCallback1.PerformCallback(callbackParameter, function(result) { 
                        s.SetContent(result, {
                            autoProcessScriptsAndLinks: true,
                            autoUpdatePosition: true
                        });

                        ASPxHiddenField1.Set('hintContent', callbackParameter);
                    } );

                }" 
                />
        </dx:ASPxHint>

        <script type="text/javascript">
            function OnEditorChanged(targetID, value) {
                var target = document.getElementById(targetID);
                target.innerHTML = value;

                ASPxClientHint.HideAll();
            }
        </script>

    </form>
</body>
</html>