Option Infer On

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web

Partial Public Class ServerSideContent
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        Dim parameters As Object = Nothing
        If ASPxHiddenField1.TryGet("hintContent", parameters) Then
            getCreateHintContent(parameters.ToString())
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    Protected Sub ASPxCallback1_Callback(ByVal source As Object, ByVal e As CallbackEventArgs)
        Dim control = getCreateHintContent(e.Parameter)
        e.Result = ASPxCallback.GetRenderResult(control)
    End Sub

    Protected Function getCreateHintContent(ByVal parameters As String) As WebControl
        Dim splitted = parameters.Split(";"c)
        Dim targetID = splitted(0)
        Dim editorType = splitted(1)

        Dim editor As WebControl = Nothing

        Select Case editorType
            Case "calendar"
                editor = CreateCalendar(targetID)
            Case "listbox"
                editor = CreateListBox(targetID)
        End Select

        Form.Controls.Add(editor)
        Return editor
    End Function

    Private Shared Function CreateCalendar(ByVal targetID As String) As WebControl
        Dim calendar = New ASPxCalendar()
        calendar.ID = targetID & "_calendar"
        calendar.ClientSideEvents.SelectionChanged = String.Format("function(s, e) {{ OnEditorChanged('{0}', s.GetSelectedDate().toLocaleDateString()); }}", targetID)
        Return calendar
    End Function

    Private Shared Function CreateListBox(ByVal targetID As String) As WebControl
        Dim listbox = New ASPxListBox()
        listbox.ID = targetID & "_listbox"
        listbox.ClientSideEvents.SelectedIndexChanged = String.Format("function(s, e) {{ OnEditorChanged('{0}', s.GetSelectedItem().text); }}", targetID)
        listbox.EnableCallbackMode = True
        listbox.CallbackPageSize = 10
        For i As Integer = 0 To 99
            listbox.Items.Add(String.Format("event #{0}", i), i)
        Next i
        Return listbox
    End Function

End Class