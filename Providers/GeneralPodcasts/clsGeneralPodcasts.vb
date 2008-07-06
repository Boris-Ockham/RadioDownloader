﻿' Plugin for Radio Downloader to download general podcasts.
' Copyright © 2008  www.nerdoftheherd.com
'
' This program is free software; you can redistribute it and/or modify it under the terms of the GNU General
' Public License as published by the Free Software Foundation; either version 2 of the License, or (at your
' option) any later version.
'
' This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the
' implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public
' License for more details.
'
' You should have received a copy of the GNU General Public License along with this program; if not, write
' to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.

Option Strict On
Option Explicit On

Imports RadioDld
Imports System.Windows.Forms

Public Class clsGeneralPodcasts
    Implements IRadioProvider

    Public Event FoundNew(ByVal gidPluginID As Guid, ByVal strProgExtID As String) Implements IRadioProvider.FoundNew
    Public Event Progress(ByVal intPercent As Integer, ByVal strStatusText As String, ByVal Icon As IRadioProvider.ProgressIcon) Implements IRadioProvider.Progress
    Public Event DldError(ByVal errType As IRadioProvider.ErrorType, ByVal strErrorDetails As String) Implements IRadioProvider.DldError
    Public Event Finished() Implements IRadioProvider.Finished

    Public ReadOnly Property ProviderID() As Guid Implements IRadioProvider.ProviderID
        Get
            Return New Guid("3cfbe63e-95b8-4f80-8570-4ace909e0921")
        End Get
    End Property

    Public ReadOnly Property ProviderName() As String Implements IRadioProvider.ProviderName
        Get
            Return "General Podcasts"
        End Get
    End Property

    Public ReadOnly Property ProviderDescription() As String Implements IRadioProvider.ProviderDescription
        Get
            Return "Allows you to download programmes made available as Podcasts."
        End Get
    End Property

    ReadOnly Property DynamicSubscriptionName() As Boolean Implements IRadioProvider.DynamicSubscriptionName
        Get
            Return False
        End Get
    End Property

    Public Function GetFindNewPanel() As Panel Implements IRadioProvider.GetFindNewPanel
        Dim frmFindNewInst As New frmFindNew
        Return frmFindNewInst.pnlFindNew
    End Function

    Public Function GetProgrammeInfo(ByVal strProgExtID As String) As IRadioProvider.ProgrammeInfo Implements IRadioProvider.GetProgrammeInfo

    End Function

    Public Function CouldBeNewEpisode(ByVal strStationID As String, ByVal strProgramID As String, ByVal dteProgramDate As Date) As Boolean Implements IRadioProvider.CouldBeNewEpisode

    End Function

    Public Function IsStillAvailable(ByVal strStationID As String, ByVal strProgramID As String, ByVal dteProgramDate As Date, ByVal booIsLatestProg As Boolean) As Boolean Implements IRadioProvider.IsStillAvailable

    End Function

    Public Sub DownloadProgram(ByVal strStationID As String, ByVal strProgramID As String, ByVal dteProgramDate As Date, ByVal intProgLength As Integer, ByVal strProgDldUrl As String, ByVal strFinalName As String, ByVal intBandwidthLimitKBytes As Integer, ByVal intAttemptNumber As Integer) Implements IRadioProvider.DownloadProgram

    End Sub
End Class