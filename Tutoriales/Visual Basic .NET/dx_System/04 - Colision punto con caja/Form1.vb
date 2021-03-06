﻿Option Strict Off
Option Explicit On

Imports System.Drawing
Imports System.Drawing.Drawing2D

Friend Class Form1
    Inherits System.Windows.Forms.Form

    Private Gfx As Graphics
    Private Sys As New dx_lib32.dx_System_Class ' Objeto que hace referencia a dx_System.
    Private A As dx_lib32.GFX_Rect ' Variables que contendran los valores de la caja.
    Private Result As String

    Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Gfx = Me.CreateGraphics

        ' Definimos la posicion y dimensiones de la caja A:
        A.X = 128
        A.Y = 64
        A.Width = 128
        A.Height = 64

    End Sub

    Private Sub Form1_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        ' Obtenemos el resultado de la colsion entre el puntero del raton y la caja:
        Result = Sys.MATH_PointInRect(eventArgs.X, eventArgs.Y, A).ToString()
        Form1_Paint(eventSender, Nothing)
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Gfx.Dispose()
    End Sub

    Private Sub Form1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        ' Limpiamos el formulario:
        Gfx.Clear(Color.Black)

        ' Actualizamos la posicion del control Shape en el formulario:
        Gfx.DrawRectangle(Pens.Red, New Rectangle(A.X, A.Y, A.Width, A.Height))

        ' Mostramos en pantalla el resultado de comprobar si existe o no colision entre las cajas A y B:
        Gfx.DrawString(Result, Me.Font, Brushes.White, 10, 10)
    End Sub
End Class