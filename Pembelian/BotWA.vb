Imports OpenQA.Selenium
Imports OpenQA.Selenium.Keys
Imports OpenQA.Selenium.Chrome
Imports System.Threading.Thread
Imports System.Text.RegularExpressions
Public Class BotWA
    Dim driver As IWebDriver = New ChromeDriver

    Private Sub BotWA_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        tmkirimkontak.Stop()
        tmkirimtanpakontak.Stop()
        driver.Quit()
        driver.Dispose()
    End Sub

    Private Sub BotWA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        driver.Navigate().GoToUrl("https://web.whatsapp.com")

        With tmkirimtanpakontak
            .Interval = 1000
            .Start()
        End With

        With tmkirimkontak
            .Interval = 1000
            .Start()
        End With
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        driver.Close()
    End Sub

    Private Sub tmkirimkontak_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmkirimkontak.Tick
        tmkirimkontak.Stop()
        If IsStart = False Then
            driver.Quit()
            driver.Dispose()
            Close()
            Exit Sub
        End If
        Dim sTujuan, sPesan As String

        If idgtjn = Nothing Then GoTo finish
        sTujuan = idgtjn
        sPesan = pesankirim

        idgtjn = Nothing
        pesankirim = Nothing

        Dim Elementcarikontak, Elementisipesankontak As String

        With My.Settings
            Elementcarikontak = .elcarikontak
            Elementisipesankontak = .elisipesankontak
        End With

        Dim element As IWebElement = driver.FindElement(By.XPath(Elementcarikontak))
        Clipboard.SetText(sTujuan)
        With element
            .Click()
            .SendKeys(Keys.Control + "v")
            .SendKeys(Keys.Enter)
        End With


        Dim elpesan As IWebElement = driver.FindElement(By.XPath(Elementisipesankontak))
        Clipboard.SetText(sPesan)
        With elpesan
            .Click()
            .SendKeys(Keys.Control + "v")
            .SendKeys(Keys.Enter)
        End With

finish:
        tmkirimkontak.Start()


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Nol = Microsoft.VisualBasic.Left(WAstruk.TBhareg.Text, 1)
        Dim NomorFix As String
        If Nol = "0" Then
            Dim TotalDigit = WAstruk.TBhareg.Text.Length
            Dim FixTotalDigit = TotalDigit - 1
            NomorFix = "62" & Microsoft.VisualBasic.Right(WAstruk.TBhareg.Text.ToString, FixTotalDigit)
        Else
            NomorFix = WAstruk.TBhareg.Text.ToString
        End If
        Sleep(2000)



        Dim Nomorwa = NomorFix
        Dim ApiWA = "https://web.whatsapp.com/send?phone=" & Nomorwa & "&text=" & WAstruk.GunaTextBox1.Text & WAgaji.GunaTextBox1.Text
        driver.Navigate().GoToUrl(ApiWA)
        Sleep(2000)




        






        'Dim elemensend As String = "//*[@class='button button--simple button--primary']"
        'Dim elkirim As IWebElement = driver.FindElement(By.XPath(elemensend))

        'With elkirim
        '    .Click()




        'End With



    End Sub

    Private Sub tmkirimtanpakontak_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmkirimtanpakontak.Tick
        Try
            Dim Elementisipesankontak As String

        With My.Settings
                Elementisipesankontak = .elisipesankontak
            End With

        Dim elpesan As IWebElement = driver.FindElement(By.XPath(Elementisipesankontak))

        With elpesan
            .Click()
            .SendKeys(Keys.Enter)
            End With

        Catch ex As Exception

        End Try


    End Sub
End Class