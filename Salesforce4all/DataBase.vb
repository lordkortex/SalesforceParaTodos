Imports MySql.Data.MySqlClient
Imports MySql.Data.MySqlClient.MySqlConnection
Imports System.Net.Mail
Imports System.Data.Odbc

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data
Imports System.Xml
Imports System.Data.SqlClient
Imports System.Net
Imports System.IO

Public Class DataBase

    'Private CadenaCon As String = "Server=50.62.209.46 ;Port=3306;Database=enofertapp_;Uid=	lordofertapp;Pwd=Cortesmoncada31*;"
    Private CadenaCon As String = "Server=mysql7001.site4now.net ;Port=3306;Database=db_a2e334_salesfo;Uid=a2e334_salesfo;Pwd=CortesMoncada31;"

    Public sqlString As String = ""


    Public Function normalizarHeader() As DataSet

        Dim dsUsuario As New DataSet
        Dim dtUsuario As New DataTable

        sqlString = "SELECT email,name,city,state,country,certificates FROM a_salesforce_header WHERE email not like '%@%'"
        dsUsuario = mySqlDataR()
        dtUsuario = dsUsuario.Tables(0)

        For Each row As DataRow In dtUsuario.Rows
            Dim primerNombre As String = row.Field(Of String)("name")
            Dim primerEmailInvalido As String = row.Field(Of String)("email")
            Dim primerCity As String = row.Field(Of String)("city")
            'Busco email en el mismo header
            sqlString = "SELECT email,name,city,state,country,certificates FROM a_salesforce_header WHERE name =  '" + primerNombre + "' and city = '" + primerCity + "' and  email like '%@%' Limit 1"
            Dim dsUsuarioPrimer As DataSet = mySqlDataR()
            Dim dtUsuarioPrimer As DataTable = dsUsuarioPrimer.Tables(0)
            If dtUsuarioPrimer.Rows.Count > 0 Then
                For Each rowItem As DataRow In dtUsuarioPrimer.Rows
                    Dim emailNew As String = rowItem.Field(Of String)("email")
                    'Actualiza el email del name and city and email invalido
                    sqlString = "UPDATE a_salesforce_header SET email = '" + emailNew + "'  WHERE name =  '" + primerNombre + "' and city = '" + primerCity + "' and  email = '" + primerEmailInvalido + "'"
                    mySqlDataR()
                Next
            Else
                'Si no encuentro busco email en el historico
                sqlString = "SELECT email,name,city,state,country,certificates FROM a_salesforce_historico WHERE name =  '" + primerNombre + "'  and city = '" + primerCity + "' and  email like '%@%' Limit 1"
                Dim dsUsuarioSegundo As DataSet = mySqlDataR()
                Dim dtUsuarioSegundo As DataTable = dsUsuarioSegundo.Tables(0)
                If dtUsuarioSegundo.Rows.Count > 0 Then
                    For Each rowItem As DataRow In dtUsuarioSegundo.Rows
                        Dim emailNew As String = rowItem.Field(Of String)("email")
                        'Actualiza el email del name and city and email invalido
                        sqlString = "UPDATE a_salesforce_header SET email = '" + emailNew + "'  WHERE name =  '" + primerNombre + "' and city = '" + primerCity + "' and  email = '" + primerEmailInvalido + "'"
                        mySqlDataR()
                    Next
                End If

            End If


        Next

        Return dsUsuario
    End Function

    Public Function selectHeader(ByVal email As String) As DataSet

        Dim dsUsuario As New DataSet
        Dim dtUsuario As New DataTable
        
        email = Replace(email, "'", "")

        If email IsNot Nothing Then
            sqlString = "SELECT email,name,city,state,country,certificates,link FROM a_salesforce_header WHERE (email = '" & email & "' OR link LIKE '%" + email + "%') AND certificates > 0 order by consultingDate DESC Limit 1"
            dsUsuario = mySqlDataR()
        End If
       
        Return dsUsuario
    End Function


    Public Function selectDetail(ByVal email As String) As DataSet

        Dim dsUsuario As New DataSet
        Dim dtUsuario As New DataTable

        email = Replace(email, "'", "")
        If email IsNot Nothing Then
            sqlString = "SELECT distinct email,certificate,certificateDate FROM a_salesforce_detail WHERE email = '" & email & "'  OR link LIKE '%" + email + "%'"
            dsUsuario = mySqlDataR()
        End If

        
        Return dsUsuario
    End Function

    Public Function insertHistorico(name As String, city As String, state As String, country As String, certificates As String, email As String, link As String, source As String) As Boolean

        Dim dsUsuario As New DataSet
        Dim dtUsuario As New DataTable

        If certificates = "" Then
            certificates = 0
        End If


        sqlString = "INSERT INTO `a_salesforce_historico` (`name`, `city`, `state`, `country`, `certificates`, `consultingDate`, `email`,`link`,`source`) " + _
                                    "VALUES  ('" + name + "', '" + city + "', '" + state + "', '" + country + "', '" + certificates + "', NOW() , '" + email + "', '" + link + "', '" + source + "');"
        dsUsuario = mySqlDataR()

    End Function

    Public Function insertHeader(name As String, city As String, state As String, country As String, certificates As String, email As String, link As String, source As String) As Boolean

        Dim dsUsuario As New DataSet
        Dim dtUsuario As New DataTable
       
        If email IsNot Nothing And email <> "" Then
            Dim dsCurrentRecord As DataSet = selectHeader(email)
            Dim dtCurrentRecord As DataTable = dsCurrentRecord.Tables(0)
            For Each row As DataRow In dtCurrentRecord.Rows
                link = row.Field(Of String)("link")
            Next

            'Delete header y detail
            sqlString = "DELETE FROM `a_salesforce_header` WHERE email = '" + email + "'"
            dsUsuario = mySqlDataR()
            'Insert Header y detail
            sqlString = "INSERT INTO `a_salesforce_header` (`name`, `city`, `state`, `country`, `certificates`, `consultingDate`, `email`,`link`) " + _
                                       "VALUES  ('" + name + "', '" + city + "', '" + state + "', '" + country + "', '" + certificates + "', NOW(), '" + email + "', '" + link + "');"
            dsUsuario = mySqlDataR()
        End If

    End Function

    Public Function deleteDetail(email As String) As Boolean

        If email IsNot Nothing And email <> "" Then
            Dim dsUsuario As New DataSet
            Dim dtUsuario As New DataTable
            sqlString = "Delete From `a_salesforce_detail` Where email = '" + email + "'"
            dsUsuario = mySqlDataR()
        End If
        
    End Function
    Public Function createSqlInsertDetail(email As String, certificate As String, certificateDate As String, classImage As String, link As String) As String
        sqlString = "INSERT INTO `a_salesforce_detail` (`email`, `certificate`, `certificateDate`, `classImage`, `link`) VALUES ('" + email + "', '" + certificate + "', '" + certificateDate + "', '" + classImage + "', '" + link + "');"
        Return sqlString
    End Function


    Public Function insertDetail(sql As String, email As String) As Boolean
        If email IsNot Nothing And email <> "" Then
            Dim dsUsuario As New DataSet
            Dim dtUsuario As New DataTable

            '2017-11-15 04:11:2
            sqlString = sql
            dsUsuario = mySqlDataR()
        End If


    End Function

    Public Function mySqlDataR() As DataSet
        Dim oConexion As New MySqlConnection()
        Dim adapter As New MySqlDataAdapter()
        Dim oComando As New MySqlCommand(sqlString, oConexion)
        Dim dataset As New DataSet

        Try
            oConexion.ConnectionString = CadenaCon
            oConexion.Open()
            adapter.SelectCommand = New MySqlCommand(sqlString, oConexion)
            adapter.Fill(dataset)
            oConexion.Dispose()
            oConexion.Close()

        Catch ex As Exception
        End Try

        Return dataset

    End Function

End Class
