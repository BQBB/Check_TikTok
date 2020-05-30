Imports System.Text, System.IO, System.Threading, System.Net, System.Net.Mail
Public Class Form1
    Dim lis As New ListBox
    Dim re As String()
    Dim tru As Integer = 0
    Dim fls As Integer = 0
    Dim point As New Point()
    Dim boolean0 As Boolean
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MsgBox("This Project Coded By > Karar" + vbCrLf + "Instagram : BQBB" + vbCrLf + "Telegram : camera", True, "CopyRight")
        CheckForIllegalCrossThreadCalls = False

        re = File.ReadAllLines("list.txt")
        For i As Integer = 0 To re.Length - 1
            lis.Items.Add(re(i))
        Next

    End Sub
    Sub one()
        For i As Integer = 1 To Convert.ToInt32(TextBox5.Text)
            Dim thread As Thread = New Thread(AddressOf two)
            thread.Start(i)
        Next
    End Sub
    Sub two(i As Integer)
        Do
            Try
                Dim str As New StringBuilder()
                str.Append(lis.Items(i))

                lis.Items.RemoveAt(i)
                check(str.ToString())
            Catch ex As Exception

                Exit Sub
            End Try
        Loop
    End Sub
    Function check(user As String)
        Try
            If IsNumeric(user(0)) Then
                '' Pass
                TextBox2.AppendText(user + vbCrLf)
                fls += 1
                TextBox4.Text = fls.ToString()
            Else
                Dim req As HttpWebRequest = DirectCast(WebRequest.Create("https://www.tiktok.com/@" + user), HttpWebRequest)
                req.Method = "get"
                req.UserAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 9_3_2 like Mac OS X) AppleWebKit/601.1.46 (KHTML, like Gecko) Mobile/13F69 Tiktok 8.4.0 (iPhone7,2; iPhone OS 9_3_2; nb_NO; nb-NO; scale=2.00; 750x1334"
                req.CookieContainer = New CookieContainer
                Dim ris As HttpWebResponse = DirectCast(req.GetResponse(), HttpWebResponse)
                Dim strea As Stream = ris.GetResponseStream()
                Dim rdr As New StreamReader(strea)
                Dim result As String = rdr.ReadToEnd()
                If result.Contains("{""id"":") Then
                    TextBox2.AppendText(user + vbCrLf)
                    fls += 1
                    TextBox4.Text = fls.ToString()
                Else
                    save(user)
                    TextBox1.AppendText(user + vbCrLf)
                    tru += 1
                    TextBox3.Text = tru.ToString()
                End If
                Thread.Sleep(Convert.ToInt32(TextBox6.Text) * 1000)


            End If


        Catch ex As System.ObjectDisposedException

            End
        End Try
    End Function
    Sub save(text As String)
        Dim save As StreamWriter = File.AppendText("Available.txt")
        save.WriteLine(text)
        save.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        one()

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        End
    End Sub







    Private Sub Label1_MouseDown(sender As Object, e As MouseEventArgs) Handles Label1.MouseDown
        If e.Button = MouseButtons.Left Then
            Me.point = New Point((0 - e.X), (0 - e.Y))
            Me.boolean0 = True

        End If
    End Sub

    Private Sub Label1_MouseMove(sender As Object, e As MouseEventArgs) Handles Label1.MouseMove
        If Me.boolean0 Then
            Dim mousePosition As Point = Control.MousePosition
            mousePosition.Offset(Me.point.X, Me.point.Y)
            Me.Location = mousePosition

        End If
    End Sub

    Private Sub Label1_MouseUp(sender As Object, e As MouseEventArgs) Handles Label1.MouseUp
        If e.Button = MouseButtons.Left Then
            Me.boolean0 = False
        End If
    End Sub


End Class
