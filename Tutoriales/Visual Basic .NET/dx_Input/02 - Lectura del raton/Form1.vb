Option Strict Off
Option Explicit On
Friend Class Form1
	Inherits System.Windows.Forms.Form
	
	Private GameInput As New dx_lib32.dx_Input_Class ' Instancia del objeto de entrada de dx_lib32.
	
	Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		GameInput.Init(Me.Handle.ToInt32)
	End Sub
	
	Private Sub Form1_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		GameInput.Terminate() ' Terminamos la ejecucion de la clase de entrada y liberamos los recursos utilizados.
		'UPGRADE_NOTE: El objeto GameInput no se puede destruir hasta que no se realice la recolecci�n de los elementos no utilizados. Haga clic aqu� para obtener m�s informaci�n: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		GameInput = Nothing
	End Sub
	
	Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
        With GameInput.Mouse
            Label1.Text = "Boton izquierdo: " & CType(.Left_Button, Boolean)
            Label2.Text = "Boton derecho: " & CType(.Right_Button, Boolean)
            Label3.Text = "Boton central: " & CType(.Middle_Button, Boolean)
            Label4.Text = "Coordenadas del cursor: " & .X.ToString() & "x " & .Y.ToString() & "y"
            Label5.Text = "Valor de la rueda: " & .Z.ToString()
        End With
	End Sub
End Class